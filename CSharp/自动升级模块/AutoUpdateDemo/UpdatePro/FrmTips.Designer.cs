namespace UpdatePro
{
    partial class FrmTips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTips));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTips = new System.Windows.Forms.Label();
            this.timer1_Up = new System.Windows.Forms.Timer(this.components);
            this.timer2_Down = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(219, 156);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "下次再说";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(97, 156);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 29);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "马上升级";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.BackColor = System.Drawing.Color.Transparent;
            this.lblTips.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTips.ForeColor = System.Drawing.Color.White;
            this.lblTips.Location = new System.Drawing.Point(92, 58);
            this.lblTips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(208, 27);
            this.lblTips.TabIndex = 14;
            this.lblTips.Text = "发 现 程 序 新 版 本！";
            // 
            // timer1_Up
            // 
            this.timer1_Up.Enabled = true;
            this.timer1_Up.Interval = 1;
            this.timer1_Up.Tick += new System.EventHandler(this.timer1_Up_Tick);
            // 
            // timer2_Down
            // 
            this.timer2_Down.Enabled = true;
            this.timer2_Down.Interval = 1;
            this.timer2_Down.Tick += new System.EventHandler(this.timer2_Down_Tick);
            // 
            // FrmTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(412, 208);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmTips";
            this.Load += new System.EventHandler(this.FrmTips_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Timer timer1_Up;
        private System.Windows.Forms.Timer timer2_Down;
    }
}