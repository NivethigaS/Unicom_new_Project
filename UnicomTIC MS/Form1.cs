using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_MS.Controllers;
using UnicomTIC_MS.Models;
using UnicomTIC_MS.Views;

namespace UnicomTIC_MS
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            string AdminUsername = "admin01";
            string AdminPassword = "12345";

            if (username == AdminUsername && password == AdminPassword) 
            {
                Roles.Username = AdminUsername;
                Roles.Role = UserRole.Admin.ToString();

                MessageBox.Show("Welcome Admin!", "Login Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var dashboard = new dashboardform();
                dashboard.Show();
                this.Hide();
                return;
            }
            else 
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var user = UserController.Authenticate(username, password); 

            if (user != null)
            {
                Roles.Username = user.Username;
                Roles.UserId = user.Id;
                Roles.Role = user.Role.ToString();

                MessageBox.Show($"Welcome {user.Username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dashboardform dashboardform = new dashboardform();
                dashboardform.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Invalid login!");
            }
        }
    }
}
