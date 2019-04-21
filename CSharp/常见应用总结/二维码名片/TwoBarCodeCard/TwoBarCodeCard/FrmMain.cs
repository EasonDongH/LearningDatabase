using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoBarCodeCard
{
    public partial class FrmMain : Form
    {
        private CreateQRCode createQRCode = new CreateQRCode();
        public FrmMain()
        {
            InitializeComponent();
        }
        //开始生成
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //封装数据
            CardData data = new CardData
            {
                Name = this.tbName.Text.Trim(),
                Post=this.tbPost.Text .Trim (),
                DepartMent = this.tbDepartment.Text.Trim(),
                Company = this.tbCompany.Text.Trim(),
                MobilePhone = this.tbMobilePhone.Text.Trim(),
                TelePhone = this.tbTelePhone.Text.Trim(),
                Address = this.tbAddrress.Text.Trim(),
                Url = this.tbUrl.Text.Trim(),
                Email = this.tbEMail.Text.Trim()
            };
            //调用二维码生成类的方法生成图片
            this.pbCode.Image = createQRCode.CreatCodeImage(data,
                this.pbCode.Width, this.pbCode.Height);
        }
    }
}
