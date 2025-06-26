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
            
    }
}
