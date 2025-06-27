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
    public partial class addstudentform : Form
    {
        public addstudentform(string studentNumber, Student selected)
        {
            InitializeComponent();
            isUpdate = false;
        }
        public addstudentform(User user, Student student)
        {
            InitializeComponent();
            isUpdate = true;
            selectedUser = user;
            selectedStudent = student;
            LoadStudentData();
        }

        public addstudentform()
        {
        }

        public addstudentform(string v, Staff selected)
        {
        }

        private bool isUpdate = false;
        private User selectedUser;
        private Student selectedStudent;

        private void LoadStudentData()
        {
            txtfirstname.Text = selectedUser.FirstName;
            txtlastname.Text = selectedUser.LastName;
            cmbgender.SelectedItem = selectedUser.Gender;
            txtaddress.Text = selectedUser.Address;
            dtpdateofbirth.Value = selectedUser.DateOfBirth;
            txtemail.Text = selectedUser.Email;
            txtphone.Text = selectedUser.Phone;
            txtusername.Text = selectedUser.Username;
            txtpassword.Text = selectedUser.Password;
            txtstudentnumber.Text = selectedStudent.StudentNumber;
            txtcourse.Text = selectedStudent.Course;
        }

        private void btnsavestudent_Click(object sender, EventArgs e)
        {
            User u = new User
            {
                FirstName = txtfirstname.Text,
                LastName = txtlastname.Text,
                Gender = cmbgender.SelectedItem.ToString(),
                Address = txtaddress.Text,
                DateOfBirth = dtpdateofbirth.Value,
                Email = txtemail.Text,
                Phone = txtphone.Text,
                Username = txtusername.Text,
                Password = txtpassword.Text,
                Role = UserRole.Student
            };

            Student s = new Student
            {
                StudentNumber = txtstudentnumber.Text,
                Course = txtcourse.Text,
            };

            try
            {
                if (isUpdate)
                {
                    u.Id = selectedUser.Id;
                 
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void lbladdress_Click(object sender, EventArgs e)
        {

        }

        private void lblphone_Click(object sender, EventArgs e)
        {

        }

        private void txtcourse_TextChanged(object sender, EventArgs e)
        {

        }

        private void addstudentform_Load(object sender, EventArgs e)
        {

        }

        private void btnx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
