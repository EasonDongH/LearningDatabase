using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace MSTest
{
    public class MySQLHelper
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ToString();

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
            catch (MySqlException e)
            {
                if (e.Number == 1451)
                {
                    throw new Exception("该数据已被引用，无法直接删除！");
                }
                throw e;
            }
            catch (Exception e)
            {
                throw e;
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
                throw ex;
            }
        }

        public static MySqlDataReader GetDataReader(string sql, MySqlParameter[] parameters=null)
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
                throw ex;
            }
        }
    }
}
