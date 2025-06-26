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
    public partial class AddstaffForm : Form
    {
        private int _staffID;
        public AddstaffForm()
        {
            InitializeComponent();
            
        }

        public AddstaffForm(int staffID, Staff selected)
        {
            InitializeComponent();
            _staffID = staffID;
            LoadStaffData();

        }
        private void LoadStaffData()
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string query = @"SELECT * FROM users user
                                 JOIN staffs staff ON user.id = staff.user_id
                                 WHERE staff.staff_id = @staffID;";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@staffID", _staffID);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtfirstname.Text = reader["first_name"].ToString();
                            txtlastname.Text = reader["last_name"].ToString();
                            cmbogender.SelectedItem = reader["gender"].ToString();
                            dtpick.Value = DateTime.Parse(reader["date_of_birth"].ToString());
                            txtaddress.Text = reader["address"].ToString();
                            txtemail.Text = reader["email"].ToString();
                            txtpassword.Text = reader["password"].ToString();
                            txtusername.Text = reader["username"].ToString();
                            txtphone.Text = reader["phone"].ToString();
                            txtdesignation.Text = reader["designation"].ToString();

                        }
                    }
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.FirstName = txtfirstname.Text;
            u.LastName = txtlastname.Text;
            u.Gender = cmbogender.SelectedItem.ToString();
            u.Address = txtaddress.Text;
            u.DateOfBirth = dtpick.Value;
            u.Email = txtemail.Text;
            u.Phone = txtphone.Text;
            u.Username = txtusername.Text;
            u.Password = txtpassword.Text;
            u.Role = UserRole.Staff;

            Staff s = new Staff();
            s.Designation = txtdesignation.Text;

            try 
            {
                StaffController.AddStaff(u, s);
                MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

            
    }
}
