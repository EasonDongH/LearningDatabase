using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLReadTool
{

    public class ModelMain : BindableBase
    {
        public ModelMain()
        {
            this.SQLType = "SQLServer";
            this.IP = "192.168.10.251";
            this.PPOE = "3306";
            this.UserName = "shrismcis";
            this.Password = "shris";
            this.ConnState = "未连接";
        }
        #region Conn Property

        private string _sqlType;
        public string SQLType
        {
            get { return _sqlType; }
            set
            {
                if (this.SetProperty(ref _sqlType, value))
                {

                    this.OnPropertyChanged("SQLType");
                    this.ConSQLCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _dataBase;
        public string DataBase
        {
            get { return _dataBase; }
            set
            {
                if (this.SetProperty(ref _dataBase, value))
                {
                    this.OnPropertyChanged("DataBase");
                    this.ConSQLCommand.RaiseCanExecuteChanged();
                    this.GetTablesCommand.RaiseCanExecuteChanged();
                    this.GetDataBaseCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _table;
        public string Table
        {
            get { return _table; }
            set
            {
                if (this.SetProperty(ref _table, value))
                {
                    this.OnPropertyChanged("Table");
                    this.ConSQLCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _iP;
        public string IP
        {
            get { return _iP; }
            set
            {
                if (this.SetProperty(ref _iP, value))
                {

                    this.OnPropertyChanged("IP");
                    this.ConSQLCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _pPOE;
        public string PPOE
        {
            get { return _pPOE; }
            set
            {
                if (this.SetProperty(ref _pPOE, value))
                {
                    this.OnPropertyChanged("PPOE");
                    this.ConSQLCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (this.SetProperty(ref _userName, value))
                {
                    this.OnPropertyChanged("UserName");
                    this.ConSQLCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (this.SetProperty(ref _password, value))
                {
                    this.OnPropertyChanged("Password");
                    this.ConSQLCommand.RaiseCanExecuteChanged();
                }
            }
        }

        #endregion






        /// <summary>
        /// SqlSever连接
        /// </summary>
        private SqlConnection _conn_SqlServer;
        public SqlConnection Conn_SqlServer
        {
            get { return _conn_SqlServer; }
            set
            {
                if (this.SetProperty(ref _conn_SqlServer, value))
                {
                    this.OnPropertyChanged("Conn_SqlServer");

                }
            }
        }



        /// <summary>
        /// MySql连接
        /// </summary>
        private MySqlConnection _conn_MySql;
        public MySqlConnection Conn_MySql
        {
            get { return _conn_MySql; }
            set
            {
                if (this.SetProperty(ref _conn_MySql, value))
                {
                    this.OnPropertyChanged("Conn_MySql");

                }
            }
        }



        /// <summary>
        /// 连接状态
        /// </summary>
        private string _connState;
        public string ConnState
        {
            get { return _connState; }
            set
            {
                if (this.SetProperty(ref _connState, value))
                {
                    this.OnPropertyChanged("ConnState");
                    this.GetDataBaseCommand.RaiseCanExecuteChanged();
                }
            }
        }






        /// <summary>
        /// 选中表的记录
        /// </summary>
        private DataTable _records;
        public DataTable Records
        {
            get { return _records; }
            set
            {
                if (this.SetProperty(ref _records, value))
                {
                    this.OnPropertyChanged("Records");

                }
            }
        }



        /// <summary>
        /// TreeView
        /// </summary>
        private readonly ObservableCollection<ModelViewItem> _tree = new ObservableCollection<ModelViewItem>();

        public ObservableCollection<ModelViewItem> Tree
        {
            get { return this._tree; }
        }





        #region 连接数据库

        private DelegateCommand conSQLCommand;

        public DelegateCommand ConSQLCommand
        {
            get
            {
                if (conSQLCommand == null)
                {
                    conSQLCommand = new DelegateCommand(ConSQL, CanConSQL);
                }
                return conSQLCommand;
            }
        }


        private void ConSQL()
        {
            try
            {

                SqlConnection wConn_SqlServer = new SqlConnection();
                MySqlConnection wConn_MySql = new MySqlConnection();

                this.ConnState = SqlReader.ConnectDataBase(this.SQLType, this.IP, this.PPOE, this.DataBase,
                    this.UserName, this.Password, ref  wConn_SqlServer, ref  wConn_MySql);
                this.Conn_SqlServer = wConn_SqlServer;
                this.Conn_MySql = wConn_MySql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private bool CanConSQL()
        {

            //return (!string.IsNullOrEmpty(this.SQLType));
            if (this.DataBase != null)
                return false;
            return (!string.IsNullOrEmpty(this.SQLType)
                && !string.IsNullOrEmpty(this.IP)
               && !string.IsNullOrEmpty(this.PPOE)
                && !string.IsNullOrEmpty(this.UserName)
             && !string.IsNullOrEmpty(this.Password)
                );




        }
        #endregion


        #region 关闭数据库
        private DelegateCommand closeSQLCommand;

        public DelegateCommand CloseSQLCommand
        {
            get
            {
                if (closeSQLCommand == null)
                {
                    closeSQLCommand = new DelegateCommand(CloseSQL, CanCloseSQL);
                }
                return closeSQLCommand;
            }
        }


        private void CloseSQL()
        {
            try
            {
                this.ConnState = SqlReader.CloseDataBase(this.Conn_SqlServer, this.Conn_MySql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private bool CanCloseSQL()
        {
            if (this.Conn_SqlServer != null || this.Conn_MySql != null)
                return true;
            else
                return false;
        }
        #endregion


        #region 获取所有数据库名称
        private DelegateCommand getDataBaseCommand;

        public DelegateCommand GetDataBaseCommand
        {
            get
            {
                if (getDataBaseCommand == null)
                {
                    getDataBaseCommand = new DelegateCommand(GetDataBase, CanGetDataBase);
                }
                return getDataBaseCommand;
            }
        }


        private void GetDataBase()
        {
            try
            {
                this.Tree.Clear();
                string wError = "";
                DataTable wDataTable = new DataTable();

                if (this.ConnState.Contains("未连接"))
                {
                    MessageBox.Show("请先连接数据库");
                    return;
                }

                wDataTable = SqlReader.GetDataBaseNames(this.Conn_SqlServer, this.Conn_MySql, out wError);
                if (wDataTable.Rows.Count > 0)
                {

                    foreach (DataRow row in wDataTable.Rows)
                    {
                        ModelViewItem wModelViewItem = new ModelViewItem();
                        wModelViewItem.DataBaseICON = @"D:\Pro\SQLReadTool_BackUP\ico\Database 3.ico";

                        if (this.SQLType.Equals("SQLServer"))
                            wModelViewItem.DataBase = row["name"].ToString();

                        if (this.SQLType.Equals("MySQL"))
                            wModelViewItem.DataBase = row[0].ToString();
                        this.Tree.Add(wModelViewItem);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private bool CanGetDataBase()
        {
            //return (!string.IsNullOrEmpty(this.ConnState));
            bool wValid = false;

            if (this.ConnState != null && this.ConnState.Equals("连接成功"))
                wValid = true;
            if(this.DataBase!=null)
                wValid = false;
            return wValid;

       

        }
        #endregion


        #region 获取某个数据库下所有表名称
        private DelegateCommand getTablesCommand
          ;

        public DelegateCommand GetTablesCommand
        {
            get
            {
                if (getTablesCommand == null)
                {
                    getTablesCommand = new DelegateCommand(GetTables, CanGetTables);
                }
                return getTablesCommand;
            }
        }


        private void GetTables()
        {
            string wError = "";
            DataTable wDataTable = new DataTable();
            this.CloseSQL();
            this.ConSQL();
            wDataTable = SqlReader.GetTableNames(this.Conn_SqlServer, this.Conn_MySql, this.DataBase, out wError);
            if (wDataTable.Rows.Count > 0)
            {

                foreach (ModelViewItem wItem in this.Tree)
                {
                    //wItem.TabelNames.Clear();
                    if (wItem.DataBase.Equals(this.DataBase))
                    {
                        //Tables---No.2
                        foreach (DataRow row in wDataTable.Rows)
                        {
                            ModelViewItem wNodes = new ModelViewItem();
                            //wNodes.DataBase = this.SelectDataBase;
                            wNodes.TabelName = row[0].ToString();
                            wNodes.TabelNameICON = @"D:\Pro\SQLReadTool_BackUP\ico\Notepad.ico";
                            //wNodes.TabelNames.Add(wNodes);
                            wItem.TabelNames.Add(wNodes);
                        }

                    }


                }

            }

        }

        private bool CanGetTables()
        {

            return (!string.IsNullOrEmpty(this.DataBase));
        }
        #endregion



        #region 获取某张表的所有记录
        private DelegateCommand getRecordsCommand
          ;

        public DelegateCommand GetRecordsCommand
        {
            get
            {
                if (getRecordsCommand == null)
                {
                    getRecordsCommand = new DelegateCommand(GetRecords, CanGetRecords);
                }
                return getRecordsCommand;
            }
        }


        /// <summary>
        /// 获取表
        /// </summary>
        public void GetRecords()
        {
            this.Records = new DataTable();
            List<Item> wFeilds = new List<Item>();
            string wError = "";
            this.CloseSQL();
            this.ConSQL();
            DataTable wDataValues = new DataTable();
            wFeilds = SqlReader.GetSqlFieldNames(this.Conn_SqlServer, this.Conn_MySql,
                this.DataBase, this.Table, out wDataValues, out wError);
            this.Records = wDataValues;
            //if (wFeilds == null || wFeilds.Count < 1)
            //    return;
            //foreach (Item wFeild in wFeilds)
            //{
            //    DataColumn wDataColumn = new DataColumn();
            //    wDataColumn.ColumnName = string.Format("{0}({1})", wFeild.Name, wFeild.Type);
            //    this.Records.Columns.Add(wDataColumn);
            //}


        }

        private bool CanGetRecords()
        {
            return (!string.IsNullOrEmpty(this.Table));
        }
        #endregion


    }
}
