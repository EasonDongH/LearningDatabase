using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDemo
{
    enum MsgType { Text = 0, File = 1 }
    class CommonMethod
    {
        public Func<byte[], string> FileSaveFunc;
        public CommonMethod()
        {
            this.FileSaveFunc += FileSave;
        }
        private byte[] GetFileBytes(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] byteBuffer = new byte[1024 * 1024 * 2];
                int length = fs.Read(byteBuffer, 0, byteBuffer.Length);
                return byteBuffer;
            }
        }

        private byte[] GetTextBytes(string msg)
        {
            return Encoding.UTF8.GetBytes(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="msgType">其会充当发送数据的首字节，接收时注意处理</param>
        /// <returns></returns>
        public byte[] GetSendBytes(string context, MsgType msgType)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(msgType));
            switch (msgType)
            {
                case MsgType.Text:
                    bytes.AddRange(GetTextBytes(context)); break;
                case MsgType.File:
                    bytes.AddRange(GetFileBytes(context)); break;
                default:
                    break;
            }
            return bytes.ToArray();

        }

        private string FileSave(byte[] file)
        {
            string returnMsg = string.Empty;
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "word files(*.docx)|*.docx|txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|All files(*.*)|*.*";
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return string.Empty;
                string filePath = saveFileDialog.FileName;
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(file, 1, file.Length - 1);
                }
                returnMsg = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return returnMsg;
        }

        public string SelectFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() != DialogResult.OK)
                return string.Empty;
            return openFile.FileName;
        }
    }
}
