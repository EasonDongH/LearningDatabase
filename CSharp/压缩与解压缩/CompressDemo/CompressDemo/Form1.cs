using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CompressDemo
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
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SharpCompressHelper.Compress(@"C:\Users\EasonDongH\Desktop\压缩文件\", @"C:\Users\EasonDongH\Desktop\得到压缩包\", "测试.zip");
        }

        private void btnRarMultiPartArchive_Click(object sender, EventArgs e)
        {
            WinRARHelper.CompressedFile(@"C:\Users\Administrator\Desktop\Test\", "1k", @"C:\Users\Administrator\Desktop\TestRar\Test.zip");
        }

        private void btnRarCompress_Click(object sender, EventArgs e)
        {
            WinRARHelper.CompressedFile(@"C:\Users\Administrator\Desktop\Test\data1.txt", @"C:\Users\Administrator\Desktop\TestRar\Test.rar", true, string.Empty);
        }

        private void btnSharpCompressDeCompress_Click(object sender, EventArgs e)
        {
            if (IsValid() == false)
                return;
            SharpCompressHelper.Decompress(this.txtPackage.Text.Trim(), this.txtFilePath.Text.Trim());
        }

        private bool IsValid()
        {
            if (this.txtPackage.Text.Trim() == string.Empty)
            {
                MessageBox.Show("压缩包路径不能为空");
                return false;
            }
            if (this.txtFilePath.Text.Trim() == string.Empty)
            {
                this.txtFilePath.Text = "TempFile\\";
            }
            if (System.IO.Directory.Exists(this.txtFilePath.Text) == false)
            {
                System.IO.Directory.CreateDirectory(this.txtFilePath.Text);
            }
            return true;
        }

        private void lblPackage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.txtPackage.Text = openFile.FileName;
            }
        }

        private void lblFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath.Text = saveFile.FileName;
            }
        }

        private void btnAutoDecompress_Click(object sender, EventArgs e)
        {
            if (IsValid() == false)
                return;
            CompressHelper.Decompress(this.txtPackage.Text.Trim(), this.txtFilePath.Text.Trim());
        }
    }
}
