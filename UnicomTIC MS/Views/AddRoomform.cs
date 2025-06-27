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
    public partial class AddRoomform : Form
    {
        public AddRoomform()
        {
            InitializeComponent();
            LoadRooms();
        }
        private void LoadRooms()
        {
            dgvRooms.Rows.Clear();
            var rooms = RoomController.GetAllRooms();
            foreach (var room in rooms)
            {
                dgvRooms.Rows.Add(room.RoomID, room.RoomName, room.RoomType);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddRoomform_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRoomName.Text == "" || txtRoomType.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }
            Room room = new Room
            {
                RoomName = txtRoomName.Text,
                RoomType = txtRoomType.Text
            };
            RoomController.AddRoom(room);
            MessageBox.Show("Room added!");
            ClearForm();
            LoadRooms();

        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtRoomName.Text = dgvRooms.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomType.Text = dgvRooms.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRoomName.Tag = dgvRooms.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRoomName.Tag == null)
            {
                MessageBox.Show("Select a room to update.");
                return;
            }
            Room room = new Room
            {
                RoomID = Convert.ToInt32(txtRoomName.Tag),
                RoomName = txtRoomName.Text,
                RoomType = txtRoomType.Text
            };
            RoomController.UpdateRoom(room);
            MessageBox.Show("Room updated!");
            ClearForm();
            LoadRooms();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRoomName.Tag == null)
            {
                MessageBox.Show("Select a room to delete.");
                return;
            }
            int roomId = Convert.ToInt32(txtRoomName.Tag);
            DialogResult result = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                RoomController.DeleteRoom(roomId);
                MessageBox.Show("Room deleted!");
                ClearForm();
                LoadRooms();
            }
        }
        private void ClearForm()
        {
            txtRoomName.Clear();
            txtRoomType.Clear();
            txtRoomName.Tag = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
