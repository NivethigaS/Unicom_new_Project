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

namespace UnicomTIC_MS.Views.Dashboardcontrol
{
    public partial class CourseControl : UserControl
    {
        public CourseControl()
        {
            InitializeComponent();
            LoadCourseSubjectTable();
        }

        public void LoadCourseSubjectTable()
        {
            using (var conn = SQLiteConfig.GetConnection()) 
            {
                
                string query = @"SELECT c.course_name, c.duration, s.subject_name, c.course_id
                    FROM course c
                    LEFT JOIN subject s ON c.course_id = s.course_id";

                using (var adapter = new SQLiteDataAdapter(query, conn)) 
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvCourseSubjects.DataSource = dataTable;

                    dgvCourseSubjects.Columns["course_name"].HeaderText = "Course Name";
                    dgvCourseSubjects.Columns["duration"].HeaderText = "Duration";
                    dgvCourseSubjects.Columns["subject_name"].HeaderText = "Subject Name";
                }
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddCourseForm addCourseForm = new AddCourseForm();
            addCourseForm.FormClosed += (s, args) => LoadCourseSubjectTable();
            addCourseForm.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            AddSubjectform addSubjectForm = new AddSubjectform();
            addSubjectForm.FormClosed += (s, args) => LoadCourseSubjectTable();
            addSubjectForm.ShowDialog();
        }

        private void AddSubjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CourseControl_Load(object sender, EventArgs e)
        {

        }
    }
}
