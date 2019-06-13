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

        public static IDbConnection Conn
        {
            get { return new MySqlConnection(connString); }
        }

        public static bool Update(string sql, MySqlParameter[] parameters = null)
        {
            int cmd_result = 0;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd_result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return cmd_result > 0;
        }

        public static object GetSingleResult(string sql, MySqlParameter[] parameters = null)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return null;
        }

        public static MySqlDataReader GetDataReader(string sql, MySqlParameter[] parameters = null)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return null;
        }
    }
}
