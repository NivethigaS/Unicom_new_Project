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

namespace UnicomTIC_MS.Views.Dashboardcontrol
{
    public partial class StaffControl : UserControl
    {
        public StaffControl()
        {
            InitializeComponent();
            LoadStaff();
        }
        private void LoadStaff() 
        {
            dgvstaff.DataSource = StaffController.GetAllStaffs();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddstaff_Click(object sender, EventArgs e)
        {
            AddstaffForm addform = new AddstaffForm();
            if (addform.ShowDialog() == DialogResult.OK)
            {
                LoadStaff();
            }
            
        }

        private void btnUpdatestaff_Click(object sender, EventArgs e)
        {
            if (dgvstaff.CurrentRow == null)
            {
                MessageBox.Show("Please select a staff to update.");
                return;
            }
            Staff selected = (Staff)dgvstaff.CurrentRow.DataBoundItem;

            using (var form = new AddstaffForm(selected.StaffID, selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStaff();
            }
        }

        private void btnDeletestaff_Click(object sender, EventArgs e)
        {
            if (dgvstaff.CurrentRow == null)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }
            Staff selected = (Staff)dgvstaff.CurrentRow.DataBoundItem;

            using (var form = new addstudentform(selected.StaffID.ToString(), selected))

            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStaff();
            }
        }
        public static void AddStaff(User user, Staff staff)
        {
            using (var conn = SQLiteConfig.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string userQuery = @"INSERT INTO users 
                (first_name, last_name, gender, date_of_birth, address, email, password, username, role, phone) 
                VALUES 
                (@first_name, @last_name, @gender, @dob, @address, @email, @password, @username, @role, @phone);
                SELECT last_insert_rowid();";

                        long userId;

                        using (var userCmd = new SQLiteCommand(userQuery, conn))
                        {
                            userCmd.Parameters.AddWithValue("@first_name", user.FirstName);
                            userCmd.Parameters.AddWithValue("@last_name", user.LastName);
                            userCmd.Parameters.AddWithValue("@gender", user.Gender);
                            userCmd.Parameters.AddWithValue("@dob", user.DateOfBirth.ToString("yyyy-MM-dd"));
                            userCmd.Parameters.AddWithValue("@address", user.Address);
                            userCmd.Parameters.AddWithValue("@email", user.Email);
                            userCmd.Parameters.AddWithValue("@password", user.Password);
                            userCmd.Parameters.AddWithValue("@username", user.Username);
                            userCmd.Parameters.AddWithValue("@role", user.Role.ToString());
                            userCmd.Parameters.AddWithValue("@phone", user.Phone);

                            userId = (long)userCmd.ExecuteScalar(); 
                        }

                        // Insert into staff table
                        string staffQuery = "INSERT INTO staffs (user_id, designation) VALUES (@user_id, @designation);";

                        using (var staffCmd = new SQLiteCommand(staffQuery, conn))
                        {
                            staffCmd.Parameters.AddWithValue("@user_id", userId);
                            staffCmd.Parameters.AddWithValue("@designation", staff.Designation);
                            staffCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw; 
                    }
                }
            }
        }


    }
}
