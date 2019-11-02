namespace MS.UI
{
    partial class FrmDepartmentQuery
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
            this.dgv_DepartmentInfo = new System.Windows.Forms.DataGridView();
            this.DepartmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_DepartmentQueryMode = new System.Windows.Forms.ComboBox();
            this.txt_QueryCondition = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_AddDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_ModifyDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_DeleteDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_QueryDepartment = new System.Windows.Forms.ToolStripButton();
            this.ep_Reminder = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DepartmentInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DepartmentInfo
            // 
            this.dgv_DepartmentInfo.AllowUserToAddRows = false;
            this.dgv_DepartmentInfo.AllowUserToDeleteRows = false;
            this.dgv_DepartmentInfo.AllowUserToResizeColumns = false;
            this.dgv_DepartmentInfo.AllowUserToResizeRows = false;
            this.dgv_DepartmentInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DepartmentInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DepartmentInfo.ColumnHeadersHeight = 35;
            this.dgv_DepartmentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_DepartmentInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepartmentNo,
            this.DepartmentName,
            this.Remarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DepartmentInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DepartmentInfo.Location = new System.Drawing.Point(15, 65);
            this.dgv_DepartmentInfo.MultiSelect = false;
            this.dgv_DepartmentInfo.Name = "dgv_DepartmentInfo";
            this.dgv_DepartmentInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DepartmentInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DepartmentInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_DepartmentInfo.RowTemplate.Height = 23;
            this.dgv_DepartmentInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DepartmentInfo.Size = new System.Drawing.Size(372, 305);
            this.dgv_DepartmentInfo.TabIndex = 18;
            // 
            // DepartmentNo
            // 
            this.DepartmentNo.DataPropertyName = "DepartmentNo";
            this.DepartmentNo.HeaderText = "部门编号";
            this.DepartmentNo.Name = "DepartmentNo";
            this.DepartmentNo.ReadOnly = true;
            this.DepartmentNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DepartmentName
            // 
            this.DepartmentName.DataPropertyName = "DepartmentName";
            this.DepartmentName.HeaderText = "部门名称";
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.ReadOnly = true;
            this.DepartmentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.label1.TabIndex = 17;
            this.label1.Text = "查询方式：";
            // 
            // cbo_DepartmentQueryMode
            // 
            this.cbo_DepartmentQueryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_DepartmentQueryMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_DepartmentQueryMode.FormattingEnabled = true;
            this.cbo_DepartmentQueryMode.Items.AddRange(new object[] {
            "  全部  ",
            "  按部门编号",
            "  按部门名称"});
            this.cbo_DepartmentQueryMode.Location = new System.Drawing.Point(86, 32);
            this.cbo_DepartmentQueryMode.Name = "cbo_DepartmentQueryMode";
            this.cbo_DepartmentQueryMode.Size = new System.Drawing.Size(91, 25);
            this.cbo_DepartmentQueryMode.TabIndex = 16;
            this.cbo_DepartmentQueryMode.SelectedIndexChanged += new System.EventHandler(this.cbo_DepartmentQueryMode_SelectedIndexChanged);
            // 
            // txt_QueryCondition
            // 
            this.txt_QueryCondition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_QueryCondition.Location = new System.Drawing.Point(183, 32);
            this.txt_QueryCondition.Name = "txt_QueryCondition";
            this.txt_QueryCondition.Size = new System.Drawing.Size(204, 23);
            this.txt_QueryCondition.TabIndex = 13;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_AddDepartment,
            this.toolStripSeparator1,
            this.tsbtn_ModifyDepartment,
            this.toolStripSeparator2,
            this.tsbtn_DeleteDepartment,
            this.toolStripSeparator3,
            this.tsbtn_QueryDepartment});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(427, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_AddDepartment
            // 
            this.tsbtn_AddDepartment.Image = global::MS.UI.Properties.Resources.添加;
            this.tsbtn_AddDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_AddDepartment.Name = "tsbtn_AddDepartment";
            this.tsbtn_AddDepartment.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_AddDepartment.Text = "添加";
            this.tsbtn_AddDepartment.Click += new System.EventHandler(this.tsbtn_AddDepartment_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_ModifyDepartment
            // 
            this.tsbtn_ModifyDepartment.Image = global::MS.UI.Properties.Resources.修改;
            this.tsbtn_ModifyDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ModifyDepartment.Name = "tsbtn_ModifyDepartment";
            this.tsbtn_ModifyDepartment.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_ModifyDepartment.Text = "修改";
            this.tsbtn_ModifyDepartment.Click += new System.EventHandler(this.tsbtn_ModifyDepartment_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_DeleteDepartment
            // 
            this.tsbtn_DeleteDepartment.Image = global::MS.UI.Properties.Resources.删除;
            this.tsbtn_DeleteDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_DeleteDepartment.Name = "tsbtn_DeleteDepartment";
            this.tsbtn_DeleteDepartment.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_DeleteDepartment.Text = "删除";
            this.tsbtn_DeleteDepartment.Click += new System.EventHandler(this.tsbtn_DeleteDepartment_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_QueryDepartment
            // 
            this.tsbtn_QueryDepartment.Image = global::MS.UI.Properties.Resources.查询;
            this.tsbtn_QueryDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_QueryDepartment.Name = "tsbtn_QueryDepartment";
            this.tsbtn_QueryDepartment.Size = new System.Drawing.Size(52, 22);
            this.tsbtn_QueryDepartment.Text = "查询";
            this.tsbtn_QueryDepartment.Click += new System.EventHandler(this.tsbtn_QueryDepartment_Click);
            // 
            // ep_Reminder
            // 
            this.ep_Reminder.ContainerControl = this;
            // 
            // FrmDepartmentQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 385);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgv_DepartmentInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_DepartmentQueryMode);
            this.Controls.Add(this.txt_QueryCondition);
            this.Name = "FrmDepartmentQuery";
            this.Tag = "1";
            this.Text = "FrmDepartmentQuery";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DepartmentInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Reminder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DepartmentInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_DepartmentQueryMode;
        private System.Windows.Forms.TextBox txt_QueryCondition;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_AddDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtn_ModifyDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtn_DeleteDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtn_QueryDepartment;
        private System.Windows.Forms.ErrorProvider ep_Reminder;
    }
}