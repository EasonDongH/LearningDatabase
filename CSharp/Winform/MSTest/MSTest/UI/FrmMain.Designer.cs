namespace MSTest
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
            this.btn_DepartmentManage = new System.Windows.Forms.Button();
            this.btn_EmployeeManage = new System.Windows.Forms.Button();
            this.gb_OperationPanel = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btn_DepartmentManage
            // 
            this.btn_DepartmentManage.Location = new System.Drawing.Point(12, 26);
            this.btn_DepartmentManage.Name = "btn_DepartmentManage";
            this.btn_DepartmentManage.Size = new System.Drawing.Size(105, 36);
            this.btn_DepartmentManage.TabIndex = 0;
            this.btn_DepartmentManage.Text = "部门管理";
            this.btn_DepartmentManage.UseVisualStyleBackColor = true;
            this.btn_DepartmentManage.Click += new System.EventHandler(this.btn_DepartmentManage_Click);
            // 
            // btn_EmployeeManage
            // 
            this.btn_EmployeeManage.Location = new System.Drawing.Point(12, 68);
            this.btn_EmployeeManage.Name = "btn_EmployeeManage";
            this.btn_EmployeeManage.Size = new System.Drawing.Size(105, 36);
            this.btn_EmployeeManage.TabIndex = 1;
            this.btn_EmployeeManage.Text = "员工管理";
            this.btn_EmployeeManage.UseVisualStyleBackColor = true;
            this.btn_EmployeeManage.Click += new System.EventHandler(this.btn_EmployeeManage_Click);
            // 
            // gb_OperationPanel
            // 
            this.gb_OperationPanel.Location = new System.Drawing.Point(133, 26);
            this.gb_OperationPanel.Name = "gb_OperationPanel";
            this.gb_OperationPanel.Size = new System.Drawing.Size(751, 410);
            this.gb_OperationPanel.TabIndex = 2;
            this.gb_OperationPanel.TabStop = false;
            this.gb_OperationPanel.Text = "操作界面";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 474);
            this.Controls.Add(this.gb_OperationPanel);
            this.Controls.Add(this.btn_EmployeeManage);
            this.Controls.Add(this.btn_DepartmentManage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(646, 483);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_DepartmentManage;
        private System.Windows.Forms.Button btn_EmployeeManage;
        private System.Windows.Forms.GroupBox gb_OperationPanel;
    }
}

