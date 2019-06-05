namespace MSTest
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
            this.cbo_DepartmentName = new System.Windows.Forms.ComboBox();
            this.rtb_Remarks = new System.Windows.Forms.RichTextBox();
            this.dtp_birth = new System.Windows.Forms.DateTimePicker();
            this.cbo_Sex = new System.Windows.Forms.ComboBox();
            this.cbo_IsJob = new System.Windows.Forms.ComboBox();
            this.txt_EmployeeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_EmployeeNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Confim = new System.Windows.Forms.Button();
            this.ep_Remind = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep_Remind)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo_DepartmentName
            // 
            this.cbo_DepartmentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_DepartmentName.FormattingEnabled = true;
            this.cbo_DepartmentName.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbo_DepartmentName.Location = new System.Drawing.Point(104, 58);
            this.cbo_DepartmentName.Name = "cbo_DepartmentName";
            this.cbo_DepartmentName.Size = new System.Drawing.Size(100, 20);
            this.cbo_DepartmentName.TabIndex = 48;
            // 
            // rtb_Remarks
            // 
            this.rtb_Remarks.Location = new System.Drawing.Point(35, 154);
            this.rtb_Remarks.Name = "rtb_Remarks";
            this.rtb_Remarks.Size = new System.Drawing.Size(392, 126);
            this.rtb_Remarks.TabIndex = 47;
            this.rtb_Remarks.Text = "";
            // 
            // dtp_birth
            // 
            this.dtp_birth.Location = new System.Drawing.Point(304, 57);
            this.dtp_birth.Name = "dtp_birth";
            this.dtp_birth.Size = new System.Drawing.Size(123, 21);
            this.dtp_birth.TabIndex = 46;
            // 
            // cbo_Sex
            // 
            this.cbo_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Sex.FormattingEnabled = true;
            this.cbo_Sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbo_Sex.Location = new System.Drawing.Point(235, 93);
            this.cbo_Sex.Name = "cbo_Sex";
            this.cbo_Sex.Size = new System.Drawing.Size(50, 20);
            this.cbo_Sex.TabIndex = 45;
            // 
            // cbo_IsJob
            // 
            this.cbo_IsJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_IsJob.FormattingEnabled = true;
            this.cbo_IsJob.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbo_IsJob.Location = new System.Drawing.Point(104, 93);
            this.cbo_IsJob.Name = "cbo_IsJob";
            this.cbo_IsJob.Size = new System.Drawing.Size(52, 20);
            this.cbo_IsJob.TabIndex = 44;
            // 
            // txt_EmployeeName
            // 
            this.txt_EmployeeName.Location = new System.Drawing.Point(304, 23);
            this.txt_EmployeeName.Name = "txt_EmployeeName";
            this.txt_EmployeeName.Size = new System.Drawing.Size(123, 21);
            this.txt_EmployeeName.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "备注：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 41;
            this.label7.Text = "是否在职：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "出生日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "\'";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "部门名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "员工姓名：";
            // 
            // txt_EmployeeNo
            // 
            this.txt_EmployeeNo.Location = new System.Drawing.Point(104, 23);
            this.txt_EmployeeNo.Name = "txt_EmployeeNo";
            this.txt_EmployeeNo.Size = new System.Drawing.Size(100, 21);
            this.txt_EmployeeNo.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "员工编码：";
            // 
            // btn_Confim
            // 
            this.btn_Confim.Location = new System.Drawing.Point(321, 91);
            this.btn_Confim.Name = "btn_Confim";
            this.btn_Confim.Size = new System.Drawing.Size(106, 36);
            this.btn_Confim.TabIndex = 33;
            this.btn_Confim.Text = "确认";
            this.btn_Confim.UseVisualStyleBackColor = true;
            // 
            // ep_Remind
            // 
            this.ep_Remind.ContainerControl = this;
            // 
            // FrmUpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 302);
            this.Controls.Add(this.cbo_DepartmentName);
            this.Controls.Add(this.rtb_Remarks);
            this.Controls.Add(this.dtp_birth);
            this.Controls.Add(this.cbo_Sex);
            this.Controls.Add(this.cbo_IsJob);
            this.Controls.Add(this.txt_EmployeeName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_EmployeeNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Confim);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 340);
            this.Name = "FrmUpdateEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUpdateEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.ep_Remind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_DepartmentName;
        private System.Windows.Forms.RichTextBox rtb_Remarks;
        private System.Windows.Forms.DateTimePicker dtp_birth;
        private System.Windows.Forms.ComboBox cbo_Sex;
        private System.Windows.Forms.ComboBox cbo_IsJob;
        private System.Windows.Forms.TextBox txt_EmployeeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_EmployeeNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Confim;
        private System.Windows.Forms.ErrorProvider ep_Remind;
    }
}