using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSTest
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

        public static string UTF16ToUTF8(string str)
        {
            byte[] utf16bytes = Encoding.Unicode.GetBytes(str);
            byte[] utf8bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16bytes);
            return Encoding.UTF8.GetString(utf8bytes);
        }

    }
}
