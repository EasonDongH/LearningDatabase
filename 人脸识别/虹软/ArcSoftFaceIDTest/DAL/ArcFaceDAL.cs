using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using DBUtil;
using Model;
using log4net;
using System.Reflection;

namespace DAL
{
    public class ArcFaceDAL
    {
        private static ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private IDbConnection Conn
        {
            get { return SQLiteHepler.Conn; }
        }

        public int Insert(ArcFaceModel model)
        {
            int result = 0;
            string sql = "INSERT INTO arcface(id, faceimage, faceindex, facefeature) VALUES(@id, @faceimage, @faceindex, @facefeature);";
            try
            {
                using (this.Conn)
                {
                    result = this.Conn.Execute(sql, model);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            return result;
        }

        public IEnumerable<ArcFaceModel> GetList()
        {
            IEnumerable<ArcFaceModel> result = null;
            try
            {
                using (this.Conn)
                {
                    result = this.Conn.GetList<ArcFaceModel>();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            return result;
        }
    }
}
