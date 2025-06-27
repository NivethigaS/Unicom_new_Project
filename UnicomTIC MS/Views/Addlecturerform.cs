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
    public partial class Addlecturerform : Form
    {
        private int _userId = -1;
        public Addlecturerform()
        {
            InitializeComponent();
        }
        public Addlecturerform(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadLecturerDetails(userId);
        }
        private void LoadLecturerDetails(int userId)
        {
            using (SQLiteConnection conn = SQLiteConfig.GetConnection())
            {
                string query = @"SELECT * FROM users user
                        JOIN lecturers lect ON user.id = lect.user_id
                        WHERE user.id = @userId;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
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
                            txtsubjects.Text = reader["subjects"].ToString();
                        }
                    }
                }
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            User user = new User
            {

                FirstName = txtfirstname.Text.Trim(),
                LastName = txtlastname.Text.Trim(),
                Gender = cmbogender.SelectedItem?.ToString(),
                DateOfBirth = dtpick.Value,
                Address = txtaddress.Text.Trim(),
                Email = txtemail.Text.Trim(),
                Password = txtpassword.Text.Trim(),
                Username = txtusername.Text.Trim(),
                Role = UserRole.Lecturer,
                Phone = txtphone.Text.Trim()
            };
            Lecturer lecturer = new Lecturer()
            {
                Subjects = txtsubjects.Text.Trim(),
            };
            try
            {
                LecturerController.AddLecturer(user, lecturer);
                MessageBox.Show("Lecturer added successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void lblpassword_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
