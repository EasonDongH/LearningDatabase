namespace ModbusDemo
{
    partial class FrmModbus
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
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_ReadReg = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_ReadOutCoil = new System.Windows.Forms.Button();
            this.btn_ReadInCoil = new System.Windows.Forms.Button();
            this.btn_ForceCoil = new System.Windows.Forms.Button();
            this.btn_SetSingleReg = new System.Windows.Forms.Button();
            this.btn_SetDoubleReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(12, 57);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(97, 49);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "连接串口";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_ReadReg
            // 
            this.btn_ReadReg.Location = new System.Drawing.Point(120, 57);
            this.btn_ReadReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ReadReg.Name = "btn_ReadReg";
            this.btn_ReadReg.Size = new System.Drawing.Size(97, 49);
            this.btn_ReadReg.TabIndex = 0;
            this.btn_ReadReg.Text = "读取寄存器";
            this.btn_ReadReg.UseVisualStyleBackColor = true;
            this.btn_ReadReg.Click += new System.EventHandler(this.btn_ReadReg_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(12, 171);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(745, 293);
            this.listBox1.TabIndex = 1;
            // 
            // btn_ReadOutCoil
            // 
            this.btn_ReadOutCoil.Location = new System.Drawing.Point(228, 57);
            this.btn_ReadOutCoil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ReadOutCoil.Name = "btn_ReadOutCoil";
            this.btn_ReadOutCoil.Size = new System.Drawing.Size(97, 49);
            this.btn_ReadOutCoil.TabIndex = 0;
            this.btn_ReadOutCoil.Text = "读取输出线圈";
            this.btn_ReadOutCoil.UseVisualStyleBackColor = true;
            this.btn_ReadOutCoil.Click += new System.EventHandler(this.btn_ReadOutCoil_Click);
            // 
            // btn_ReadInCoil
            // 
            this.btn_ReadInCoil.Location = new System.Drawing.Point(336, 57);
            this.btn_ReadInCoil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ReadInCoil.Name = "btn_ReadInCoil";
            this.btn_ReadInCoil.Size = new System.Drawing.Size(97, 49);
            this.btn_ReadInCoil.TabIndex = 0;
            this.btn_ReadInCoil.Text = "读取输入线圈";
            this.btn_ReadInCoil.UseVisualStyleBackColor = true;
            this.btn_ReadInCoil.Click += new System.EventHandler(this.btn_ReadInCoil_Click);
            // 
            // btn_ForceCoil
            // 
            this.btn_ForceCoil.Location = new System.Drawing.Point(444, 57);
            this.btn_ForceCoil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ForceCoil.Name = "btn_ForceCoil";
            this.btn_ForceCoil.Size = new System.Drawing.Size(97, 49);
            this.btn_ForceCoil.TabIndex = 0;
            this.btn_ForceCoil.Text = "强制线圈";
            this.btn_ForceCoil.UseVisualStyleBackColor = true;
            this.btn_ForceCoil.Click += new System.EventHandler(this.btn_ForceCoil_Click);
            // 
            // btn_SetSingleReg
            // 
            this.btn_SetSingleReg.Location = new System.Drawing.Point(552, 57);
            this.btn_SetSingleReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SetSingleReg.Name = "btn_SetSingleReg";
            this.btn_SetSingleReg.Size = new System.Drawing.Size(97, 49);
            this.btn_SetSingleReg.TabIndex = 0;
            this.btn_SetSingleReg.Text = "写入单寄存器";
            this.btn_SetSingleReg.UseVisualStyleBackColor = true;
            this.btn_SetSingleReg.Click += new System.EventHandler(this.btn_SetSingleReg_Click);
            // 
            // btn_SetDoubleReg
            // 
            this.btn_SetDoubleReg.Location = new System.Drawing.Point(660, 57);
            this.btn_SetDoubleReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SetDoubleReg.Name = "btn_SetDoubleReg";
            this.btn_SetDoubleReg.Size = new System.Drawing.Size(97, 49);
            this.btn_SetDoubleReg.TabIndex = 0;
            this.btn_SetDoubleReg.Text = "写入双寄存器";
            this.btn_SetDoubleReg.UseVisualStyleBackColor = true;
            this.btn_SetDoubleReg.Click += new System.EventHandler(this.btn_SetDoubleReg_Click);
            // 
            // FrmModbus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 595);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_SetDoubleReg);
            this.Controls.Add(this.btn_SetSingleReg);
            this.Controls.Add(this.btn_ForceCoil);
            this.Controls.Add(this.btn_ReadInCoil);
            this.Controls.Add(this.btn_ReadOutCoil);
            this.Controls.Add(this.btn_ReadReg);
            this.Controls.Add(this.btn_Connect);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmModbus";
            this.Text = "Modbus仿真";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_ReadReg;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_ReadOutCoil;
        private System.Windows.Forms.Button btn_ReadInCoil;
        private System.Windows.Forms.Button btn_ForceCoil;
        private System.Windows.Forms.Button btn_SetSingleReg;
        private System.Windows.Forms.Button btn_SetDoubleReg;
    }
}