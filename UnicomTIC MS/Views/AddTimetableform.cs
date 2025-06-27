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
    public partial class AddTimetableform : Form
    {
        private int selectedId = -1;
        public AddTimetableform()
        {
            InitializeComponent();
            LoadComboData(); ;
            LoadTimetables();
        }
        private void LoadComboData() 
        {
            cmbSubject.DataSource = SubjectController.GetAllSubjects();
            cmbSubject.DisplayMember = "SujectName";
            cmbSubject.ValueMember = "SubjectID";

            cmbRoom.DataSource = RoomController.GetAllRooms();
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";
        }
        private void LoadTimetables() 
        {
            dgvTimetable.DataSource = TimetableController.GetAllTimetables();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Timetable t = new Timetable
            {
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue),
                TimeSlot = txtTimeSlot.Text.Trim(),
                RoomID = Convert.ToInt32(cmbRoom.SelectedValue)
            };

            TimetableController.AddTimetable(t);
            LoadTimetables();
            ClearForm();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) 
            {
                MessageBox.Show("Select a timetable to update.");
                return;
            }
            Timetable timetable = new Timetable
            {
                TimetableID = selectedId,
                SubjectID = Convert.ToInt32((int)cmbSubject.SelectedValue),
                TimeSlot = txtTimeSlot.Text.Trim(),
                RoomID = Convert.ToInt32((int)cmbRoom.SelectedValue)
            };

            TimetableController.UpdateTimetable(timetable); 
            LoadTimetables();
            ClearForm();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId != -1) 
            {
                MessageBox.Show("Select a timetable to delte.");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                TimetableController.DeleteTimetable(selectedId);
                LoadTimetables() ;
                ClearForm();
            }
        }

        private void dgvTimetable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvTimetable.Rows[e.RowIndex];

                selectedId = Convert.ToInt32(row.Cells["TimetableID"].Value );
                txtTimeSlot.Text = row.Cells["TTimeSlot"].Value.ToString();
                cmbSubject.Text = row.Cells["SubjectName"].Value.ToString();
                cmbRoom.Text = row.Cells["RoomName"].Value.ToString();
            }
        }
        private void ClearForm() 
        {
            selectedId = -1;
            txtTimeSlot.Clear();
            cmbSubject.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
