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
    public partial class MarkControl : UserControl
    {
        public MarkControl()
        {
            InitializeComponent();
            LoadMarks();
        }
        private void LoadMarks() 
        {
            dgvMarks.Rows.Clear();
            var marks = MarkController.GetAllMarks();

            foreach (var mark in marks) 
            {
                dgvMarks.Rows.Add(
                   mark.MarkId,
                   mark.StudentName,
                   mark.ExamName,
                   mark.Score,
                   mark.StudentID,
                   mark.ExamId
                );
            }
        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            var form = new AddMarkform();
            form.ShowDialog();
            LoadMarks();
        }

        private void MarkControl_Load(object sender, EventArgs e)
        {
            LoadMarks();

            UserRole parsedRole = (UserRole)Enum.Parse(typeof(UserRole), Roles.Role);
            if (parsedRole == UserRole.Student)
            {
                btnAddMark.Enabled = false;
            }

        }          
    }
}
