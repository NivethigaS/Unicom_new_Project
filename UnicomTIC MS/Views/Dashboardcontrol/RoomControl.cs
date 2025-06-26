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
    public partial class RoomControl : UserControl
    {
        private int selectedId = -1;
        public RoomControl()
        {
            InitializeComponent();
            cmbRoomType.Items.AddRange(new string[] { "Classroom", "Laboratory", "Conference Room", "Auditorium" });
            cmbRoomType.SelectedIndex = 0;
            LoadRoomGrid();
        }
        private void LoadRoomGrid()
        {
            dgvRoom.DataSource = RoomController.GetAllRooms();
            dgvRoom.Columns["RoomID"].Visible = false;
            dgvRoom.Columns["RoomName"].HeaderText = "Room Name";
            dgvRoom.Columns["RoomType"].HeaderText = "Room Type";
        }


        private void RoomControl_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Room room = new Room
            {
                RoomName = txtRoomName.Text.Trim(),
                RoomType = cmbRoomType.SelectedItem.ToString()
            };
            RoomController.AddRoom(room);
            LoadRoomGrid();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a room to update.");
                return;
            }
            Room room = new Room
            {
                RoomID = selectedId,
                RoomName = txtRoomName.Text.Trim(),
                RoomType = cmbRoomType.SelectedItem.ToString()
            };
            RoomController.UpdateRoom(room);
            LoadRoomGrid();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a room to delete.");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RoomController.DeleteRoom(selectedId);
                LoadRoomGrid();
                ClearForm();
            }
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRoom.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["RoomID"].Value);
                txtRoomName.Text = row.Cells["RoomName"].Value.ToString();
                cmbRoomType.SelectedItem = row.Cells["RoomType"].Value.ToString();
            }
        }
        private void ClearForm()
        {
            selectedId = -1;
            txtRoomName.Clear();
            cmbRoomType.SelectedIndex = 0;
        }
    }
}
