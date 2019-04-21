using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models.Ext;
using Models;

namespace DAL
{
    public class ScoreListService
    {

        #region 获取全部考试的考试综合信息

        /// <summary>
        /// 获取全部考试的考试综合信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetScoreInfo()
        {
            string sql = "select stuCount=count(*),avgCSharp=avg(CSharp),avgDB=avg(SQLServerDB) from ScoreList;";
            sql += "select absectCount=count(*) from Students where StudentId not in(select StudentId from ScoreList)";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            Dictionary<string, string> scoreInfo = null;
            if (objReader.Read())
            {
                scoreInfo = new Dictionary<string, string>();
                scoreInfo.Add("stuCount", objReader["stucount"].ToString());
                scoreInfo.Add("avgCSharp", objReader["avgCSharp"].ToString());
                scoreInfo.Add("avgDB", objReader["avgDB"].ToString());
            }
            if (objReader.NextResult())
            {
                if (objReader.Read())
                {
                    scoreInfo.Add("absectCount", objReader["absectCount"].ToString());
                }
            }
            objReader.Close();
            return scoreInfo;
        }
        /// <summary>
        /// 获取未参加考试的学生名单
        /// </summary>
        /// <returns></returns>
        public List<string> GetAbsentList()
        {
            string sql = "select StudentName from Students where StudentId not in(select StudentId from ScoreList)";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<string> list = new List<string>();
            while (objReader.Read())
            {
                list.Add(objReader["StudentName"].ToString());
            }
            objReader.Close();
            return list;
        }

        #endregion

        #region 按照班级统计考试信息

        public Dictionary<string, string> GetScoreInfoByClassId(string classId)
        {
            string sql = "select stuCount=count(*),avgCSharp=avg(CSharp),avgDB=avg(SQLServerDB) from ScoreList ";
            sql += "inner join Students on Students.StudentId=ScoreList.StudentId where ClassId={0};";
            sql += "select absentCount=count(*) from Students where StudentId not in";
            sql += "(select StudentId from ScoreList) and ClassId={1}";
            sql = string.Format(sql, classId, classId);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            Dictionary<string, string> scoreInfo = null;
            if (objReader.Read())//读取考试成绩统计结果
            {
                scoreInfo = new Dictionary<string, string>();
                scoreInfo.Add("stuCount", objReader["stucount"].ToString());
                scoreInfo.Add("avgCSharp", objReader["avgCSharp"].ToString());
                scoreInfo.Add("avgDB", objReader["avgDB"].ToString());
            }
            if (objReader.NextResult())//读取缺考人数列表
            {
                if (objReader.Read())
                {
                    scoreInfo.Add("absentCount", objReader["absentCount"].ToString());
                }
            }
            objReader.Close();
            return scoreInfo;
        }
        /// <summary>
        /// 查询未参加考试的学生名单
        /// </summary>
        /// <returns></returns>
        public List<string> GetAbsentListByClassId(string classId)
        {
            string sql = "select StudentName from Students where StudentId not in ";
            sql += "(select StudentId from ScoreList) and ClassId={0}";
            sql = string.Format(sql, classId);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<string> list = new List<string>();
            while (objReader.Read())
            {
                list.Add(objReader["StudentName"].ToString());
            }
            objReader.Close();
            return list;
        }

        #endregion

        #region 查询考试成绩

        /// <summary>
        /// 查询考试成绩
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        //public List<StudentExt> GetSCoreList(string className)
        //{
        //    string sql = "select Students.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB from Students";
        //    sql += " inner join StudentClass on StudentClass.ClassId=Students.ClassId ";
        //    sql += " inner join ScoreList on ScoreList.StudentId=Students.StudentId ";
        //    if (className != null && className.Length != 0)
        //    {
        //        sql += " where ClassName='" + className + "'";
        //    }
        //    SqlDataReader objReader = SQLHelper.GetReader(sql);
        //    List<StudentExt> list = new List<StudentExt>();
        //    while (objReader.Read())
        //    {
        //        list.Add(new StudentExt()
        //        {
        //            StudentId = Convert.ToInt32(objReader["StudentId"]),
        //            StudentName = objReader["StudentName"].ToString(),
        //            ClassName = objReader["ClassName"].ToString(),
        //            Gender = objReader["Gender"].ToString(),
        //            PhoneNumber = objReader["PhoneNumber"].ToString(),
        //            CSharp = objReader["CSharp"].ToString(),
        //            SQLServerDB = objReader["SQLServerDB"].ToString(),
        //            cc=false
        //        });
        //    }
        //    objReader.Close();
        //    return list;
        //}

        public List<ExtStudent> GetSCoreList(string className)
        {
            string sql = "select Students.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB from Students";
            sql += " inner join StudentClass on StudentClass.ClassId=Students.ClassId ";
            sql += " inner join ScoreList on ScoreList.StudentId=Students.StudentId ";
            if (className != null && className.Length != 0)
            {
                sql += " where ClassName='" + className + "'";
            }
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<ExtStudent> list = new List<ExtStudent>();
            while (objReader.Read())
            {

                list.Add(new ExtStudent()
                {
                    ObjStudent = new Student()
                    {
                        StudentId = Convert.ToInt32(objReader["StudentId"]),
                        StudentName = objReader["StudentName"].ToString(),

                        Gender = objReader["Gender"].ToString(),
                        PhoneNumber = objReader["PhoneNumber"].ToString(),
                    },
                    ObjScore=new ScoreList()
                    {
                        CSharp =Convert .ToInt32( objReader["CSharp"]),
                        SQLServerDB =Convert .ToInt32( objReader["SQLServerDB"]),
                    },
                    ClassName = objReader["ClassName"].ToString(),
                  
                    cc = false
                });
            }
            objReader.Close();
            return list;
        }

        #endregion

        #region 数据集DataSet的使用

        /// <summary>
        /// 获取所有的学员成绩列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllScoreList()
        {
            string sql = "select Students.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB";
            sql += " from Students";
            sql += " inner join StudentClass on StudentClass.ClassId=Students.ClassId ";
            sql += " inner join ScoreList on ScoreList.StudentId=Students.StudentId ";
            return SQLHelper.GetDataSet(sql);
        }


        #endregion
    }
}
