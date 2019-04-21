using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;

namespace SinoLogi.SupplyChain.SCIOrder.Web
{
    public static class SQLHelper
    {
       static string connString = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
        public static int AddDeleteModify(string sql)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand(sql, conn);
            conn.Open();
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("调用AddDeleteModify(string sql)错误。" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static object GetSingle(string sql)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand(sql, conn);
            conn.Open();
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("调用GetSingle(string sql)错误。" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static OracleDataReader GetReader(string sql)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand(sql, conn);
            conn.Open();
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("调用GetReader(string sql)错误。" + ex.Message);
            }
        }
        
        //读取到dataset中
        public static DataSet GetDataSet(string sql, string path)
        {
            OracleConnection conn = new OracleConnection(string.Format(connString,path));
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public static DataSet GetDataSet(string sql)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool UpdateByTran(List<string> sqlList)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();
                foreach (string itemSql in sqlList)
                {
                    cmd.CommandText = itemSql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction!=null)
                {
                    cmd.Transaction.Rollback();
                    throw ex;                    
                }
                return false;
            }
        }
        public static int UpdateByPro(string spName,OracleParameter[] param)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand(spName,conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;//声明当前操作是存储过程
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {              
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool UpdateByTranPro(string procedureName, List<OracleParameter[]> paramArray)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;//声明当前操作是调用存储过程
                cmd.Transaction = conn.BeginTransaction();//开启事务
                cmd.CommandText = procedureName;
                foreach (OracleParameter[] param in paramArray)
                {
                    cmd.Parameters.Clear();//必须要清除以前的参数
                    cmd.Parameters.AddRange(param);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();//回滚事务                 
                    
                    throw ex;
                }
                return false;
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;//清空事务
                }
                conn.Close();
            }
        }


    }
}