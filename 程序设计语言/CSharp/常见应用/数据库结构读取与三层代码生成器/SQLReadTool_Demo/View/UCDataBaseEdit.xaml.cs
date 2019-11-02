using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// UCDataBaseEdit.xaml 的交互逻辑
    /// </summary>
    public partial class UCDataBaseEdit : UserControl
    {

        ModelMain mDataContext;
        public UCDataBaseEdit()
        {
            InitializeComponent();

            this.DataContext = new ModelMain();
            mDataContext = (ModelMain)this.DataContext;
        }
        private void MyTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (MyTreeView.SelectedItem != null)
            {


                ModelViewItem wSelectItem = (ModelViewItem)MyTreeView.SelectedItem;
                mDataContext.Table = wSelectItem.TabelName;
                if (mDataContext.Table != null)
                    return;
                mDataContext.DataBase = wSelectItem.DataBase;





            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mDataContext.GetRecords();
            this.MyDataGrid.ItemsSource = null;
            this.MyDataGrid.ItemsSource = mDataContext.Records.DefaultView;
        }

    }
}
