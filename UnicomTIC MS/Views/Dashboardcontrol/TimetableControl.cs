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
    public partial class TimetableControl : UserControl
    {
        private int selectedId = -1;
        public TimetableControl()
        {
            InitializeComponent();
            LoadComboData();
            LoadTimetables();
        }
        private void LoadComboData() 
        {
            cmbSubject.DataSource = SubjectController.GetAllSubjects();
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";

            cmbRoom.DataSource = RoomController.GetAllRooms();
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";
        }
        private void LoadTimetables() 
        {
            dgvTimeTable.DataSource = TimetableController.GetAllTimetables();
            dgvTimeTable.Columns["TimetableID"].Visible = false;
            dgvTimeTable.Columns["SubjectUID"].Visible = false;
            dgvTimeTable.Columns["RoomUID"].Visible = false;
            dgvTimeTable.Columns["SubjectName"].HeaderText = "Subject";
            dgvTimeTable.Columns["TimeSlot"].HeaderText = "Time Slot";
            dgvTimeTable.Columns["RoomName"].HeaderText = "Room";
            dgvTimeTable.Columns["RoomType"].HeaderText = "Room Type";

        }
        private void ClearForm() 
        {
            selectedId = -1;
            txtTimeSlot.Clear();
            cmbSubject.SelectedIndex = 0;
            cmbRoom.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTimetableform addTimetableForm = new AddTimetableform();
            addTimetableForm.ShowDialog();
            LoadTimetables();

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
            Timetable t = new Timetable
            {
                TimetableID = selectedId,
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue),
                TimeSlot = txtTimeSlot.Text.Trim(),
                RoomID = Convert.ToInt32(cmbRoom.SelectedValue)
            };
            TimetableController.UpdateTimetable(t);
            LoadTimetables();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a timetable to delete.");
                return;
            }
            var confirm = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                TimetableController.DeleteTimetable(selectedId);
                LoadTimetables();
                ClearForm();
            }
        }

        private void dgvTimeTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvTimeTable.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["TimetableID"].Value);
                cmbSubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectUID"].Value);
                txtTimeSlot.Text = row.Cells["TimeSlot"].Value.ToString();
                cmbRoom.SelectedValue = Convert.ToInt32(row.Cells["RoomUID"].Value);
            }
        }
    }
}
