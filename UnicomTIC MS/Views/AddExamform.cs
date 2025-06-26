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
    public partial class AddExamform : Form
    {
        public AddExamform() 
        {
            InitializeComponent();
            LoadSubjects();
            LoadExams();
        }
        private void LoadSubjects()
        {
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectId";
            cmbSubject.DataSource = SubjectController.GetAllSubjects();

        }
        private void LoadExams() 
        {
            dgvExams.Rows.Clear();
            var exams = ExamController.GetAllExamsWithSubject();
            foreach (var exam in exams) 
            {
                dgvExams.Rows.Add(exam.ExamId, exam.ExamName, exam.SubjectName, exam.SubjectId);
            }
        }
        
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExamName.Text) || cmbSubject.SelectedValue == null) 
            {
                MessageBox.Show("Please Enter all field");
                return;
            }
            Exam exam = new Exam
            {
                ExamName = txtExamName.Text,
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue)
            };

            ExamController.AddExam(exam);
            MessageBox.Show("Exam added!");
            ClearInputs();
            LoadExams();

        }

        private void dgvExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvExams.Rows[e.RowIndex];
                txtExamName.Text = row.Cells[1].Value.ToString();
                cmbSubject.SelectedValue = row.Cells[3].Value;
                txtExamName.Tag = row.Cells[0].Value;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtExamName.Tag == null)
            {
                MessageBox.Show("Please select an exam to update.");
                return;
            }
            Exam exam = new Exam
            {
                ExamId = Convert.ToInt32(txtExamName.Tag),
                ExamName = txtExamName.Text,
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue)
            };

            ExamController.UpdateExam(exam);
            MessageBox.Show("Exam updated!");
            ClearInputs();
            LoadExams();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtExamName.Tag == null)
            {
                MessageBox.Show("Please select an exam to delete.");
                return;
            }
            int examId = Convert.ToInt32(txtExamName.Tag);
            DialogResult result = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                ExamController.DeleteExam(examId);
                MessageBox.Show("Deleted!");
                ClearInputs();
                LoadExams();
            }
        }
        private void ClearInputs()
        {
            txtExamName.Clear();
            txtExamName.Tag = null;
            cmbSubject.SelectedIndex = 0;
        }
    }
}

