namespace MS.UI
{
    partial class FrmUpdateEmployee
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdateEmployee));
            this.cbo_DepartmentName = new System.Windows.Forms.ComboBox();
            this.rtb_Remarks = new System.Windows.Forms.RichTextBox();
            this.dtp_Birth = new System.Windows.Forms.DateTimePicker();
            this.txt_EmployeeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_EmployeeNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_InJob = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Exit = new System.Windows.Forms.ToolStripButton();
            this.ep_Reminder = new System.Windows.Forms.ErrorProvider(this.components);
            this.rb_Male = new System.Windows.Forms.RadioButton();
            this.rb_Female = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo_DepartmentName
            // 
            this.cbo_DepartmentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_DepartmentName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_DepartmentName.FormattingEnabled = true;
            this.cbo_DepartmentName.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbo_DepartmentName.Location = new System.Drawing.Point(93, 67);
            this.cbo_DepartmentName.Name = "cbo_DepartmentName";
            this.cbo_DepartmentName.Size = new System.Drawing.Size(105, 25);
            this.cbo_DepartmentName.TabIndex = 64;
            // 
            // rtb_Remarks
            // 
            this.rtb_Remarks.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_Remarks.Location = new System.Drawing.Point(93, 137);
            this.rtb_Remarks.Name = "rtb_Remarks";
            this.rtb_Remarks.Size = new System.Drawing.Size(306, 133);
            this.rtb_Remarks.TabIndex = 63;
            this.rtb_Remarks.Text = "";
            // 
            // dtp_Birth
            // 
            this.dtp_Birth.CustomFormat = "yyyy-MM-dd";
            this.dtp_Birth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_Birth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Birth.Location = new System.Drawing.Point(293, 66);
            this.dtp_Birth.Name = "dtp_Birth";
            this.dtp_Birth.Size = new System.Drawing.Size(105, 23);
            this.dtp_Birth.TabIndex = 62;
            // 
            // txt_EmployeeName
            // 
            this.txt_EmployeeName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_EmployeeName.Location = new System.Drawing.Point(293, 32);
            this.txt_EmployeeName.Name = "txt_EmployeeName";
            this.txt_EmployeeName.Size = new System.Drawing.Size(105, 23);
            this.txt_EmployeeName.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(46, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 58;
            this.label8.Text = "备注：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(222, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "出生日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(246, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(22, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 53;
            this.label3.Text = "部门名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(222, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 52;
            this.label2.Text = "员工姓名：";
            // 
            // txt_EmployeeNo
            // 
            this.txt_EmployeeNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_EmployeeNo.Location = new System.Drawing.Point(93, 32);
            this.txt_EmployeeNo.Name = "txt_EmployeeNo";
            this.txt_EmployeeNo.Size = new System.Drawing.Size(105, 23);
            this.txt_EmployeeNo.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "员工编码：";
            // 
            // cb_InJob
            // 
            this.cb_InJob.AutoSize = true;
            this.cb_InJob.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_InJob.Location = new System.Drawing.Point(93, 102);
            this.cb_InJob.Name = "cb_InJob";
            this.cb_InJob.Size = new System.Drawing.Size(75, 21);
            this.cb_InJob.TabIndex = 65;
            this.cb_InJob.Text = "是否在职";
            this.cb_InJob.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Save,
            this.toolStripSeparator1,
            this.tsbtn_Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(444, 25);
            this.toolStrip1.TabIndex = 69;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_Save
            // 
            this.tsbtn_Save.Image = global::MS.UI.Properties.Resources.保存;
            this.tsbtn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Save.Name = "tsbtn_Save";
            this.tsbtn_Save.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_Save.Text = "保存";
            this.tsbtn_Save.Click += new System.EventHandler(this.tsbtn_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_Exit
            // 
            this.tsbtn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Exit.Image")));
            this.tsbtn_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Exit.Name = "tsbtn_Exit";
            this.tsbtn_Exit.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_Exit.Text = "退出";
            this.tsbtn_Exit.Click += new System.EventHandler(this.tsbtn_Exit_Click);
            // 
            // ep_Reminder
            // 
            this.ep_Reminder.ContainerControl = this;
            // 
            // rb_Male
            // 
            this.rb_Male.AutoSize = true;
            this.rb_Male.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Male.Location = new System.Drawing.Point(293, 101);
            this.rb_Male.Name = "rb_Male";
            this.rb_Male.Size = new System.Drawing.Size(38, 21);
            this.rb_Male.TabIndex = 70;
            this.rb_Male.TabStop = true;
            this.rb_Male.Text = "男";
            this.rb_Male.UseVisualStyleBackColor = true;
            // 
            // rb_Female
            // 
            this.rb_Female.AutoSize = true;
            this.rb_Female.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Female.Location = new System.Drawing.Point(337, 101);
            this.rb_Female.Name = "rb_Female";
            this.rb_Female.Size = new System.Drawing.Size(38, 21);
            this.rb_Female.TabIndex = 71;
            this.rb_Female.TabStop = true;
            this.rb_Female.Text = "女";
            this.rb_Female.UseVisualStyleBackColor = true;
            // 
            // FrmUpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 282);
            this.Controls.Add(this.rb_Female);
            this.Controls.Add(this.rb_Male);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cb_InJob);
            this.Controls.Add(this.cbo_DepartmentName);
            this.Controls.Add(this.rtb_Remarks);
            this.Controls.Add(this.dtp_Birth);
            this.Controls.Add(this.txt_EmployeeName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_EmployeeNo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUpdateEmployee";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_DepartmentName;
        private System.Windows.Forms.RichTextBox rtb_Remarks;
        private System.Windows.Forms.DateTimePicker dtp_Birth;
        private System.Windows.Forms.TextBox txt_EmployeeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_EmployeeNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_InJob;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtn_Exit;
        private System.Windows.Forms.ErrorProvider ep_Reminder;
        private System.Windows.Forms.RadioButton rb_Female;
        private System.Windows.Forms.RadioButton rb_Male;
    }
}