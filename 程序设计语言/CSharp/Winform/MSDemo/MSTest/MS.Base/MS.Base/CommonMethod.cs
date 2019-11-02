using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MS.Base
{
    public class CommonMethod
    {
        public static string GetGUID()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 将child窗体附加到father控件中
        /// </summary>
        /// <param name="father"></param>
        /// <param name="child"></param>
        public static void ChildFormAddToParentForm(Control father, Form child)
        {
            foreach (Control c in father.Controls)
            {
                if (c is Form)
                {
                    ((Form)c).Close();
                }
            }

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;//去窗体边框
            child.Parent = father;//指定父容器
            child.Dock = DockStyle.Fill;//设置子窗体随着容器大小变化
            child.Show();
        }

        /// <summary>
        /// 使Combox显示文本居中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ComboBox_TextCenter(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;  //当前的ComboBox控件
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            SolidBrush myBrush = new SolidBrush(cmb.ForeColor);  //字体颜色
            Font ft = cmb.Font;    //获取在属性中设置的字体

            //选项的文本
            string itemText = cmb.GetItemText(cmb.Items[e.Index]);//cmb.Items[e.Index].ToString(); 
            // 计算字符串尺寸（以像素为单位）
            SizeF ss = e.Graphics.MeasureString(itemText, cmb.Font);

            // 水平居中
            float left = 0;
            left = (float)(e.Bounds.Width - ss.Width) / 2;  //如果需要水平居中取消注释
            if (left < 0) left = 0f;

            // 垂直居中
            float top = (float)(e.Bounds.Height - ss.Height) / 2;
            if (top <= 0) top = 0f;

            // 输出
            e.DrawBackground();
            e.Graphics.DrawString(itemText, ft, myBrush, new RectangleF(
                e.Bounds.X + left,    //设置X坐标偏移量
                e.Bounds.Y + top,     //设置Y坐标偏移量
                e.Bounds.Width, e.Bounds.Height), StringFormat.GenericDefault);

            //e.Graphics.DrawString(cmb.GetItemText(cmb.Items[e.Index]), ft, myBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        public static string UTF16ToUTF8(string str)
        {
            byte[] utf16bytes = Encoding.Unicode.GetBytes(str);
            byte[] utf8bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16bytes);
            return Encoding.UTF8.GetString(utf8bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length">当前文本长度</param>
        /// <param name="key">当前键入值</param>
        /// <param name="c">错误提示绑定的控件</param>
        /// <param name="ep">错误提示控件</param>
        /// <param name="func">验证函数</param>
        public static void CheckInputLength(Control c,KeyPressEventArgs e,  ErrorProvider ep, Func<int, bool> func)
        {
            ep.Clear();
            if (!(func(c.Text.Trim().Length)))
            {
                if (Convert.ToInt32(e.KeyChar) != Convert.ToInt32(Keys.Back))
                {
                    ep.SetError(c, "已到达最大输入长度");
                    e.Handled = true;
                }
            }
        }
    }
}
