using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Models;

namespace DAL.Helper
{
    /// <summary>
    /// 从Excel中导入数据
    /// </summary>
    public class ImportDataFromExcel
    {
        /// <summary>
        /// 从Excel文件中读取数据
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentByExcel(string path)
        {
            List<Student> list = new List<Student>();
            DataSet ds = OleDbHelper.GetDataSet("select * from [Student$] ", path);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Student()
                    {
                        StudentName = row["姓名"].ToString(),
                        Gender = row["性别"].ToString(),
                        Birthday = Convert.ToDateTime(row["出生日期"]),
                        Age = DateTime.Now.Year - Convert.ToDateTime(row["出生日期"]).Year,
                        CardNo = row["考勤卡号"].ToString(),
                        StudentIdNo = row["身份证号"].ToString(),
                        PhoneNumber = row["电话号码"].ToString(),
                        StudentAddress = row["家庭住址"].ToString(),
                        ClassId = Convert.ToInt32(row["班级编号"])
                    });
            }
            return list;
        }
        /// <summary>
        /// 将集合中的对象插入到数据库
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Import(List<Student> list)
        {
            List<string> sqlList = new List<string>();
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(studentName,Gender,Birthday,");
            sqlBuilder.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId)");
            sqlBuilder.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8})");
            foreach (Student objStudent in list)
            {
                string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday,
                    objStudent.StudentIdNo, objStudent.Age,
                    objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo,
                    objStudent.ClassId);
                sqlList.Add(sql);
            }
            return SQLHelper.UpdateByTran(sqlList);
        }
    }
}
