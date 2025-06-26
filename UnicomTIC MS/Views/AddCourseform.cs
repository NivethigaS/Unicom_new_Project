using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_MS.Controllers;
using UnicomTIC_MS.Models;

namespace UnicomTIC_MS.Views
{
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
            LoadCourses();
        }
        private void LoadCourses()
        {
            dgvCourses.Rows.Clear();
            var courseList = CourseController.GetAllCourses();
            foreach (var c in courseList)
            {
                dgvCourses.Rows.Add(c.CourseId, c.CourseName, c.Duration);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text) || string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            Course course = new Course
            {
                CourseName = txtCourseName.Text,
                Duration = txtDuration.Text,
            };

            CourseController.AddCourse(course);
            MessageBox.Show("Course Added!");
            ClearInputs();
            LoadCourses();
        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                txtCourseName.Text = row.Cells["1"].Value.ToString();
                txtDuration.Text = row.Cells["2"].Value.ToString();
                txtCourseName.Tag = row.Cells["0"].Value;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtCourseName.Tag == null)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }
            Course course = new Course
            {
                CourseId = Convert.ToInt32(txtCourseName.Tag),
                CourseName = txtCourseName.Text,
                Duration = txtDuration.Text
            };
            CourseController.UpdateCourse(course);
            MessageBox.Show("Course Updated!");
            ClearInputs();
            LoadCourses();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtCourseName.Tag == null)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }
            int courseId = Convert.ToInt32(txtCourseName.Tag);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CourseController.DeleteCourse(courseId);
                MessageBox.Show("Course Deleted!");
                ClearInputs();
                LoadCourses();
            }

        }
        private void ClearInputs()
        {
            txtCourseName.Clear();
            txtDuration.Clear();
            txtCourseName.Tag = null;
        }
    }
}
