namespace MSTest
{
    partial class FrmDepartmentManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_AddDepartment = new System.Windows.Forms.Button();
            this.btn_DeleteDepartment = new System.Windows.Forms.Button();
            this.txt_QueryCondition = new System.Windows.Forms.TextBox();
            this.btn_QueryDepartmentInfo = new System.Windows.Forms.Button();
            this.btn_ModifyDepartmentInfo = new System.Windows.Forms.Button();
            this.cbo_DepartmentQueryMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_DepartmentInfo = new System.Windows.Forms.DataGridView();
            this.DepartmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_DepartmentInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rtb_Remarks = new System.Windows.Forms.RichTextBox();
            this.txt_DepartmentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DepartmentNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Confim = new System.Windows.Forms.Button();
            this.ep_Remind = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_AddRemind = new System.Windows.Forms.Label();
            this.lbl_ModifyRemind = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DepartmentInfo)).BeginInit();
            this.gb_DepartmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Remind)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AddDepartment
            // 
            this.btn_AddDepartment.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddDepartment.Location = new System.Drawing.Point(24, 56);
            this.btn_AddDepartment.Name = "btn_AddDepartment";
            this.btn_AddDepartment.Size = new System.Drawing.Size(100, 26);
            this.btn_AddDepartment.TabIndex = 0;
            this.btn_AddDepartment.Text = "添加部门";
            this.btn_AddDepartment.UseVisualStyleBackColor = true;
            this.btn_AddDepartment.Click += new System.EventHandler(this.btn_AddDepartment_Click);
            // 
            // btn_DeleteDepartment
            // 
            this.btn_DeleteDepartment.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteDepartment.Location = new System.Drawing.Point(298, 56);
            this.btn_DeleteDepartment.Name = "btn_DeleteDepartment";
            this.btn_DeleteDepartment.Size = new System.Drawing.Size(100, 26);
            this.btn_DeleteDepartment.TabIndex = 1;
            this.btn_DeleteDepartment.Text = "删除部门";
            this.btn_DeleteDepartment.UseVisualStyleBackColor = true;
            this.btn_DeleteDepartment.Click += new System.EventHandler(this.btn_DeleteDepartment_Click);
            // 
            // txt_QueryCondition
            // 
            this.txt_QueryCondition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_QueryCondition.Location = new System.Drawing.Point(192, 22);
            this.txt_QueryCondition.Name = "txt_QueryCondition";
            this.txt_QueryCondition.Size = new System.Drawing.Size(100, 23);
            this.txt_QueryCondition.TabIndex = 2;
            // 
            // btn_QueryDepartmentInfo
            // 
            this.btn_QueryDepartmentInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_QueryDepartmentInfo.Location = new System.Drawing.Point(297, 20);
            this.btn_QueryDepartmentInfo.Name = "btn_QueryDepartmentInfo";
            this.btn_QueryDepartmentInfo.Size = new System.Drawing.Size(100, 26);
            this.btn_QueryDepartmentInfo.TabIndex = 3;
            this.btn_QueryDepartmentInfo.Text = "查询部门信息";
            this.btn_QueryDepartmentInfo.UseVisualStyleBackColor = true;
            this.btn_QueryDepartmentInfo.Click += new System.EventHandler(this.btn_QueryDepartmentInfo_Click);
            // 
            // btn_ModifyDepartmentInfo
            // 
            this.btn_ModifyDepartmentInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModifyDepartmentInfo.Location = new System.Drawing.Point(161, 56);
            this.btn_ModifyDepartmentInfo.Name = "btn_ModifyDepartmentInfo";
            this.btn_ModifyDepartmentInfo.Size = new System.Drawing.Size(100, 26);
            this.btn_ModifyDepartmentInfo.TabIndex = 4;
            this.btn_ModifyDepartmentInfo.Text = "修改部门信息";
            this.btn_ModifyDepartmentInfo.UseVisualStyleBackColor = true;
            this.btn_ModifyDepartmentInfo.Click += new System.EventHandler(this.btn_ModifyDepartmentInfo_Click);
            // 
            // cbo_DepartmentQueryMode
            // 
            this.cbo_DepartmentQueryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_DepartmentQueryMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_DepartmentQueryMode.FormattingEnabled = true;
            this.cbo_DepartmentQueryMode.Items.AddRange(new object[] {
            "  按部门编号",
            "  按部门名称"});
            this.cbo_DepartmentQueryMode.Location = new System.Drawing.Point(95, 20);
            this.cbo_DepartmentQueryMode.Name = "cbo_DepartmentQueryMode";
            this.cbo_DepartmentQueryMode.Size = new System.Drawing.Size(91, 25);
            this.cbo_DepartmentQueryMode.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "查询方式：";
            // 
            // dgv_DepartmentInfo
            // 
            this.dgv_DepartmentInfo.AllowUserToAddRows = false;
            this.dgv_DepartmentInfo.AllowUserToDeleteRows = false;
            this.dgv_DepartmentInfo.AllowUserToResizeColumns = false;
            this.dgv_DepartmentInfo.AllowUserToResizeRows = false;
            this.dgv_DepartmentInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DepartmentInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_DepartmentInfo.ColumnHeadersHeight = 35;
            this.dgv_DepartmentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_DepartmentInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepartmentNo,
            this.DepartmentName,
            this.Remarks});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DepartmentInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_DepartmentInfo.Location = new System.Drawing.Point(26, 101);
            this.dgv_DepartmentInfo.MultiSelect = false;
            this.dgv_DepartmentInfo.Name = "dgv_DepartmentInfo";
            this.dgv_DepartmentInfo.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DepartmentInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_DepartmentInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_DepartmentInfo.RowTemplate.Height = 23;
            this.dgv_DepartmentInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DepartmentInfo.Size = new System.Drawing.Size(372, 226);
            this.dgv_DepartmentInfo.TabIndex = 7;
            this.dgv_DepartmentInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DepartmentInfo_CellClick);
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
            // gb_DepartmentInfo
            // 
            this.gb_DepartmentInfo.Controls.Add(this.label3);
            this.gb_DepartmentInfo.Controls.Add(this.btn_Cancel);
            this.gb_DepartmentInfo.Controls.Add(this.rtb_Remarks);
            this.gb_DepartmentInfo.Controls.Add(this.txt_DepartmentName);
            this.gb_DepartmentInfo.Controls.Add(this.label2);
            this.gb_DepartmentInfo.Controls.Add(this.txt_DepartmentNo);
            this.gb_DepartmentInfo.Controls.Add(this.label4);
            this.gb_DepartmentInfo.Controls.Add(this.btn_Confim);
            this.gb_DepartmentInfo.Location = new System.Drawing.Point(420, 12);
            this.gb_DepartmentInfo.Name = "gb_DepartmentInfo";
            this.gb_DepartmentInfo.Size = new System.Drawing.Size(317, 318);
            this.gb_DepartmentInfo.TabIndex = 8;
            this.gb_DepartmentInfo.TabStop = false;
            this.gb_DepartmentInfo.Text = "部门详情";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "备注：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(167, 261);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(93, 36);
            this.btn_Cancel.TabIndex = 47;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rtb_Remarks
            // 
            this.rtb_Remarks.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_Remarks.Location = new System.Drawing.Point(42, 126);
            this.rtb_Remarks.Name = "rtb_Remarks";
            this.rtb_Remarks.Size = new System.Drawing.Size(218, 120);
            this.rtb_Remarks.TabIndex = 46;
            this.rtb_Remarks.Text = "";
            // 
            // txt_DepartmentName
            // 
            this.txt_DepartmentName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_DepartmentName.Location = new System.Drawing.Point(111, 59);
            this.txt_DepartmentName.Name = "txt_DepartmentName";
            this.txt_DepartmentName.Size = new System.Drawing.Size(149, 23);
            this.txt_DepartmentName.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "部门名称：";
            // 
            // txt_DepartmentNo
            // 
            this.txt_DepartmentNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_DepartmentNo.Location = new System.Drawing.Point(111, 24);
            this.txt_DepartmentNo.Name = "txt_DepartmentNo";
            this.txt_DepartmentNo.Size = new System.Drawing.Size(149, 23);
            this.txt_DepartmentNo.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(40, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "部门编号：";
            // 
            // btn_Confim
            // 
            this.btn_Confim.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Confim.Location = new System.Drawing.Point(42, 261);
            this.btn_Confim.Name = "btn_Confim";
            this.btn_Confim.Size = new System.Drawing.Size(93, 36);
            this.btn_Confim.TabIndex = 41;
            this.btn_Confim.Text = "确认";
            this.btn_Confim.UseVisualStyleBackColor = true;
            // 
            // ep_Remind
            // 
            this.ep_Remind.ContainerControl = this;
            // 
            // lbl_AddRemind
            // 
            this.lbl_AddRemind.AutoSize = true;
            this.lbl_AddRemind.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_AddRemind.ForeColor = System.Drawing.Color.Red;
            this.lbl_AddRemind.Location = new System.Drawing.Point(25, 83);
            this.lbl_AddRemind.Name = "lbl_AddRemind";
            this.lbl_AddRemind.Size = new System.Drawing.Size(104, 17);
            this.lbl_AddRemind.TabIndex = 9;
            this.lbl_AddRemind.Text = "请在右侧填写信息";
            this.lbl_AddRemind.Visible = false;
            // 
            // lbl_ModifyRemind
            // 
            this.lbl_ModifyRemind.AutoSize = true;
            this.lbl_ModifyRemind.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ModifyRemind.ForeColor = System.Drawing.Color.Red;
            this.lbl_ModifyRemind.Location = new System.Drawing.Point(160, 83);
            this.lbl_ModifyRemind.Name = "lbl_ModifyRemind";
            this.lbl_ModifyRemind.Size = new System.Drawing.Size(104, 17);
            this.lbl_ModifyRemind.TabIndex = 10;
            this.lbl_ModifyRemind.Text = "请在右侧修改信息";
            this.lbl_ModifyRemind.Visible = false;
            // 
            // FrmDepartmentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 387);
            this.Controls.Add(this.lbl_ModifyRemind);
            this.Controls.Add(this.lbl_AddRemind);
            this.Controls.Add(this.gb_DepartmentInfo);
            this.Controls.Add(this.dgv_DepartmentInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_DepartmentQueryMode);
            this.Controls.Add(this.btn_ModifyDepartmentInfo);
            this.Controls.Add(this.btn_QueryDepartmentInfo);
            this.Controls.Add(this.txt_QueryCondition);
            this.Controls.Add(this.btn_DeleteDepartment);
            this.Controls.Add(this.btn_AddDepartment);
            this.Name = "FrmDepartmentManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部门管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DepartmentInfo)).EndInit();
            this.gb_DepartmentInfo.ResumeLayout(false);
            this.gb_DepartmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep_Remind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AddDepartment;
        private System.Windows.Forms.Button btn_DeleteDepartment;
        private System.Windows.Forms.TextBox txt_QueryCondition;
        private System.Windows.Forms.Button btn_QueryDepartmentInfo;
        private System.Windows.Forms.Button btn_ModifyDepartmentInfo;
        private System.Windows.Forms.ComboBox cbo_DepartmentQueryMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_DepartmentInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.GroupBox gb_DepartmentInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.RichTextBox rtb_Remarks;
        private System.Windows.Forms.TextBox txt_DepartmentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DepartmentNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Confim;
        private System.Windows.Forms.ErrorProvider ep_Remind;
        private System.Windows.Forms.Label lbl_ModifyRemind;
        private System.Windows.Forms.Label lbl_AddRemind;
    }
}