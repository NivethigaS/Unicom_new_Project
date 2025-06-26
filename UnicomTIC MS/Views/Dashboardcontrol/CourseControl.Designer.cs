namespace UnicomTIC_MS.Views.Dashboardcontrol
{
    partial class CourseControl
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
            this.lblCourse = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddSubjects = new System.Windows.Forms.Button();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.dgvCourseSubjects = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCourse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 58);
            this.panel1.TabIndex = 0;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Calisto MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.Location = new System.Drawing.Point(44, 14);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(193, 31);
            this.lblCourse.TabIndex = 5;
            this.lblCourse.Text = "Course Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddSubjects);
            this.panel2.Controls.Add(this.cmbCourse);
            this.panel2.Controls.Add(this.txtSubjectName);
            this.panel2.Controls.Add(this.txtDuration);
            this.panel2.Controls.Add(this.txtCourseName);
            this.panel2.Controls.Add(this.btnAddCourse);
            this.panel2.Controls.Add(this.lblCourseName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblDuration);
            this.panel2.Controls.Add(this.lblSubjectName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 158);
            this.panel2.TabIndex = 1;
            // 
            // btnAddSubjects
            // 
            this.btnAddSubjects.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubjects.Location = new System.Drawing.Point(556, 113);
            this.btnAddSubjects.Name = "btnAddSubjects";
            this.btnAddSubjects.Size = new System.Drawing.Size(113, 23);
            this.btnAddSubjects.TabIndex = 10;
            this.btnAddSubjects.Text = "ADD SUBJECT";
            this.btnAddSubjects.UseVisualStyleBackColor = true;
            this.btnAddSubjects.Click += new System.EventHandler(this.btnAddSubjects_Click);
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(329, 116);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(141, 21);
            this.cmbCourse.TabIndex = 9;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(91, 116);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(146, 20);
            this.txtSubjectName.TabIndex = 8;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(329, 45);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(141, 20);
            this.txtDuration.TabIndex = 7;
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(91, 45);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(146, 20);
            this.txtCourseName.TabIndex = 6;
            this.txtCourseName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCourse.Location = new System.Drawing.Point(556, 43);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(113, 23);
            this.btnAddCourse.TabIndex = 5;
            this.btnAddCourse.Text = "ADD COURSE";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(88, 15);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(94, 19);
            this.lblCourseName.TabIndex = 0;
            this.lblCourseName.Text = "Course Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(335, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Course";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(335, 15);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(61, 19);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Duration";
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectName.Location = new System.Drawing.Point(88, 90);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(96, 19);
            this.lblSubjectName.TabIndex = 4;
            this.lblSubjectName.Text = "Subject Name";
            // 
            // dgvCourseSubjects
            // 
            this.dgvCourseSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourseSubjects.Location = new System.Drawing.Point(36, 234);
            this.dgvCourseSubjects.Name = "dgvCourseSubjects";
            this.dgvCourseSubjects.Size = new System.Drawing.Size(734, 312);
            this.dgvCourseSubjects.TabIndex = 2;
            // 
            // CourseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCourseSubjects);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CourseControl";
            this.Size = new System.Drawing.Size(856, 549);
            this.Load += new System.EventHandler(this.CourseControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourseSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCourseSubjects;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblSubjectName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Button btnAddSubjects;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.TextBox txtSubjectName;
    }
}
