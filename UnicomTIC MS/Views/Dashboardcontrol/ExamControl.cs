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

namespace UnicomTIC_MS.Views.Dashboardcontrol
{
    public partial class ExamControl : UserControl
    {
        public ExamControl()
        {
            InitializeComponent();
            LoadExams();
        }
        private void LoadExams() 
        {
            dgvExams.Rows.Clear();
            var exams = ExamController.GetAllExamsWithSubject();

            foreach (var exam in exams) 
            {
                dgvExams.Rows.Add(
                    exam.ExamId,
                    exam.ExamName,
                    exam.SubjectName,
                    exam.SubjectId
                );
            }
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            var form = new AddExamform();
            form.ShowDialog();
            LoadExams();
        }

        private void ExamControl_Load(object sender, EventArgs e)
        {   }
        
    }
}
