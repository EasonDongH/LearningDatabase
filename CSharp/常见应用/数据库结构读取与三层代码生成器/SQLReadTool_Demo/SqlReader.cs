using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SQLReadTool
{
    /// <summary>
    /// 
    /// </summary>
    ///   1.获得SqlServer服务器名：列表显示
    ///   2.获得SqlServer数据库名：列表显示
    ///   3.获得SqlServer表名：列表显示
    ///   4.获得SqlServer字段名：列表显示
    ///   5.复制旧表到新表
    ///   6.删除新数据库的数据
    public static class SqlReader
    {



        public static string IP = "";

        public static string UserName = "";

        public static string Password = "";

        public static string ConnectDataBase(string wSQLType, string wIP, string wPPOE,
            string wDataBase, string wUserName, string wPassword, ref SqlConnection wConn_SqlServer, ref  MySqlConnection wConn_MySql)
        {
            string wState = "连接失败";
            wConn_SqlServer = new SqlConnection();
            wConn_MySql = new MySqlConnection();
            try
            {
                string wConnstr = "";
                switch (wSQLType)
                {
                    case "SQLServer":
                        wConnstr = string.Format("Data Source={0};Initial Catalog = {1};User ID = {2};PWD = {3}", wIP, wDataBase, wUserName, wPassword);
                        wConn_SqlServer = new SqlConnection(wConnstr);
                        if (wConn_SqlServer.State == System.Data.ConnectionState.Closed)
                        {
                            wConn_SqlServer.Open();
                            wState = "连接成功";
                        }
                        break;
                    case "MySQL":
                        wConnstr = string.Format("server={0};user id={1};password={2};database={3};port={4};pooling=false;charset=utf8", wIP, wUserName, wPassword, wDataBase, wPPOE);
                        wConn_MySql = new MySqlConnection(wConnstr);
                        if (wConn_MySql.State == System.Data.ConnectionState.Closed)
                        {
                            wConn_MySql.Open();
                            wState = "连接成功";
                        }
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {

                wState = "异常";
                throw ex;
            }
            return wState;

        }

        public static string CloseDataBase(SqlConnection wConn_SqlServer, MySqlConnection wConn_MySql)
        {
            string wState = "";
            try
            {

                if (wConn_SqlServer != null)
                    if (wConn_SqlServer.State == System.Data.ConnectionState.Open)
                    {
                        wConn_SqlServer.Close();
                        wState = "已关闭";
                    }
                if (wConn_MySql != null)
                    if (wConn_MySql.State == System.Data.ConnectionState.Open)
                    {
                        wConn_MySql.Close();
                        wState = "已关闭";
                    }
            }
            catch (Exception ex)
            {

                wState = "异常";
                throw ex;
            }
            return wState;

        }


        public static DataTable GetDataBaseNames(SqlConnection wConn_SqlServer, MySqlConnection wConn_MySql, out string wError)
        {
            DataTable wDataTable = null;
            wError = "";
            try
            {
                wDataTable = new DataTable();

                string wConmandStr = "";
                if (wConn_SqlServer.ConnectionString != null)
                    if (wConn_SqlServer.State == System.Data.ConnectionState.Open)
                    {
                        wConmandStr = "select name from master..sysdatabases";
                        SqlDataAdapter wSqlDataAdapter = new SqlDataAdapter(wConmandStr, wConn_SqlServer);
                        lock (wSqlDataAdapter)
                            wSqlDataAdapter.Fill(wDataTable);
                    }
                if (wConn_MySql.ConnectionString != null)
                    if (wConn_MySql.State == System.Data.ConnectionState.Open)
                    {
                        wConmandStr = "SHOW DATABASES";
                        MySqlDataAdapter wMySqlDataAdapter = new MySqlDataAdapter(wConmandStr, wConn_MySql);
                        lock (wMySqlDataAdapter)
                            wMySqlDataAdapter.Fill(wDataTable);
                    }
            }
            catch (Exception ex)
            {

                wError = ex.ToString();

            }
            return wDataTable;
        }

        public static DataTable GetTableNames(SqlConnection wConn_SqlServer, MySqlConnection wConn_MySql, string wDataBase, out string wError)
        {
            DataTable wDataTable = null;
            wError = "";
            try
            {
                wDataTable = new DataTable();
                wDataTable.TableName = wDataBase;
                string wConmandStr = "";
                if (wConn_SqlServer.ConnectionString != null)
                    if (wConn_SqlServer.State == System.Data.ConnectionState.Open)
                    {
                        wConmandStr = "select TABLE_NAME,TABLE_TYPE,TABLE_CATALOG,TABLE_SCHEMA from INFORMATION_SCHEMA.TABLES";
                        SqlDataAdapter wSqlDataAdapter = new SqlDataAdapter(wConmandStr, wConn_SqlServer);
                        lock (wSqlDataAdapter)
                            wSqlDataAdapter.Fill(wDataTable);
                      
                    }
                if (wConn_MySql.ConnectionString != null)
                    if (wConn_MySql.State == System.Data.ConnectionState.Open)
                    {
                        wConmandStr = "SHOW TABLES";
                        MySqlDataAdapter wMySqlDataAdapter = new MySqlDataAdapter(wConmandStr, wConn_MySql);
                        lock (wMySqlDataAdapter)
                            wMySqlDataAdapter.Fill(wDataTable);
                    }

                
            }
            catch (Exception ex)
            {

                wError = ex.ToString();

            }
            return wDataTable;
        }

        public static List<Item> GetSqlFieldNames(SqlConnection wConn_SqlServer, MySqlConnection wConn_MySql,
            string wDataBase, string wTableName, out DataTable wDataValues, out string wError)
        {
            List<Item> wList = null;
            wDataValues = new DataTable();
            wError = "";
            try
            {
                wList = new List<Item>();

                wDataValues.TableName = wTableName;
                string wConmandStr = string.Format("select COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,IS_NULLABLE from information_schema.COLUMNS  where TABLE_NAME = '{0}'", wTableName);
                if (wConn_SqlServer != null)
                    if (wConn_SqlServer.State == System.Data.ConnectionState.Open)
                    {


                        SqlCommand wSqlCommand = new SqlCommand(wConmandStr, wConn_SqlServer);
                        SqlDataReader wSqlDataReader = wSqlCommand.ExecuteReader();
                        while (wSqlDataReader.Read())
                        {
                            Item wField = new Item();
                            wField.Name = wSqlDataReader[0].ToString();
                            wField.Type = wSqlDataReader[1].ToString();
                            wList.Add(wField);

                        }

                        wConn_SqlServer.Close();
                        wConmandStr = string.Format("SELECT  * from {0}", wTableName);
                        SqlDataAdapter wSqlDataAdapter = new SqlDataAdapter(wConmandStr, wConn_SqlServer);
                        lock (wSqlDataAdapter)
                            wSqlDataAdapter.Fill(wDataValues);

                    }
                if (wConn_MySql != null)
                    if (wConn_MySql.State == System.Data.ConnectionState.Open)
                    {
                        wConmandStr += "and TABLE_SCHEMA = " + "'" + wDataBase + "'";

                        MySqlCommand wMySqlCommand = new MySqlCommand(wConmandStr, wConn_MySql);
                        MySqlDataReader wMySqlDataReader = wMySqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        while (wMySqlDataReader.Read())
                        {
                            Item wField = new Item();
                            wField.Name = wMySqlDataReader[0].ToString();
                            wField.Type = wMySqlDataReader[1].ToString();
                            wList.Add(wField);

                        }


                        wConn_MySql.Close();
                        wConmandStr = string.Format("SELECT  * from {0}", wTableName);
                        MySqlDataAdapter wMySqlDataAdapter = new MySqlDataAdapter(wConmandStr, wConn_MySql);
                        lock (wMySqlDataAdapter)
                            wMySqlDataAdapter.Fill(wDataValues);


                    }
            }
            catch (Exception ex)
            {

                wError = ex.ToString();

            }
            return wList;

        }




        public static void GetConnection(SQLType wSQLType, string wDbName, out object wConne, out string wFaultCode)
        {
            wConne = new object();
            wFaultCode = "";
            try
            {
                string wIP = IP;
                string wUserName = UserName;
                string wPassword = Password;

                string wConnstr = "";
                switch (wSQLType)
                {
                    case SQLType.SQLServer:
                        wConnstr = string.Format("Data Source={0};Initial Catalog = {1};User ID = {2};PWD = {3}", wIP, wDbName, wUserName, wPassword);
                        SqlConnection wConn_SqlServer = new SqlConnection(wConnstr);
                        wConne = wConn_SqlServer;
                        break;
                    case SQLType.MySQL:
                        wConnstr = string.Format("server={0};user id={1};password={2};database={3};port={4};pooling=false;charset=utf8", wIP, wUserName, wPassword, "mesbasic", 3306);
                        MySqlConnection wConn_MySql = new MySqlConnection(wConnstr);
                        wConne = wConn_MySql;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                wFaultCode = ex.ToString();
            }


        }


        public static DataTable GetSQLTable(SQLType wSQLType, string wDbName, string wConmandStr, out string wFaultCode)
        {


            object wConn = new object();
            wFaultCode = "";

            DataTable DBNameTable = new DataTable();
            string wConnstr = "";
            try
            {
                switch (wSQLType)
                {
                    case SQLType.SQLServer:
                        wConnstr = string.Format("Data Source={0};Initial Catalog = {1};User ID = {2};PWD = {3}", "192.168.10.251", wDbName, "shrismcis", "shris");
                        SqlConnection wConn_SqlServer = new SqlConnection(wConnstr);

                        SqlDataAdapter wSqlDataAdapter = new SqlDataAdapter();



                        if (wConn_SqlServer.State == System.Data.ConnectionState.Closed)
                            wConn_SqlServer.Open();
                        wSqlDataAdapter = new SqlDataAdapter(wConmandStr, wConn_SqlServer);
                        lock (wSqlDataAdapter)
                        {
                            wSqlDataAdapter.Fill(DBNameTable);
                        }


                        break;
                    case SQLType.MySQL:


                        //wConnstr = string.Format("server={0};user id={1};password={2};database={3}", "192.168.10.251", "root", "shris", wDbName);
                        wConnstr = string.Format("server={0};user id={1};password={2};database={3};port={4};pooling=false;charset=utf8", "192.168.10.164", "root", "shris", "mesbasic", 3306);
                        MySqlConnection wMySqlConnection = new MySqlConnection(wConnstr);
                        wMySqlConnection.Open();
                        //MySqlCommand mysqlcom = new MySqlCommand(wConmandStr, wMySqlConnection);
                        //MySqlDataReader wMySqlDataReader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);

                        if (wMySqlConnection.State == System.Data.ConnectionState.Closed)
                            wMySqlConnection.Open();
                        MySqlDataAdapter wMySqlDataAdapter = new MySqlDataAdapter(wConmandStr, wMySqlConnection);

                        lock (wMySqlDataAdapter)
                        {
                            wMySqlDataAdapter.Fill(DBNameTable);
                        }


                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                wFaultCode = ex.ToString();
            }
            return DBNameTable;
        }




        /// <summary>
        /// 获取数据库名
        /// </summary>
        /// <param name="wError"></param>
        /// <returns></returns>
        public static ArrayList GetSqlDataBaseNames(SQLType wSQLType, out string wError)
        {
            wError = "";
            ArrayList wNames = new ArrayList();

            string wDbName = "master";
            object wConn = new object();


            DataTable DBNameTable = new DataTable();
            string wConmandStr = "select name from master..sysdatabases";

            try
            {
                switch (wSQLType)
                {
                    case SQLType.SQLServer:
                        SqlConnection wConn_SqlServer = new SqlConnection();
                        SqlDataAdapter wSqlDataAdapter = new SqlDataAdapter();

                        GetConnection(wSQLType, wDbName, out  wConn, out  wError);
                        wConn_SqlServer = (SqlConnection)wConn;
                        if (wConn_SqlServer.State == System.Data.ConnectionState.Closed)
                            wConn_SqlServer.Open();
                        wSqlDataAdapter = new SqlDataAdapter(wConmandStr, wConn_SqlServer);
                        lock (wSqlDataAdapter)
                        {
                            wSqlDataAdapter.Fill(DBNameTable);
                        }
                        foreach (DataRow row in DBNameTable.Rows)
                            wNames.Add(row["name"]);
                        wConn_SqlServer.Close();
                        break;
                    case SQLType.MySQL:
                        MySqlConnection wMySqlConnection = new MySqlConnection();
                        GetConnection(wSQLType, wDbName, out  wConn, out  wError);
                        wMySqlConnection = (MySqlConnection)wConn;




                        if (wMySqlConnection.State == System.Data.ConnectionState.Closed)
                            wMySqlConnection.Open();
                        wConmandStr = "SHOW DATABASES";
                        //MySqlCommand mysqlcom = new MySqlCommand(wConmandStr, wMySqlConnection);
                        //MySqlDataReader wMySqlDataReader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);

                        MySqlDataAdapter wMySqlDataAdapter = new MySqlDataAdapter(wConmandStr, wMySqlConnection);

                        lock (wMySqlDataAdapter)
                        {
                            wMySqlDataAdapter.Fill(DBNameTable);
                        }
                        foreach (DataRow row in DBNameTable.Rows)
                            wNames.Add(row[0]);
                        wMySqlConnection.Close();
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                wError = ex.ToString();
            }

            return wNames;
        }


        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="wError"></param>
        /// <returns></returns>
        public static ArrayList GetSqlTableNames(SQLType wSQLType, string wDataBase, out string wError)
        {
            wError = "";

            ArrayList wNames = new ArrayList();
            object wConn = new object();

            DataTable DBNameTable = new DataTable();
            string wConmandStr = "select TABLE_NAME,TABLE_TYPE,TABLE_CATALOG,TABLE_SCHEMA from INFORMATION_SCHEMA.TABLES";

            try
            {

                switch (wSQLType)
                {
                    case SQLType.SQLServer:
                        SqlConnection wConn_SqlServer = new SqlConnection();
                        SqlDataAdapter wSqlDataAdapter = new SqlDataAdapter();

                        GetConnection(wSQLType, wDataBase, out  wConn, out  wError);
                        wConn_SqlServer = (SqlConnection)wConn;
                        if (wConn_SqlServer.State == System.Data.ConnectionState.Closed)
                            wConn_SqlServer.Open();
                        wSqlDataAdapter = new SqlDataAdapter(wConmandStr, wConn_SqlServer);
                        lock (wSqlDataAdapter)
                        {
                            wSqlDataAdapter.Fill(DBNameTable);
                        }

                        foreach (DataRow row in DBNameTable.Rows)
                            wNames.Add(row["TABLE_NAME"]);
                        wConn_SqlServer.Close();
                        break;
                    case SQLType.MySQL:
                        MySqlConnection wMySqlConnection = new MySqlConnection();
                        GetConnection(wSQLType, wDataBase, out  wConn, out  wError);
                        wMySqlConnection = (MySqlConnection)wConn;
                        wConmandStr = "SHOW TABLES";


                        if (wMySqlConnection.State == System.Data.ConnectionState.Closed)
                            wMySqlConnection.Open();
                        MySqlDataAdapter wMySqlDataAdapter = new MySqlDataAdapter(wConmandStr, wMySqlConnection);

                        lock (wMySqlDataAdapter)
                        {
                            wMySqlDataAdapter.Fill(DBNameTable);
                        }
                        foreach (DataRow row in DBNameTable.Rows)
                            wNames.Add(row[0]);
                        wMySqlConnection.Close();
                        break;
                    default:
                        break;
                }




            }
            catch (Exception ex)
            {
                wError = ex.ToString();
            }

            return wNames;
        }


        /// <summary>
        /// 获取字段名
        /// </summary>
        /// <param name="wError"></param>
        /// <returns></returns>
        public static List<Item> GetSqlFieldNames(SQLType wSQLType, string wDataBase, string wTableName, out string wError)
        {

            wError = "";
            List<Item> wNames = null;
            object wConn;
            DataTable DBNameTable;

            string wConmandStr = string.Format("select COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,IS_NULLABLE from information_schema.COLUMNS  where TABLE_NAME = '{0}'", wTableName);
            try
            {

                switch (wSQLType)
                {
                    case SQLType.SQLServer:
                        wConn = new object();
                        wNames = new List<Item>();
                        DBNameTable = new DataTable();
                        SqlConnection wConn_SqlServer = new SqlConnection();
                        SqlDataAdapter wSqlDataAdapter = new SqlDataAdapter();
                        GetConnection(wSQLType, wDataBase, out  wConn, out  wError);
                        wConn_SqlServer = (SqlConnection)wConn;
                        if (wConn_SqlServer.State == System.Data.ConnectionState.Closed)
                            wConn_SqlServer.Open();
                        SqlCommand wSqlCommand = new SqlCommand(wConmandStr, wConn_SqlServer);
                        SqlDataReader wSqlDataReader = wSqlCommand.ExecuteReader();
                        while (wSqlDataReader.Read())
                        {
                            Item wField = new Item();
                            wField.Name = wSqlDataReader[0].ToString();
                            wField.Type = wSqlDataReader[1].ToString();
                            wNames.Add(wField);

                        }
                        wConn_SqlServer.Close();
                        break;
                    case SQLType.MySQL:
                        wConmandStr += "and TABLE_SCHEMA = " + "'" + wDataBase + "'";
                        wConn = new object();
                        wNames = new List<Item>();
                        DBNameTable = new DataTable();
                        MySqlConnection wMySqlConnection = new MySqlConnection();
                        GetConnection(wSQLType, wDataBase, out  wConn, out  wError);
                        wMySqlConnection = (MySqlConnection)wConn;

                        if (wMySqlConnection.State == System.Data.ConnectionState.Closed)
                            wMySqlConnection.Open();


                        MySqlCommand wMySqlCommand = new MySqlCommand(wConmandStr, wMySqlConnection);
                        MySqlDataReader wMySqlDataReader = wMySqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        while (wMySqlDataReader.Read())
                        {
                            Item wField = new Item();
                            wField.Name = wMySqlDataReader[0].ToString();
                            wField.Type = wMySqlDataReader[1].ToString();
                            wNames.Add(wField);

                        }

                        wMySqlConnection.Close();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                wError = ex.ToString();
            }

            return wNames;
        }

        public static List<T> ToListEntity<T>(this System.Data.DataTable dtSource)
        {
            if (dtSource == null)
            {
                return null;
            }

            List<T> list = new List<T>();
            Type type = typeof(T);
            foreach (DataRow dataRow in dtSource.Rows)
            {
                Object entity = Activator.CreateInstance(type);         //创建实例               
                foreach (PropertyInfo entityCols in type.GetProperties())
                {
                    if (!string.IsNullOrEmpty(dataRow[entityCols.Name].ToString()))
                    {
                        entityCols.SetValue(entity, Convert.ChangeType(dataRow[entityCols.Name], entityCols.PropertyType), null);
                    }
                }
                list.Add((T)entity);
            }
            return list;
        }



        public static void CopyData(SQLType wOldSQLType, string wOldconstr, DataTable wOldTable, SQLType wNewSQLType, string wNewconstr, DataTable wNewTable)
        {
            switch (wNewSQLType)
            {

                case SQLType.SQLServer:
                    using (SqlConnection conn = new SqlConnection(wNewconstr))
                    {
                        using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(wNewconstr, SqlBulkCopyOptions.UseInternalTransaction))
                        {
                            try
                            {
                                sqlbulkcopy.DestinationTableName = wNewTable.TableName;

                                for (int i = 0; i < wOldTable.Columns.Count; i++)
                                {
                                    if (wNewTable.Columns.Contains(wOldTable.Columns[i].ColumnName))
                                        sqlbulkcopy.ColumnMappings.Add(wOldTable.Columns[i].ColumnName, wOldTable.Columns[i].ColumnName);
                                }

                                sqlbulkcopy.WriteToServer(wOldTable);
                            }
                            catch (System.Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    break;
                case SQLType.MySQL:
                    //  List<Item> wNewFeilds = new List<Item>();
                    //foreach (string wName in wNewFeildsDic.Keys)
                    //{
                    //    Item wItem = new Item();
                    //    wItem.Name = wName;
                    //    wItem.Type = wNewFeildsDic[wName];
                    //    wNewFeilds.Add(wItem);
                    //}
                    //int rRetrn = BulkInsert(wNewconstr,wNewFeilds, wOldTable);
                    //if (rRetrn < 0)
                    //    return;

                    break;
                default:
                    break;

            }

        }



        /// <summary>
        /// 复制旧表到新表
        /// </summary>
        /// 


        public static void CopyData(DataTable wOldDataTable, string wOldSqlDataBaseName, string wOldSqlTableName,
           SQLType wNewSQLType, string wNewSqlDataBaseName, string wNewSqlTableName, DataTable wNewDataTable, string wNewConn1, out string wError)
        {
            wError = "";

            try
            {

                Dictionary<string, string> wNewFeildsDic = new Dictionary<string, string>();
                foreach (DataColumn wItem in wNewDataTable.Columns)
                {
                    if (!wNewFeildsDic.ContainsKey(wItem.ColumnName))
                        wNewFeildsDic.Add(wItem.ColumnName, wItem.DataType.Name);
                }

                SqlBulkCopyByDatatable(wNewSQLType, wNewConn1, wNewSqlTableName, wOldDataTable, wNewFeildsDic);
            }
            catch (Exception ex)
            {

                wError = ex.ToString();
            }
        }




        private static void SqlBulkCopyByDatatable(SQLType wNewSQLType, string NewconnectionString,
            string wNewTableName, DataTable wOldDataTable, Dictionary<string, string> wNewFeildsDic)
        {
            switch (wNewSQLType)
            {

                case SQLType.SQLServer:
                    using (SqlConnection conn = new SqlConnection(NewconnectionString))
                    {
                        using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(NewconnectionString,SqlBulkCopyOptions.UseInternalTransaction))
                        {
                            try
                            {
                                sqlbulkcopy.DestinationTableName = wNewTableName;

                                for (int i = 0; i < wOldDataTable.Columns.Count; i++)
                                {
                                    if (wNewFeildsDic.ContainsKey(wOldDataTable.Columns[i].ColumnName))
                                        sqlbulkcopy.ColumnMappings.Add(wOldDataTable.Columns[i].ColumnName, wOldDataTable.Columns[i].ColumnName);
                                }

                                sqlbulkcopy.WriteToServer(wOldDataTable);
                            }
                            catch (System.Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    break;
                case SQLType.MySQL:
                    List<Item> wNewFeilds = new List<Item>();
                    foreach (string wName in wNewFeildsDic.Keys)
                    {
                        Item wItem = new Item();
                        wItem.Name = wName;
                        wItem.Type = wNewFeildsDic[wName];
                        wNewFeilds.Add(wItem);
                    }
                    int rRetrn = BulkInsert(NewconnectionString,wNewFeilds, wOldDataTable);
                    if (rRetrn < 0)
                        return;

                    break;
                default:
                    break;

            }

        }




        private static string DataTableToCsv(DataTable wOldTable, List<Item> wNewTableFeilds)
        {




            List<string> wNewColumns = new List<string>();
            Dictionary<string, string> wNewDic = new Dictionary<string, string>();
            foreach (Item wItem in wNewTableFeilds)
            {
                wNewDic.Add(wItem.Name, wItem.Type);
                wNewColumns.Add(wItem.Name);
            }

            Dictionary<string, string> wOldDic = new Dictionary<string, string>();
            DataColumn colum;
            for (int i = 0; i < wOldTable.Columns.Count; i++)
            {
                colum = wOldTable.Columns[i];
                wOldDic.Add(colum.ColumnName, "");

            }



            List<string> wValues;
            //循环OldTable,取一行

            string wValuestr = "";
            foreach (DataRow row in wOldTable.Rows)
            {
                wValues = new List<string>();
                //对比NewTbale,字段相同，填Value,不相同，Null
                foreach (string wFeildName in wNewDic.Keys)
                {
                    if (wOldDic.ContainsKey(wFeildName))
                    {
                        colum = wOldTable.Columns[wFeildName];
                        wValues.Add(row[colum].ToString());
                    }
                    else
                    {

                        wValues.Add("");

                    }
                }
                wValuestr += string.Join(",", wValues) + "\r\n";
            }

            return wValuestr;






        }



        /// <summary>
        /// 获取相同列的数据.Csv
        /// </summary>
        /// <param name="wOldTable">旧表</param>
        /// <param name="wNewTable">新表</param>
        /// <returns>旧表中相同列的数据str</returns>
        private static string DataTableToCsv(DataTable wOldTable, DataTable wNewTable)
        {
            string wResult = "";
            try
            {
                //获取相同列
                List<DataColumn> wColumns = new List<DataColumn>();
                foreach (DataColumn wColumn in wNewTable.Columns)
                {
                    if (wOldTable.Columns.Contains(wColumn.ColumnName))
                        wColumns.Add(wColumn);
                }

                //取到相同列的数据
                foreach (DataRow wRow in wOldTable.Rows)
                {
                    List<string> wValues = new List<string>();


                    foreach (DataColumn wDataColumn in wColumns)
                        wValues.Add(wRow[wDataColumn.ColumnName].ToString());
                    wResult += string.Join(",", wValues) + "\r\n";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return wResult;

        }

 


        /// <summary>
        /// 将旧表复制到新表
        /// </summary>
        /// <param name="wOldDataTable"></param>
        /// <param name="wNewDataTable"></param>
        /// <param name="wNewSQLType"></param>
        /// <param name="NewconnectionString"></param>
        /// <param name="wError"></param>
        public static void SqlBulkCopyByDatatable(DataTable wOldDataTable, DataTable wNewDataTable,
            SQLType wNewSQLType, string NewconnectionString, out string wError)
        {
            wError = "";
            try
            {
                switch (wNewSQLType)
                {

                    case SQLType.SQLServer:
                        #region SQLServer
                        using (SqlConnection conn = new SqlConnection(NewconnectionString))
                        {
                            using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(NewconnectionString, SqlBulkCopyOptions.UseInternalTransaction))
                            {
                                try
                                {
                                    sqlbulkcopy.DestinationTableName = wNewDataTable.TableName;
                                    for (int i = 0; i < wOldDataTable.Columns.Count; i++)
                                    {
                                        if (wNewDataTable.Columns.Contains(wOldDataTable.Columns[i].ColumnName))
                                            sqlbulkcopy.ColumnMappings.Add(wOldDataTable.Columns[i].ColumnName, wOldDataTable.Columns[i].ColumnName);
                                    }
                                    sqlbulkcopy.WriteToServer(wOldDataTable);
                                }
                                catch (System.Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        #endregion
                        break;
                    case SQLType.MySQL:
                        #region MySQL
                        if (string.IsNullOrEmpty(wOldDataTable.TableName))
                        {
                            wError = "请给wOldDataTable的TableName属性附上表名称";
                            return;
                        }
                        if (string.IsNullOrEmpty(wNewDataTable.TableName))
                        {
                            wError = "请给wNewDataTable的TableName属性附上表名称";
                            return;
                        }
                        if (wOldDataTable.Rows.Count == 0)
                        {
                            wError = "请给wOldDataTable没有数据";
                            return;
                        }
                        string tmpPath = Path.GetTempFileName();
                        string csv = DataTableToCsv(wOldDataTable, wNewDataTable);
                        File.WriteAllText(tmpPath, csv);
                        //MySqlTransaction tran = null;

                        using (MySqlConnection conn = new MySqlConnection(NewconnectionString))
                        {
                            try
                            {
                                MySqlConnection con = new MySqlConnection(NewconnectionString);
                                if (con != null && con.State != ConnectionState.Open)
                                    con.Open();
                                MySqlBulkLoader bulkLoader = new MySqlBulkLoader(con);
                                bulkLoader.TableName = wOldDataTable.TableName;//插入的表的名字
                                bulkLoader.FieldTerminator = ",";//字段间的间隔方式，为逗号
                                bulkLoader.FieldQuotationCharacter = '"';
                                bulkLoader.EscapeCharacter = '"';
                                bulkLoader.LineTerminator = "\r\n";
                                bulkLoader.NumberOfLinesToSkip = 1;
                                bulkLoader.FileName = tmpPath;
                                bulkLoader.Load();

                            }
                            catch (MySqlException ex)
                            {
                                wError = ex.ToString();
                                return;
                            }
                        }
                        File.Delete(tmpPath);
                       #endregion

                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {

                wError = ex.ToString();
            }
           

        }

        public static int BulkInsert(string NewconnectionString, List<Item> wNewTableFeilds, DataTable wOldTable)
        {

            if (string.IsNullOrEmpty(wOldTable.TableName)) throw new Exception("请给DataTable的TableName属性附上表名称");
            if (wOldTable.Rows.Count == 0) return 0;
            int insertCount = 0;
            string tmpPath = Path.GetTempFileName();

            string wError = "";
            //获取NewTable
            ////List<Item> wNewTableFeilds = GetSqlFieldNames(SQLType.MySQL, "mesbasic", wOldTable.TableName, out  wError);
            ////if (wError.Length > 0)
            ////    return -1;
            string csv = DataTableToCsv(wOldTable, wNewTableFeilds);
            File.WriteAllText(tmpPath, csv);
            MySqlTransaction tran = null;

            using (MySqlConnection conn = new MySqlConnection(NewconnectionString))
            {

                try
                {



                    MySqlConnection con = new MySqlConnection(NewconnectionString);
                    if (con != null && con.State != ConnectionState.Open)
                        con.Open();
                    MySqlBulkLoader bulkLoader = new MySqlBulkLoader(con);
                    bulkLoader.TableName = wOldTable.TableName;//插入的表的名字
                    bulkLoader.FieldTerminator = ",";//字段间的间隔方式，为逗号
                    bulkLoader.FieldQuotationCharacter = '"';
                    bulkLoader.EscapeCharacter = '"';
                    bulkLoader.LineTerminator = "\r\n";

                    bulkLoader.NumberOfLinesToSkip = 1;
                    bulkLoader.FileName = tmpPath;

                    bulkLoader.Load();

                }
                catch (MySqlException ex)
                {
                    if (tran != null) tran.Rollback();
                    throw ex;
                }
            }
            File.Delete(tmpPath);
            return insertCount;
        }


    }
    public class Item
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
    public class Test
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int OwnerID { get; set; }
        public string Explain { get; set; }

        public string Active { get; set; }

        public DateTime CreateTime { get; set; }
    }

    public enum SQLType
    {
        SQLServer = 0,
        MySQL = 1
    }
}
