using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using ArcFace.Models;
using ArcFace.DBUtil;

namespace ArcFace.DAL
{
    public class FaceSampleDAL
    {
        private IDbConnection Conn
        {
            get { return MySQLHelper.Conn; }
        }

        public int Add(FaceSampleModel model)
        {
            StringBuilder sql = new StringBuilder("INSERT INTO face_sample(id, childno, barcode, childname, childsex, childbirth, mothername, sampledata, sampleorient, sampleface, familykind, clienttype, clientname, usercode, username, status, createtime, updatetime, sampledataver)");
            sql.Append(" VALUES(@id, @childno, @barcode, @childname, @childsex, @childbirth, @mothername, @sampledata, @sampleorient, @sampleface, @familykind, @clienttype, @clientname, @usercode, @username, @status, @createtime, @updatetime, @sampledataver)");
            sql.Append(";");
            int add_Result = 0;
            try
            {
                using (this.Conn)
                {
                    add_Result = this.Conn.Execute(sql.ToString(), model);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return add_Result;
        }

        public IEnumerable<FaceSampleModel> GetList(string ver)
        {
            IEnumerable<FaceSampleModel> models = new List<FaceSampleModel>();
            try
            {
                using (this.Conn)
                {
                    models = this.Conn.GetList<FaceSampleModel>();
                }
            }
            catch (Exception)
            {

            }

            return models;
        }

        public IEnumerable<FaceSampleModel> GetAllSampleInfo(string ver)
        {
            string sql = "SELECT id, sampledata, sampleface FROM face_sample WHERE sampledataver <> @ver;";
            IEnumerable<FaceSampleModel> models = new List<FaceSampleModel>();
            try
            {
                using (this.Conn)
                {
                    models = this.Conn.Query<FaceSampleModel>(sql, new { ver = ver }); ;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return models;
        }

        public IEnumerable<FaceSampleModel> GetAllSampleInfo()
        {
            string sql = "SELECT id, sampledata, sampleface FROM face_sample;";
            IEnumerable<FaceSampleModel> models = new List<FaceSampleModel>();
            try
            {
                using (this.Conn)
                {
                    models = this.Conn.Query<FaceSampleModel>(sql); ;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return models;
        }

        public int GetNeedUpdateAmount(decimal version)
        {
            int query_Result = 0;
            string sql = "SELECT COUNT(*) FROM face_sample WHERE sampledataver<>@version;";
            try
            {
                using (this.Conn)
                {
                    query_Result = Convert.ToInt32(this.Conn.ExecuteScalar(sql, new { version = version }));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return query_Result;
        }
        /// <summary>
        /// 获取分页数据
        /// 该方法仅返回id、childno、sampleface三个字段
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<FaceSampleModel> GetPagingData(int startIndex, int num)
        {
            //string sql = "SELECT id, childno, sampleface FROM face_sample WHERE sampledataver < @ver LIMIT @StartIndex, @Num;";
            string sql = "SELECT id, childno, sampleface FROM face_sample LIMIT @StartIndex, @Num;";
            IEnumerable<FaceSampleModel> enumerable = new List<FaceSampleModel>();
            try
            {
                using (this.Conn)
                {
                    enumerable = this.Conn.Query<FaceSampleModel>(sql, new { StartIndex = startIndex, Num = num });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return enumerable;
        }

        /// <summary>
        /// 批量更新
        /// 该方法仅更新sampledata、sampledataver两个字段
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int Update(List<FaceSampleModel> models)
        {
            int update_Result = 0;
            string sql = "UPDATE face_sample SET sampledata=@sampledata, sampledataver=@sampledataver WHERE id=@id;";
            try
            {
                using (this.Conn)
                {
                    update_Result = this.Conn.Execute(sql, models);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return update_Result;
        }

        public int Update(FaceSampleModel model)
        {
            int update_Result = 0;
            string sql = "UPDATE face_sample SET sampledata=@sampledata, sampledataver=@sampledataver WHERE id=@id;";
            try
            {
                using (this.Conn)
                {
                    update_Result = this.Conn.Execute(sql, model);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return update_Result;
        }
    }
}
