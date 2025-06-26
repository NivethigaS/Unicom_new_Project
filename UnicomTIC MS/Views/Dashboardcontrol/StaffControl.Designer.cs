namespace UnicomTIC_MS.Views.Dashboardcontrol
{
    partial class StaffControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvstaff = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddstaff = new System.Windows.Forms.Button();
            this.btnUpdatestaff = new System.Windows.Forms.Button();
            this.btnDeletestaff = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDeletestaff);
            this.panel3.Controls.Add(this.btnUpdatestaff);
            this.panel3.Controls.Add(this.btnAddstaff);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(731, 52);
            this.panel3.TabIndex = 1;
            // 
            // dgvstaff
            // 
            this.dgvstaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvstaff.Location = new System.Drawing.Point(0, 102);
            this.dgvstaff.Name = "dgvstaff";
            this.dgvstaff.Size = new System.Drawing.Size(731, 434);
            this.dgvstaff.TabIndex = 2;
            this.dgvstaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Staff Information";
            // 
            // btnAddstaff
            // 
            this.btnAddstaff.Location = new System.Drawing.Point(70, 23);
            this.btnAddstaff.Name = "btnAddstaff";
            this.btnAddstaff.Size = new System.Drawing.Size(75, 23);
            this.btnAddstaff.TabIndex = 0;
            this.btnAddstaff.Text = "ADD";
            this.btnAddstaff.UseVisualStyleBackColor = true;
            this.btnAddstaff.Click += new System.EventHandler(this.btnAddstaff_Click);
            // 
            // btnUpdatestaff
            // 
            this.btnUpdatestaff.Location = new System.Drawing.Point(250, 23);
            this.btnUpdatestaff.Name = "btnUpdatestaff";
            this.btnUpdatestaff.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatestaff.TabIndex = 1;
            this.btnUpdatestaff.Text = "UPDATE";
            this.btnUpdatestaff.UseVisualStyleBackColor = true;
            this.btnUpdatestaff.Click += new System.EventHandler(this.btnUpdatestaff_Click);
            // 
            // btnDeletestaff
            // 
            this.btnDeletestaff.Location = new System.Drawing.Point(409, 26);
            this.btnDeletestaff.Name = "btnDeletestaff";
            this.btnDeletestaff.Size = new System.Drawing.Size(75, 23);
            this.btnDeletestaff.TabIndex = 2;
            this.btnDeletestaff.Text = "DELETE";
            this.btnDeletestaff.UseVisualStyleBackColor = true;
            this.btnDeletestaff.Click += new System.EventHandler(this.btnDeletestaff_Click);
            // 
            // StaffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvstaff);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "StaffControl";
            this.Size = new System.Drawing.Size(731, 536);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeletestaff;
        private System.Windows.Forms.Button btnUpdatestaff;
        private System.Windows.Forms.Button btnAddstaff;
        private System.Windows.Forms.DataGridView dgvstaff;
    }
}
