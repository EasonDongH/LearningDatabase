namespace MSTest
{
    partial class FrmEmployeeManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_EmployeeInfo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_EmployeeQueryMode = new System.Windows.Forms.ComboBox();
            this.btn_ModifyEmployeeInfo = new System.Windows.Forms.Button();
            this.btn_QueryEmployeeInfo = new System.Windows.Forms.Button();
            this.txt_QueryCondition = new System.Windows.Forms.TextBox();
            this.btn_DeleteEmployee = new System.Windows.Forms.Button();
            this.btn_AddEmployee = new System.Windows.Forms.Button();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeInfo)).BeginInit();
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
            this.dgv_EmployeeInfo.Location = new System.Drawing.Point(19, 59);
            this.dgv_EmployeeInfo.Name = "dgv_EmployeeInfo";
            this.dgv_EmployeeInfo.ReadOnly = true;
            this.dgv_EmployeeInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_EmployeeInfo.RowTemplate.Height = 23;
            this.dgv_EmployeeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeInfo.Size = new System.Drawing.Size(699, 304);
            this.dgv_EmployeeInfo.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "查询方式：";
            // 
            // cbo_EmployeeQueryMode
            // 
            this.cbo_EmployeeQueryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_EmployeeQueryMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_EmployeeQueryMode.FormattingEnabled = true;
            this.cbo_EmployeeQueryMode.Items.AddRange(new object[] {
            " 按员工编号",
            " 按员工名称"});
            this.cbo_EmployeeQueryMode.Location = new System.Drawing.Point(92, 15);
            this.cbo_EmployeeQueryMode.Name = "cbo_EmployeeQueryMode";
            this.cbo_EmployeeQueryMode.Size = new System.Drawing.Size(91, 25);
            this.cbo_EmployeeQueryMode.TabIndex = 13;
            // 
            // btn_ModifyEmployeeInfo
            // 
            this.btn_ModifyEmployeeInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModifyEmployeeInfo.Location = new System.Drawing.Point(511, 14);
            this.btn_ModifyEmployeeInfo.Name = "btn_ModifyEmployeeInfo";
            this.btn_ModifyEmployeeInfo.Size = new System.Drawing.Size(100, 26);
            this.btn_ModifyEmployeeInfo.TabIndex = 12;
            this.btn_ModifyEmployeeInfo.Text = "修改员工信息";
            this.btn_ModifyEmployeeInfo.UseVisualStyleBackColor = true;
            this.btn_ModifyEmployeeInfo.Click += new System.EventHandler(this.btn_ModifyEmployeeInfo_Click);
            // 
            // btn_QueryEmployeeInfo
            // 
            this.btn_QueryEmployeeInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_QueryEmployeeInfo.Location = new System.Drawing.Point(297, 14);
            this.btn_QueryEmployeeInfo.Name = "btn_QueryEmployeeInfo";
            this.btn_QueryEmployeeInfo.Size = new System.Drawing.Size(100, 26);
            this.btn_QueryEmployeeInfo.TabIndex = 11;
            this.btn_QueryEmployeeInfo.Text = "查询员工信息";
            this.btn_QueryEmployeeInfo.UseVisualStyleBackColor = true;
            this.btn_QueryEmployeeInfo.Click += new System.EventHandler(this.btn_QueryEmployeeInfo_Click);
            // 
            // txt_QueryCondition
            // 
            this.txt_QueryCondition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_QueryCondition.Location = new System.Drawing.Point(190, 16);
            this.txt_QueryCondition.Name = "txt_QueryCondition";
            this.txt_QueryCondition.Size = new System.Drawing.Size(100, 23);
            this.txt_QueryCondition.TabIndex = 10;
            // 
            // btn_DeleteEmployee
            // 
            this.btn_DeleteEmployee.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteEmployee.Location = new System.Drawing.Point(618, 14);
            this.btn_DeleteEmployee.Name = "btn_DeleteEmployee";
            this.btn_DeleteEmployee.Size = new System.Drawing.Size(100, 26);
            this.btn_DeleteEmployee.TabIndex = 9;
            this.btn_DeleteEmployee.Text = "删除员工";
            this.btn_DeleteEmployee.UseVisualStyleBackColor = true;
            this.btn_DeleteEmployee.Click += new System.EventHandler(this.btn_DeleteEmployee_Click);
            // 
            // btn_AddEmployee
            // 
            this.btn_AddEmployee.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddEmployee.Location = new System.Drawing.Point(404, 13);
            this.btn_AddEmployee.Name = "btn_AddEmployee";
            this.btn_AddEmployee.Size = new System.Drawing.Size(100, 26);
            this.btn_AddEmployee.TabIndex = 8;
            this.btn_AddEmployee.Text = "添加员工";
            this.btn_AddEmployee.UseVisualStyleBackColor = true;
            this.btn_AddEmployee.Click += new System.EventHandler(this.btn_AddEmployee_Click);
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
            // FrmEmployeeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 387);
            this.Controls.Add(this.dgv_EmployeeInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_EmployeeQueryMode);
            this.Controls.Add(this.btn_ModifyEmployeeInfo);
            this.Controls.Add(this.btn_QueryEmployeeInfo);
            this.Controls.Add(this.txt_QueryCondition);
            this.Controls.Add(this.btn_DeleteEmployee);
            this.Controls.Add(this.btn_AddEmployee);
            this.Name = "FrmEmployeeManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_EmployeeInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_EmployeeQueryMode;
        private System.Windows.Forms.Button btn_ModifyEmployeeInfo;
        private System.Windows.Forms.Button btn_QueryEmployeeInfo;
        private System.Windows.Forms.TextBox txt_QueryCondition;
        private System.Windows.Forms.Button btn_DeleteEmployee;
        private System.Windows.Forms.Button btn_AddEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}