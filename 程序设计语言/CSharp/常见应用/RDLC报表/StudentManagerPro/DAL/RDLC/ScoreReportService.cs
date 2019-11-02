using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class ScoreReportService
    {
        /// <summary>
        ///根据班级查询成绩信息
        /// </summary>
        /// <param name="className">班级名称</param>
        /// <returns></returns>
        public List<ScoreReport> GetSCoreList(string className)
        {
            string sql = "select Students.StudentId,StudentName,ClassName,Gender,PhoneNumber,CSharp,SQLServerDB from Students";
            sql += " inner join StudentClass on StudentClass.ClassId=Students.ClassId ";
            sql += " inner join ScoreList on ScoreList.StudentId=Students.StudentId ";
            if (className != null && className.Length != 0)
            {
                sql += " where ClassName='" + className + "'";
            }
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<ScoreReport> list = new List<ScoreReport>();
            while (objReader.Read())
            {
                list.Add(new ScoreReport()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    CSharp = Convert.ToInt32(objReader["CSharp"]),
                    SQLServerDB = Convert.ToInt32(objReader["SQLServerDB"]),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
    }
}
