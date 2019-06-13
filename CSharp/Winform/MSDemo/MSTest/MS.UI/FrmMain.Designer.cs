namespace MS.UI
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.btn_DepartmentQuery = new System.Windows.Forms.Button();
            this.btn_EmployeeQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Location = new System.Drawing.Point(119, 12);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(748, 431);
            this.tc_Main.TabIndex = 0;
            this.tc_Main.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tc_Main_DrawItem);
            this.tc_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tc_Main_MouseDown);
            // 
            // btn_DepartmentQuery
            // 
            this.btn_DepartmentQuery.Location = new System.Drawing.Point(12, 43);
            this.btn_DepartmentQuery.Name = "btn_DepartmentQuery";
            this.btn_DepartmentQuery.Size = new System.Drawing.Size(101, 42);
            this.btn_DepartmentQuery.TabIndex = 1;
            this.btn_DepartmentQuery.Text = "部门管理";
            this.btn_DepartmentQuery.UseVisualStyleBackColor = true;
            this.btn_DepartmentQuery.Click += new System.EventHandler(this.btn_DepartmentQuery_Click);
            // 
            // btn_EmployeeQuery
            // 
            this.btn_EmployeeQuery.Location = new System.Drawing.Point(12, 91);
            this.btn_EmployeeQuery.Name = "btn_EmployeeQuery";
            this.btn_EmployeeQuery.Size = new System.Drawing.Size(101, 42);
            this.btn_EmployeeQuery.TabIndex = 2;
            this.btn_EmployeeQuery.Text = "员工管理";
            this.btn_EmployeeQuery.UseVisualStyleBackColor = true;
            this.btn_EmployeeQuery.Click += new System.EventHandler(this.btn_EmployeeQuery_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 457);
            this.Controls.Add(this.btn_EmployeeQuery);
            this.Controls.Add(this.btn_DepartmentQuery);
            this.Controls.Add(this.tc_Main);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(895, 495);
            this.MinimumSize = new System.Drawing.Size(895, 495);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.Button btn_DepartmentQuery;
        private System.Windows.Forms.Button btn_EmployeeQuery;
    }
}

