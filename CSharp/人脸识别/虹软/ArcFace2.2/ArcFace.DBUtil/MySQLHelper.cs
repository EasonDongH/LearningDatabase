using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ArcFace.DBUtil
{
    public class MySQLHelper
    {
        public static string ConnString = "server=localhost;user id=root;password=shensu;database=vopdface;charset=utf8";

        private static void SetDBType()
        {
            Dapper.SimpleCRUD.SetDialect(Dapper.SimpleCRUD.Dialect.MySQL);
        }

        static MySQLHelper()
        {
            SetDBType();
        }

        public static IDbConnection Conn
        {
            get { return new MySqlConnection(ConnString); }
        }
    }
}
