using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Data.SqlClient;using System.Diagnostics;


namespace NPOIDemo
{
    public partial class FrmDemo : Form
    {
        private ProductService productService = new ProductService();
        private List<Product> ExportProductList = null;
        private List<Product> importProductList = null;

        public FrmDemo()
        {
            InitializeComponent();

            this.dgvProductList1.AutoGenerateColumns = false;
            this.dgvProductList2.AutoGenerateColumns = false;

            this.ExportProductList = productService.GetProductList();
            this.dgvProductList1.DataSource = this.ExportProductList;

        }

        //将集合导出到Excel文件
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //设置导出的列标题（实际开发中，也可以放到xml文件中）
            Dictionary<string, string> columnNames = new Dictionary<string, string>();
            columnNames.Add("ProductId", "商品编号");
            columnNames.Add("ProductName", "商品名称");
            columnNames.Add("Unit", "计量单位");
            columnNames.Add("UnitPrice", "商品单价");
            columnNames.Add("Discount", "当前折扣");
            //调用导出方法:fileName将来可以通过让用户选择路径方式获取
            bool result = NPOIService.ExportToExcel<Product>("productList.xls",
               this.ExportProductList, columnNames);
            if (result)
            {
                DialogResult dialog = MessageBox.Show("导出成功！是否打开文件", "导出成功",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Process.Start("productList.xls");
                }
            }
        }

        //将Excel导入集合并在DataGridView显示
        private void bntImortExcel_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFile.FileName;//获取文件路径
                this.importProductList = NPOIService.ImportToList<Product>(path);
                //显示数据
                this.dgvProductList2.DataSource = null;
                this.dgvProductList2.DataSource = this.importProductList;
            }
        }
    }
}
