namespace MS.UI
{
    partial class FrmUpdateDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdateDepartment));
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_Remarks = new System.Windows.Forms.RichTextBox();
            this.txt_DepartmentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DepartmentNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Exit = new System.Windows.Forms.ToolStripButton();
            this.ep_Reminder = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(47, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "备注：";
            // 
            // rtb_Remarks
            // 
            this.rtb_Remarks.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_Remarks.Location = new System.Drawing.Point(94, 90);
            this.rtb_Remarks.Name = "rtb_Remarks";
            this.rtb_Remarks.Size = new System.Drawing.Size(240, 120);
            this.rtb_Remarks.TabIndex = 55;
            this.rtb_Remarks.Text = "";
            // 
            // txt_DepartmentName
            // 
            this.txt_DepartmentName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_DepartmentName.Location = new System.Drawing.Point(94, 61);
            this.txt_DepartmentName.Name = "txt_DepartmentName";
            this.txt_DepartmentName.Size = new System.Drawing.Size(240, 23);
            this.txt_DepartmentName.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "部门名称：";
            // 
            // txt_DepartmentNo
            // 
            this.txt_DepartmentNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_DepartmentNo.Location = new System.Drawing.Point(94, 32);
            this.txt_DepartmentNo.Name = "txt_DepartmentNo";
            this.txt_DepartmentNo.Size = new System.Drawing.Size(240, 23);
            this.txt_DepartmentNo.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 51;
            this.label4.Text = "部门编号：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Save,
            this.toolStripSeparator1,
            this.tsbtn_Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(369, 25);
            this.toolStrip1.TabIndex = 59;
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
            // FrmUpdateDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 226);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtb_Remarks);
            this.Controls.Add(this.txt_DepartmentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_DepartmentNo);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUpdateDepartment";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_Remarks;
        private System.Windows.Forms.TextBox txt_DepartmentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DepartmentNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtn_Exit;
        private System.Windows.Forms.ErrorProvider ep_Reminder;
    }
}