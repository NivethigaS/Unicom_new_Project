using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_MS.Controllers;
using UnicomTIC_MS.Data;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Views
{
    public partial class AddSubjectform : Form
    {
        public AddSubjectform()
        {
            InitializeComponent();
            LoadCourses();
            LoadSubjects();
        }
        private void LoadCourses()
        {
            cmbCourse.DataSource = CourseController.GetAllCourses();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseId";
        }
        private void LoadSubjects()
        {
            dgvSubjects.Rows.Clear();
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string query = @"SELECT s.SubjectId, s.SubjectName, c.CourseName, s.CourseId
                    FROM subject s
                    JOIN course c ON s.CourseId = c.CourseId";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvSubjects.Rows.Add(
                            reader["SubjectId"],
                            reader["SubjectName"],
                            reader["CourseName"],
                            reader["CourseId"]
                        );
                    }
                }
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) || cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            Subject subject = new Subject
            {
                SubjectName = txtSubjectName.Text,
                CourseID = Convert.ToInt32(cmbCourse.SelectedValue)
            };
            SubjectController.AddSubject(subject);
            MessageBox.Show("Subject Added!");
            ClearInputs();
            LoadSubjects();
            
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvSubjects.Rows[e.RowIndex];
                txtSubjectName.Text = row.Cells[1].Value.ToString();
                cmbCourse.SelectedValue = row.Cells[3].Value.ToString();
                txtSubjectName.Tag = row.Cells[0].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSubjectName.Tag == null) 
            {
                MessageBox.Show("Please select a subject to update");
                return;
            }
            Subject subject = new Subject
            {
                SubjectName = txtSubjectName.Text,
                SubjectID = Convert.ToInt32(txtSubjectName.Tag),
                CourseID = Convert.ToInt32(cmbCourse.SelectedValue)
            };

            using (var conn = SQLiteConfig.GetConnection()) 
            {
                conn.Open();
                string query = "UPDATE subject SET SubjectName = @name, CourseId = @courseId WHERE SubjectId = @id";
                using (var cmd = new SQLiteCommand(query, conn)) 
                {
                    cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                    cmd.Parameters.AddWithValue("@id", subject.SubjectID);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Subject Updated Successfully!");
            ClearInputs();
            LoadSubjects();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSubjectName.Tag == null) 
            {
                MessageBox.Show("Please select a subject to delete");
                return;
            }
            int subjecteId = Convert.ToInt32(txtSubjectName.Tag);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this subject?", "Confirm",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                using (var conn = SQLiteConfig.GetConnection()) 
                {
                    conn.Open();
                    string query = "DELETE FROM subjects WHERE SubjectedId = @id";
                    using(var cmd = new SQLiteCommand(query, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@id", subjecteId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Subject deleted Successfully!");
                ClearInputs();
                LoadSubjects();
            }
        }
        private void ClearInputs() 
        {
            txtSubjectName.Text = "";
            txtSubjectName.Tag = null;
            cmbCourse.SelectedIndex = 0;
        }

    }
}
