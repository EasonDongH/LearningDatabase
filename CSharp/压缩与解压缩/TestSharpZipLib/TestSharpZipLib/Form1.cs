using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestSharpZipLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharpZipLibHelper.ZipDecompress(@"C:\Users\EasonDongH\Desktop\新建文件夹 (2)", "Python Cookbook第三版中文.zip", @"C:\Users\EasonDongH\Desktop\新建文件夹 (3)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SharpZipLibHelper.ZipCompress(new string[] { @"C:\Users\EasonDongH\Desktop\123.txt", @"C:\Users\EasonDongH\Desktop\234.txt", @"C:\Users\EasonDongH\Desktop\新建文件夹 (3)" }, @"C:\Users\EasonDongH\Desktop\新建文件夹\123");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharpZipLibHelper.ZipCompress(@"C:\Users\EasonDongH\Desktop\新建文件夹 (3)", @"C:\Users\EasonDongH\Desktop\123.zip");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SharpCompress.Decompression(@"C:\Users\EasonDongH\Desktop\Python Cookbook第三版中文.rar", @"C:\Users\EasonDongH\Desktop\新建文件夹\");
        }
    }
}
