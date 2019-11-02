
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLReadTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {


        UCDataBaseEdit wUC1 = new UCDataBaseEdit();
        UCDataBaseEdit wUC2 = new UCDataBaseEdit();
        public MainWindow()
        {

            InitializeComponent();



            this.MyGrid1.Children.Add(wUC1);
            this.MyGrid2.Children.Add(wUC2);
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            ModelMain wU1 = (ModelMain)wUC1.DataContext;
            ModelMain wU2 = (ModelMain)wUC2.DataContext;
            string wError = "";



            if (wU2.SQLType.Equals("SQLServer"))
            {

                string wConnstr = String.Format("Data Source={0};Initial Catalog = {1};User ID = {2};PWD = {3}", wU2.IP, wU2.DataBase, wU2.UserName, wU2.Password);
                SqlReader.CopyData(wU1.Records, wU1.DataBase, wU1.Table, SQLType.SQLServer, wU2.DataBase, wU2.Table, wU2.Records, wConnstr, out wError);
            }
            if (wU2.SQLType.Equals("MySQL"))
            {


                string wConnstr = string.Format("server={0};user id={1};password={2};database={3};port={4};pooling=false;charset=utf8",
                    wU2.IP, wU2.UserName, wU2.Password, wU2.DataBase, wU2.PPOE);
                //SqlReader.SqlBulkCopyByDatatable(wU1.Records, wU2.Records, SQLType.MySQL, wConnstr, out wError);
                SqlReader.CopyData(wU1.Records, wU1.DataBase, wU1.Table, SQLType.MySQL, wU2.DataBase, wU2.Table, wU2.Records, wConnstr, out wError);
            }
            if (wError.Length > 0)
            {
                MessageBox.Show("复制失败!");
                return;
            }


            MessageBox.Show("复制成功!");
            wU2.GetRecords();
            wUC2.MyDataGrid.ItemsSource = null;
            wUC2.MyDataGrid.ItemsSource = wU2.Records.DefaultView;




        }







    }
}
