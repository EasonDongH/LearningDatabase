using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.IO.Ports;

namespace ModbusDemo
{
    public partial class FrmModbus : Form
    {
        public FrmModbus()
        {
            InitializeComponent();
        }
        Modbus objMod = new Modbus();

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (objMod.OpenMyComm(9600, "COM3", 8, Parity.None, StopBits.One))
            {
                MessageBox.Show("打开串口成功！");
            }
            else
            {
                MessageBox.Show("打开串口失败！");
            }
        }

        private void btn_ReadReg_Click(object sender, EventArgs e)
        {
           byte[] Res = objMod.ReadKeepReg(1, 0, 10);
            if (Res.Length > 0)
            {
                this.listBox1.Items.Clear();
                for (int i = 0; i < Res.Length; i++)
                {
                    this.listBox1.Items.Add(Res[i].ToString());
                }
            }
        }

        private void btn_ReadOutCoil_Click(object sender, EventArgs e)
        {
            byte[] Res = objMod.ReadOutputStatus(1, 0, 10);
            if (Res.Length > 0)
            {
                this.listBox1.Items.Clear();
                for (int i = 0; i < Res.Length; i++)
                {
                    this.listBox1.Items.Add(Res[i].ToString());
                }
            }
        }

        private void btn_ReadInCoil_Click(object sender, EventArgs e)
        {
            byte[] Res = objMod.ReadInputStatus(1, 0, 10);
            if (Res.Length > 0)
            {
                this.listBox1.Items.Clear();
                for (int i = 0; i < Res.Length; i++)
                {
                    this.listBox1.Items.Add(Res[i].ToString());
                }
            }
        }

        private void btn_ForceCoil_Click(object sender, EventArgs e)
        {
            if (objMod.ForceCoil(1, 0, true))
            {
                MessageBox.Show("强制成功");
            }
            else
            {
                MessageBox.Show("强制失败");
            }
        }

        private void btn_SetSingleReg_Click(object sender, EventArgs e)
        {
            if (objMod.PreSetKeepReg(1,0,32))
            {
                MessageBox.Show("强制成功");
            }
            else
            {
                MessageBox.Show("强制失败");
            }
        }

        private void btn_SetDoubleReg_Click(object sender, EventArgs e)
        {
            if (objMod.PreSetFloatKeepReg(1,0,12.3f))
            {
                MessageBox.Show("强制成功");
            }
            else
            {
                MessageBox.Show("强制失败");
            }
        }
    }
}
