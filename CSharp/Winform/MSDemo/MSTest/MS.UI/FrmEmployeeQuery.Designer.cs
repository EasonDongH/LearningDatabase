namespace MS.UI
{
    partial class FrmEmployeeQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_EmployeeInfo = new System.Windows.Forms.DataGridView();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_EmployeeQueryMode = new System.Windows.Forms.ComboBox();
            this.txt_QueryCondition = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_AddEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_ModifyEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_DeleteEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_QueryEmployee = new System.Windows.Forms.ToolStripButton();
            this.ep_Reminder = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_EmployeeInfo
            // 
            this.dgv_EmployeeInfo.AllowUserToAddRows = false;
            this.dgv_EmployeeInfo.AllowUserToDeleteRows = false;
            this.dgv_EmployeeInfo.AllowUserToResizeColumns = false;
            this.dgv_EmployeeInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_EmployeeInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_EmployeeInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EmployeeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_EmployeeInfo.ColumnHeadersHeight = 35;
            this.dgv_EmployeeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_EmployeeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Department,
            this.EmployeeNo,
            this.EmployeeName,
            this.EmployeeSex,
            this.EmployeeBirth,
            this.IsJob,
            this.Remarks});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_EmployeeInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_EmployeeInfo.Location = new System.Drawing.Point(15, 65);
            this.dgv_EmployeeInfo.MultiSelect = false;
            this.dgv_EmployeeInfo.Name = "dgv_EmployeeInfo";
            this.dgv_EmployeeInfo.ReadOnly = true;
            this.dgv_EmployeeInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_EmployeeInfo.RowTemplate.Height = 23;
            this.dgv_EmployeeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeInfo.Size = new System.Drawing.Size(700, 305);
            this.dgv_EmployeeInfo.TabIndex = 23;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "DepartmentName";
            this.Department.HeaderText = "部门名称";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EmployeeNo
            // 
            this.EmployeeNo.DataPropertyName = "EmployeeNo";
            this.EmployeeNo.HeaderText = "员工编号";
            this.EmployeeNo.Name = "EmployeeNo";
            this.EmployeeNo.ReadOnly = true;
            this.EmployeeNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmployeeNo.Width = 80;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "员工名称";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            this.EmployeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmployeeName.Width = 80;
            // 
            // EmployeeSex
            // 
            this.EmployeeSex.DataPropertyName = "EmployeeSex";
            this.EmployeeSex.HeaderText = "性别";
            this.EmployeeSex.Name = "EmployeeSex";
            this.EmployeeSex.ReadOnly = true;
            this.EmployeeSex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmployeeSex.Width = 50;
            // 
            // EmployeeBirth
            // 
            this.EmployeeBirth.DataPropertyName = "EmployeeBirth";
            this.EmployeeBirth.HeaderText = "员工生日";
            this.EmployeeBirth.Name = "EmployeeBirth";
            this.EmployeeBirth.ReadOnly = true;
            this.EmployeeBirth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmployeeBirth.Width = 80;
            // 
            // IsJob
            // 
            this.IsJob.DataPropertyName = "IsJob";
            this.IsJob.HeaderText = "是否在职";
            this.IsJob.Name = "IsJob";
            this.IsJob.ReadOnly = true;
            this.IsJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsJob.Width = 80;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "查询方式：";
            // 
            // cbo_EmployeeQueryMode
            // 
            this.cbo_EmployeeQueryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_EmployeeQueryMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_EmployeeQueryMode.FormattingEnabled = true;
            this.cbo_EmployeeQueryMode.Items.AddRange(new object[] {
            "  全部",
            "  按员工编号",
            "  按员工名称"});
            this.cbo_EmployeeQueryMode.Location = new System.Drawing.Point(86, 32);
            this.cbo_EmployeeQueryMode.Name = "cbo_EmployeeQueryMode";
            this.cbo_EmployeeQueryMode.Size = new System.Drawing.Size(91, 25);
            this.cbo_EmployeeQueryMode.TabIndex = 21;
            this.cbo_EmployeeQueryMode.SelectedIndexChanged += new System.EventHandler(this.cbo_EmployeeQueryMode_SelectedIndexChanged);
            // 
            // txt_QueryCondition
            // 
            this.txt_QueryCondition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_QueryCondition.Location = new System.Drawing.Point(183, 32);
            this.txt_QueryCondition.Name = "txt_QueryCondition";
            this.txt_QueryCondition.Size = new System.Drawing.Size(204, 23);
            this.txt_QueryCondition.TabIndex = 18;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_AddEmployee,
            this.toolStripSeparator1,
            this.tsbtn_ModifyEmployee,
            this.toolStripSeparator2,
            this.tsbtn_DeleteEmployee,
            this.toolStripSeparator3,
            this.tsbtn_QueryEmployee});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_AddEmployee
            // 
            this.tsbtn_AddEmployee.Image = global::MS.UI.Properties.Resources.添加;
            this.tsbtn_AddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_AddEmployee.Name = "tsbtn_AddEmployee";
            this.tsbtn_AddEmployee.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_AddEmployee.Text = "添加";
            this.tsbtn_AddEmployee.Click += new System.EventHandler(this.tsbtn_AddEmployee_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_ModifyEmployee
            // 
            this.tsbtn_ModifyEmployee.Image = global::MS.UI.Properties.Resources.修改;
            this.tsbtn_ModifyEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ModifyEmployee.Name = "tsbtn_ModifyEmployee";
            this.tsbtn_ModifyEmployee.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_ModifyEmployee.Text = "修改";
            this.tsbtn_ModifyEmployee.Click += new System.EventHandler(this.tsbtn_ModifyEmployee_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_DeleteEmployee
            // 
            this.tsbtn_DeleteEmployee.Image = global::MS.UI.Properties.Resources.删除;
            this.tsbtn_DeleteEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_DeleteEmployee.Name = "tsbtn_DeleteEmployee";
            this.tsbtn_DeleteEmployee.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_DeleteEmployee.Text = "删除";
            this.tsbtn_DeleteEmployee.Click += new System.EventHandler(this.tsbtn_DeleteEmployee_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_QueryEmployee
            // 
            this.tsbtn_QueryEmployee.Image = global::MS.UI.Properties.Resources.查询;
            this.tsbtn_QueryEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_QueryEmployee.Name = "tsbtn_QueryEmployee";
            this.tsbtn_QueryEmployee.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_QueryEmployee.Text = "查询";
            this.tsbtn_QueryEmployee.Click += new System.EventHandler(this.tsbtn_QueryEmployee_Click);
            // 
            // ep_Reminder
            // 
            this.ep_Reminder.ContainerControl = this;
            // 
            // FrmEmployeeQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 380);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgv_EmployeeInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_EmployeeQueryMode);
            this.Controls.Add(this.txt_QueryCondition);
            this.Name = "FrmEmployeeQuery";
            this.Text = "FrmEmployeeQuery";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_EmployeeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_EmployeeQueryMode;
        private System.Windows.Forms.TextBox txt_QueryCondition;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtn_ModifyEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtn_DeleteEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtn_QueryEmployee;
        private System.Windows.Forms.ErrorProvider ep_Reminder;
        private System.Windows.Forms.ToolStripButton tsbtn_AddEmployee;
    }
}