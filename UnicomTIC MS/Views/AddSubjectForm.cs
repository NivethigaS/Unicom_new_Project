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
                string query = @"SELECT s.subject_id, s.subject_name, c.course_name, s.course_id
                    FROM subject s
                    JOIN course c ON s.course_id = c.course_id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvSubjects.Rows.Add(
                            reader["subject_id"],
                            reader["subject_name"],
                            reader["course_name"],
                            reader["course_id"]
                        );
                    }
                }
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblSubjectName.Text) || cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            Subject subject = new Subject
            {
                SubjectName = lblSubjectName.Text,
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
                lblSubjectName.Text = row.Cells[1].Value.ToString();
                cmbCourse.SelectedValue = row.Cells[3].Value.ToString();
                lblSubjectName.Tag = row.Cells[0].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblSubjectName.Tag == null) 
            {
                MessageBox.Show("Please select a subject to update");
                return;
            }
            Subject subject = new Subject
            {
                SubjectName = lblSubjectName.Text,
                SubjectID = Convert.ToInt32(lblSubjectName.Tag),
                CourseID = Convert.ToInt32(cmbCourse.SelectedValue)
            };

            using (var conn = SQLiteConfig.GetConnection()) 
            {
         
                string query = "UPDATE subject SET subject_name = @name, course_id = @course_id WHERE subject_id = @id";
                using (var cmd = new SQLiteCommand(query, conn)) 
                {
                    cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@course_id", subject.CourseID);
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
            if (lblSubjectName.Tag == null) 
            {
                MessageBox.Show("Please select a subject to delete");
                return;
            }
            int subjecteId = Convert.ToInt32(lblSubjectName.Tag);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this subject?", "Confirm",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                using (var conn = SQLiteConfig.GetConnection()) 
                {
                    
                    string query = "DELETE FROM subject WHERE subject_id = @id";
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
            lblSubjectName.Tag = null;
            cmbCourse.SelectedIndex = 0;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
