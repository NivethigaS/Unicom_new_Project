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
    public partial class StudentControl : UserControl
    {
        public StudentControl()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents() 
        {
            List<Student> studentList = StudentController.GetAllStudents();
            dgvStudents.DataSource = studentList;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (var form = new addstudentform()) 
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStudents();
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) 
            {
                MessageBox.Show("Please select a student row to update.");
                return;
            }
            Student selected = (Student)dgvStudents.CurrentRow.DataBoundItem;

            using (var form = new addstudentform(selected.StudentNumber, selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStudents();
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) 
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }
            Student selected = (Student)dgvStudents.CurrentRow.DataBoundItem;

            using (var form = new addstudentform(selected.StudentNumber, selected)) 
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStudents();
            }
        }

        private void StudentControl_Load(object sender, EventArgs e)
        {
            LoadStudents();


            {
                UserRole parsedRole = (UserRole)Enum.Parse(typeof(UserRole), Roles.Role);
                if (parsedRole == UserRole.Student)
                {
                    btnAddStudent.Enabled = false;
                    btnUpdateStudent.Enabled = false;
                    btnDeleteStudent.Enabled = false;
                }
            }
        }
    }
}
