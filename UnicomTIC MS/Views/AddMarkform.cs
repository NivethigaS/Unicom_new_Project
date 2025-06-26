using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_MS.Controllers;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Views
{
    public partial class AddMarkform : Form
    {
        public AddMarkform()
        {
            InitializeComponent();
            LoadStudents();
            LoadExams();
            LoadMarks();
        }
        private void LoadStudents()
        {
            cmbStudent.DisplayMember = "StudentName";
            cmbStudent.ValueMember = "StudentId";
            cmbStudent.DataSource = StudentController.GetAllStudents();
        }
        private void LoadExams()
        {
            cmbExam.DisplayMember = "ExamName";
            cmbExam.ValueMember = "ExamId";
            cmbExam.DataSource = ExamController.GetAllExamsWithSubject();
        }
        private void LoadMarks()
        {
            dgvMarks.Rows.Clear();
            var marks = MarkController.GetAllMarks();
            foreach (var m in marks)
            {
                dgvMarks.Rows.Add(m.MarkId, m.StudentName, m.ExamName, m.Score, m.StudentId, m.ExamId);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedValue == null || cmbExam.SelectedValue == null || string.IsNullOrWhiteSpace(txtScore.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            int score;
            if (!int.TryParse(txtScore.Text, out score) || score < 0 || score > 100)
            {
                MessageBox.Show("Score must be between 0 and 100.");
                return;
            }

            Mark mark = new Mark
            {
                StudentID = Convert.ToInt32(cmbStudent.SelectedValue),
                ExamId = Convert.ToInt32(cmbExam.SelectedValue),
                Score = score
            };

            MarkController.AddMark(mark);
            MessageBox.Show("Mark added!");
            ClearInputs();
            LoadMarks();
        }

        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMarks.Rows[e.RowIndex];
                cmbStudent.SelectedValue = row.Cells[4].Value;
                cmbExam.SelectedValue = row.Cells[5].Value;
                txtScore.Text = row.Cells[3].Value.ToString();
                txtScore.Tag = row.Cells[0].Value;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtScore.Tag == null)
            {
                MessageBox.Show("Please select a mark to update.");
                return;
            }

            int score;
            if (!int.TryParse(txtScore.Text, out score) || score < 0 || score > 100)
            {
                MessageBox.Show("Score must be between 0 and 100.");
                return;
            }
            Mark mark = new Mark
            {
                MarkId = Convert.ToInt32(txtScore.Tag),
                StudentID = Convert.ToInt32(cmbStudent.SelectedValue),
                ExamId = Convert.ToInt32(cmbExam.SelectedValue),
                Score = score
            };
            MarkController.UpdateMark(mark);
            MessageBox.Show("Updated successfully!");
            ClearInputs();
            LoadMarks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtScore.Tag == null)
            {
                MessageBox.Show("Please select a mark to delete.");
                return;
            }
            int markId = Convert.ToInt32(txtScore.Tag);
            DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MarkController.DeleteMark(markId);
                MessageBox.Show("Deleted successfully!");
                ClearInputs();
                LoadMarks();
            }
        }
        private void ClearInputs()
        {
            cmbStudent.SelectedIndex = 0;
            cmbExam.SelectedIndex = 0;
            txtScore.Clear();
            txtScore.Tag = null;
        }
    }
}
