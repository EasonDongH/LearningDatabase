using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSTest
{
    public class FormOperation
    {
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
    }
}
