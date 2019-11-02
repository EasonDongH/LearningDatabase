using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

using log4net;
using Dapper;
using MySql.Data.MySqlClient;

using MS.Base;

namespace MS.DBUtil
{
    public class MySQLHelper
    {
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ToString();

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
            get 
            {
                return new MySqlConnection(connString); 
            }
        }
    }
}
