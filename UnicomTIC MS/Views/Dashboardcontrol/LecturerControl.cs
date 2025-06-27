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

namespace UnicomTIC_MS.Views.Dashboardform
{
    public partial class LecturerControl : UserControl
    {
        public LecturerControl()
        {
            InitializeComponent();
            LoadLecturers();
        }
        private void LoadLecturers() 
        {
            DataTable datatable = LecturerController.GetAllLecturers();
            dataGridViewlecturer.DataSource = datatable;

        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            Addlecturerform addform = new Addlecturerform();
            if (addform.ShowDialog() == DialogResult.OK) 
            {
                LoadLecturers();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewlecturer.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridViewlecturer.SelectedRows[0].Cells["id"].Value);
                Addlecturerform addform = new Addlecturerform(userId);
                if (addform.ShowDialog() == DialogResult.OK)
                {
                    LoadLecturers();
                }
            }
            else 
            {
                MessageBox.Show("Please select a lecturer to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewlecturer.SelectedRows.Count > 0) 
            {
                int userId = Convert.ToInt32(dataGridViewlecturer.SelectedRows[0].Cells["id"].Value);
                var confirm = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes) 
                {
                    LecturerController.DeleteLecturer(userId);
                    LoadLecturers();
                }
            }
            else 
            {
                MessageBox.Show("Please Selecet a lecturer to delete.");
            }
        }
    }
}
