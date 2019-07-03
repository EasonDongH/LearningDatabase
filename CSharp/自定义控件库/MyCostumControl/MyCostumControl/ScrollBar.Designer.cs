namespace MyCostumControl
{
    partial class ScrollBar
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Text
            // 
            this.lbl_Text.AutoSize = true;
            this.lbl_Text.Location = new System.Drawing.Point(3, 29);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(53, 12);
            this.lbl_Text.TabIndex = 0;
            this.lbl_Text.Text = "提示内容";
            // 
            // ScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Text);
            this.Name = "ScrollBar";
            this.Size = new System.Drawing.Size(256, 73);
            this.Load += new System.EventHandler(this.ScrollBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Text;
    }
}
