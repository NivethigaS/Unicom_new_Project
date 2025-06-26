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
using UnicomTIC_MS.Views.Dashboardcontrol;
using UnicomTIC_MS.Views.Dashboardform;

namespace UnicomTIC_MS.Views
{
    public partial class dashboardform : Form
    {
        public dashboardform()
        {
            InitializeComponent();
            ApplyRoleBaseAcces();
            
        }
        private void ApplyRoleBaseAcces() 
        {
            var Role = Roles.Role;

            if (string.IsNullOrEmpty(Role))
            {
                MessageBox.Show("User role not set. Please login again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            UserRole parsedRole = (UserRole)Enum.Parse(typeof(UserRole), Role);


            
            

            if (parsedRole == UserRole.Lecturer)
            {
                btnstudent.Visible = false;
                btnstaff.Visible = false;
                btnlecturer.Visible = true;
                btncourse.Visible = true;
                btnMark.Visible = true;
                btnExam.Visible = true;
                btntimetable.Visible = true;
                btnRoom.Visible = true;


            }

            else if (parsedRole == UserRole.Student)
            {
                btnstudent.Visible = true;
                btnlecturer.Visible = false;
                btnstaff.Visible = false;
                btncourse.Visible = true;
                btnMark.Visible = true;
                btnExam.Visible = true;
                btntimetable.Visible = true;
                btnRoom.Visible = true;

            }
            else if (parsedRole == UserRole.Staff)
            {
                btnstaff.Visible = true;
                btncourse.Visible = true;
                btnlecturer.Visible = false;
                btnstudent.Visible = false;
                btnMark.Visible = true;
                btnExam.Visible = true;
                btntimetable.Visible = true;
                btnRoom.Visible = true;


            }

            
            
        }
        private void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void LoadLecturerControl(LecturerControl lecturerControl) 
        {
            panelMain.Controls.Clear();
            lecturerControl = new LecturerControl();
            lecturerControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(lecturerControl);
        }

        private void btnlecturer_Click(object sender, EventArgs e)
        {
            LoadLecturerControl(new LecturerControl());
        }

        private void LoadStudentControl(StudentControl studentControl) 
        {
            panelMain.Controls.Clear();
            studentControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(studentControl);
        }

        private void btnstudent_Click(object sender, EventArgs e)
        {
            UserRole parsedRole = (UserRole)Enum.Parse(typeof(UserRole), Roles.Role);
            if (parsedRole == UserRole.Lecturer || parsedRole == UserRole.Staff)
            {
                MessageBox.Show("Access Denied.");
                return;
            }
                LoadStudentControl(new StudentControl());

        }
        private void LoadUserControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnstaff_Click(object sender, EventArgs e)
        {

            UserRole parsedRole = (UserRole)Enum.Parse(typeof(UserRole), Roles.Role);
            if (parsedRole == UserRole.Lecturer || parsedRole == UserRole.Student)
            {
                MessageBox.Show("Access Denied.");
                return;
            }
            LoadControl(new StaffControl());
        }
        private void LoadCoursecControl() 
        {
            panelMain.Controls.Clear();
            CourseControl courseControl = new CourseControl();
            courseControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(courseControl);
        }

        private void btncourse_Click(object sender, EventArgs e)
        {
            LoadControl(new CourseControl());
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            LoadControl(new MarkControl());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserRole parsedRole = (UserRole)Enum.Parse(typeof(UserRole), Roles.Role);
            if (parsedRole == UserRole.Staff)
            {
                MessageBox.Show("Access Denied.");
                return;
            }
            LoadControl(new ExamControl());
        }

        private void btntimetable_Click(object sender, EventArgs e)
        {
            LoadControl(new TimetableControl());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadControl(new RoomControl());

        }
    }
}
