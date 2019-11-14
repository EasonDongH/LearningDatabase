using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Ext;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AttendanceService
    {
        /// <summary>
        /// 添加打卡记录
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string AddRecord(string cardNo)
        {
            string sql = "insert into Attendance (CardNo) values('{0}')";
            sql = string.Format(sql, cardNo);
            try
            {
                SQLHelper.Update(sql);
                return "success";
            }
            catch (Exception ex)
            {
                return "打卡失败！系统出现问题，请联系管理员！" + ex.Message;
            }
        }
        /// <summary>
        /// 获取学员总数
        /// </summary>
        /// <returns></returns>
        public string GetAllStudents()
        {
            string sql = "select count(*) from Students";
            try
            {
                return SQLHelper.GetSingleResult(sql).ToString();
            }
            catch (Exception ex)
            {
                return "暂时无法获取学员总数！" + ex.Message;
            }
        }
        /// <summary>
        /// 按照指定日期查询当天已签到的学员总数
        /// </summary>
        /// <param name="dt">查询的时间</param>
        /// <param name="isToday">是否是当天</param>
        /// <returns></returns>
        public string GetAttendStudents(DateTime dt, bool isToday)
        {
            DateTime dt1;
            if (isToday)//如果是当天，则直接获取服务器的时间
            {
                dt1 = Convert.ToDateTime(SQLHelper.GetServerTime().ToShortDateString());
            }
            else
            {
                dt1 = dt;
            }
            DateTime dt2 = dt1.AddDays(1.0);//将当天时间加上一天
            string sql = "select count(distinct CardNo)  from Attendance where DTime between '{0}' and '{1}'";
            sql = string.Format(sql, dt1, dt2);
            try
            {
                return SQLHelper.GetSingleResult(sql).ToString();
            }
            catch (Exception ex)
            {
                return "暂时无法获取已签到的学员总数！" + ex.Message;
            }
        }
        /// <summary>
        /// 根据时间和姓名查询考勤
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<StudentExt> GetStuByDate(DateTime beginDate, DateTime endDate, string name)
        {
            string sql = "select StudentId,StudentName,Gender,DTime,ClassName,Attendance.CardNo from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " inner join Attendance on Students.CardNo=Attendance.CardNo";
            sql += " where DTime between '{0}' and '{1}'";
            sql = string.Format(sql, beginDate, endDate);
            if (name != null && name.Length != 0)
            {
                sql += string.Format(" and StudentName='{0}'", name);
            }         
            sql += " Order By DTime ASC";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (objReader.Read())
            {
                list.Add(new StudentExt()
                    {
                        StudentId = Convert.ToInt32(objReader["StudentId"]),
                        StudentName = objReader["StudentName"].ToString(),
                        Gender = objReader["Gender"].ToString(),
                        CardNo = objReader["CardNo"].ToString(),
                        ClassName = objReader["ClassName"].ToString(),
                        DTime = Convert.ToDateTime(objReader["DTime"])
                    });
            }
            return list;

        }
    }
}
