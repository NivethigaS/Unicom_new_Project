namespace UnicomTIC_MS.Views
{
    partial class addstudentform
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblstudentcreate = new System.Windows.Forms.Label();
            this.lbldob = new System.Windows.Forms.Label();
            this.lblstudentnumber = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            this.lblfirstname = new System.Windows.Forms.Label();
            this.lbllastname = new System.Windows.Forms.Label();
            this.lblcourse = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.btnsavestudent = new System.Windows.Forms.Button();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.txtcourse = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.dtpdateofbirth = new System.Windows.Forms.DateTimePicker();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtstudentnumber = new System.Windows.Forms.TextBox();
            this.cmbgender = new System.Windows.Forms.ComboBox();
            this.btnx1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblstudentcreate
            // 
            this.lblstudentcreate.AutoSize = true;
            this.lblstudentcreate.Font = new System.Drawing.Font("Calisto MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstudentcreate.Location = new System.Drawing.Point(37, 42);
            this.lblstudentcreate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstudentcreate.Name = "lblstudentcreate";
            this.lblstudentcreate.Size = new System.Drawing.Size(344, 41);
            this.lblstudentcreate.TabIndex = 0;
            this.lblstudentcreate.Text = "Create New Student";
            // 
            // lbldob
            // 
            this.lbldob.AutoSize = true;
            this.lbldob.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldob.Location = new System.Drawing.Point(709, 218);
            this.lbldob.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldob.Name = "lbldob";
            this.lbldob.Size = new System.Drawing.Size(117, 22);
            this.lbldob.TabIndex = 1;
            this.lbldob.Text = "Date Of Birth";
            // 
            // lblstudentnumber
            // 
            this.lblstudentnumber.AutoSize = true;
            this.lblstudentnumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstudentnumber.Location = new System.Drawing.Point(520, 313);
            this.lblstudentnumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstudentnumber.Name = "lblstudentnumber";
            this.lblstudentnumber.Size = new System.Drawing.Size(136, 22);
            this.lblstudentnumber.TabIndex = 2;
            this.lblstudentnumber.Text = "Student Number";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.Location = new System.Drawing.Point(40, 313);
            this.lblusername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(93, 22);
            this.lblusername.TabIndex = 3;
            this.lblusername.Text = "UserName";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.Location = new System.Drawing.Point(276, 218);
            this.lblemail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(57, 22);
            this.lblemail.TabIndex = 4;
            this.lblemail.Text = "Email";
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladdress.Location = new System.Drawing.Point(41, 218);
            this.lbladdress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(76, 22);
            this.lbladdress.TabIndex = 5;
            this.lbladdress.Text = "Address";
            this.lbladdress.Click += new System.EventHandler(this.lbladdress_Click);
            // 
            // lblfirstname
            // 
            this.lblfirstname.AutoSize = true;
            this.lblfirstname.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfirstname.Location = new System.Drawing.Point(41, 121);
            this.lblfirstname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfirstname.Name = "lblfirstname";
            this.lblfirstname.Size = new System.Drawing.Size(98, 22);
            this.lblfirstname.TabIndex = 6;
            this.lblfirstname.Text = "First Name";
            // 
            // lbllastname
            // 
            this.lbllastname.AutoSize = true;
            this.lbllastname.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllastname.Location = new System.Drawing.Point(269, 121);
            this.lbllastname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllastname.Name = "lbllastname";
            this.lbllastname.Size = new System.Drawing.Size(94, 22);
            this.lbllastname.TabIndex = 8;
            this.lbllastname.Text = "Last Name";
            // 
            // lblcourse
            // 
            this.lblcourse.AutoSize = true;
            this.lblcourse.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcourse.Location = new System.Drawing.Point(745, 313);
            this.lblcourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcourse.Name = "lblcourse";
            this.lblcourse.Size = new System.Drawing.Size(66, 22);
            this.lblcourse.TabIndex = 9;
            this.lblcourse.Text = "Course";
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpassword.Location = new System.Drawing.Point(275, 313);
            this.lblpassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(88, 22);
            this.lblpassword.TabIndex = 10;
            this.lblpassword.Text = "Password";
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblphone.Location = new System.Drawing.Point(521, 218);
            this.lblphone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(58, 22);
            this.lblphone.TabIndex = 11;
            this.lblphone.Text = "Phone";
            this.lblphone.Click += new System.EventHandler(this.lblphone_Click);
            // 
            // lblgender
            // 
            this.lblgender.AutoSize = true;
            this.lblgender.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgender.Location = new System.Drawing.Point(516, 121);
            this.lblgender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(68, 22);
            this.lblgender.TabIndex = 12;
            this.lblgender.Text = "Gender";
            // 
            // btnsavestudent
            // 
            this.btnsavestudent.BackColor = System.Drawing.Color.Teal;
            this.btnsavestudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsavestudent.Location = new System.Drawing.Point(273, 441);
            this.btnsavestudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsavestudent.Name = "btnsavestudent";
            this.btnsavestudent.Size = new System.Drawing.Size(393, 39);
            this.btnsavestudent.TabIndex = 13;
            this.btnsavestudent.Text = "Save";
            this.btnsavestudent.UseVisualStyleBackColor = false;
            this.btnsavestudent.Click += new System.EventHandler(this.btnsavestudent_Click);
            // 
            // txtfirstname
            // 
            this.txtfirstname.Location = new System.Drawing.Point(41, 153);
            this.txtfirstname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(132, 22);
            this.txtfirstname.TabIndex = 14;
            // 
            // txtlastname
            // 
            this.txtlastname.Location = new System.Drawing.Point(273, 153);
            this.txtlastname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(132, 22);
            this.txtlastname.TabIndex = 15;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(41, 250);
            this.txtaddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(132, 22);
            this.txtaddress.TabIndex = 16;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(273, 250);
            this.txtemail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(132, 22);
            this.txtemail.TabIndex = 17;
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(520, 250);
            this.txtphone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(132, 22);
            this.txtphone.TabIndex = 18;
            // 
            // txtcourse
            // 
            this.txtcourse.Location = new System.Drawing.Point(751, 357);
            this.txtcourse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcourse.Name = "txtcourse";
            this.txtcourse.Size = new System.Drawing.Size(132, 22);
            this.txtcourse.TabIndex = 19;
            this.txtcourse.TextChanged += new System.EventHandler(this.txtcourse_TextChanged);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(41, 357);
            this.txtusername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(132, 22);
            this.txtusername.TabIndex = 20;
            // 
            // dtpdateofbirth
            // 
            this.dtpdateofbirth.Location = new System.Drawing.Point(713, 250);
            this.dtpdateofbirth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpdateofbirth.Name = "dtpdateofbirth";
            this.dtpdateofbirth.Size = new System.Drawing.Size(265, 22);
            this.dtpdateofbirth.TabIndex = 23;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(273, 357);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(132, 22);
            this.txtpassword.TabIndex = 24;
            // 
            // txtstudentnumber
            // 
            this.txtstudentnumber.Location = new System.Drawing.Point(520, 357);
            this.txtstudentnumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtstudentnumber.Name = "txtstudentnumber";
            this.txtstudentnumber.Size = new System.Drawing.Size(132, 22);
            this.txtstudentnumber.TabIndex = 25;
            // 
            // cmbgender
            // 
            this.cmbgender.FormattingEnabled = true;
            this.cmbgender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbgender.Location = new System.Drawing.Point(520, 153);
            this.cmbgender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbgender.Name = "cmbgender";
            this.cmbgender.Size = new System.Drawing.Size(160, 24);
            this.cmbgender.TabIndex = 26;
            // 
            // btnx1
            // 
            this.btnx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnx1.Location = new System.Drawing.Point(1005, 15);
            this.btnx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnx1.Name = "btnx1";
            this.btnx1.Size = new System.Drawing.Size(45, 39);
            this.btnx1.TabIndex = 27;
            this.btnx1.Text = "X";
            this.btnx1.UseVisualStyleBackColor = true;
            this.btnx1.Click += new System.EventHandler(this.btnx1_Click);
            // 
            // addstudentform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnx1);
            this.Controls.Add(this.cmbgender);
            this.Controls.Add(this.txtstudentnumber);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.dtpdateofbirth);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.txtcourse);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.txtfirstname);
            this.Controls.Add(this.btnsavestudent);
            this.Controls.Add(this.lblgender);
            this.Controls.Add(this.lblphone);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.lblcourse);
            this.Controls.Add(this.lbllastname);
            this.Controls.Add(this.lblfirstname);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.lblstudentnumber);
            this.Controls.Add(this.lbldob);
            this.Controls.Add(this.lblstudentcreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "addstudentform";
            this.Text = "AddStudentForm";
            this.Load += new System.EventHandler(this.addstudentform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblstudentcreate;
        private System.Windows.Forms.Label lbldob;
        private System.Windows.Forms.Label lblstudentnumber;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.Label lblfirstname;
        private System.Windows.Forms.Label lbllastname;
        private System.Windows.Forms.Label lblcourse;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label lblgender;
        private System.Windows.Forms.Button btnsavestudent;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.TextBox txtcourse;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.DateTimePicker dtpdateofbirth;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtstudentnumber;
        private System.Windows.Forms.ComboBox cmbgender;
        private System.Windows.Forms.Button btnx1;
    }
}