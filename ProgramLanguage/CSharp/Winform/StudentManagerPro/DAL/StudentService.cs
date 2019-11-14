using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;
using Models.Ext;

namespace DAL
{
    public class StudentService
    {

        #region  添加学员对象

        /// <summary>
        /// 判断身份证号是否已经存在
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo)
        {
            string sql = "select count(*) from Students where StudentIdNo=" + studentIdNo;
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 判断卡号是否已经存在
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool IsCardNoExisted(string cardNo)
        {
            string sql = string.Format("select count(*) from Students where CardNo='{0}'", cardNo);
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 添加学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int AddStudent(Student objStudent)
        {
            //string sql1 = "insert into Students(studentName,Gender,Birthday,";
            //sql1 += "StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId,StuImage)";
            //sql1 += " values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},'{9}')";
            //【1】编写SQL语句         
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(studentName,Gender,Birthday,");
            sqlBuilder.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId,StuImage)");
            sqlBuilder.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},'{9}');select @@Identity");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
                    objStudent.StudentIdNo, objStudent.Age,
                    objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo,
                    objStudent.ClassId, objStudent.StuImage);
            try
            {
                return Convert.ToInt32(SQLHelper.GetSingleResult(sql)); //【3】执行SQL语句，返回结果
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 查询学员信息

        /// <summary>
        /// 根据班级查询学员信息
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentByClass(string className)
        {
            string sql = "select StudentId,StudentName,Gender,PhoneNumber,StudentIdNo,Birthday,ClassName from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " where ClassName='{0}'";
            sql= string.Format(sql, className);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (objReader.Read())
            {
                list.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 根据学生编号查询学生信息
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentExt GetStudentById(string studentId)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,";
            sql += "StudentIdNo,PhoneNumber,StudentAddress,CardNo,StuImage from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " where StudentId=" + studentId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            StudentExt objStudent = null;
            if (objReader.Read())
            {
                objStudent = new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    CardNo = objReader["CardNo"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    StuImage = objReader["StuImage"] == null ? "" : objReader["StuImage"].ToString()
                };
            }
            objReader.Close();
            return objStudent;
            // string whereSql = string.Format(" where StudentId={0}", studentId);
            //    return this.GetStudent(whereSql);


        }

        /// <summary>
        /// 根据卡号查询学生信息（请思考如何将两个方法合并）
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public StudentExt GetStudentByCardNo(string CardNo)
        {
            string whereSql = string.Format(" where CardNo='{0}'", CardNo);
            return this.GetStudent(whereSql);
        }
        //内部私有方法
        private StudentExt GetStudent(string whereSql)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,";
            sql += "StudentIdNo,PhoneNumber,StudentAddress,CardNo,StuImage from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += whereSql;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            StudentExt objStudent = null;
            if (objReader.Read())
            {
                objStudent = new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    CardNo = objReader["CardNo"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    StuImage = objReader["StuImage"] == null ? "" : objReader["StuImage"].ToString()
                };
            }
            objReader.Close();
            return objStudent;
        }

        #endregion

        #region 修改学员信息

        /// <summary>
        /// 修改学员时判断身份证号是否和其他学员的重复
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string idNo, string studentId)
        {
            string sql = "select count(*) from Students where StudentIdNo=" + idNo + " and StudentId<>" + studentId;
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 修改学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int ModifyStudent(Student objStudent)
        {   //【1】编写SQL语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Students set studentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlBuilder.Append(
                "StudentIdNo={3},Age={4},PhoneNumber='{5}',StudentAddress='{6}',CardNo='{7}',ClassId={8},StuImage='{9}'");
            sqlBuilder.Append(" where StudentId={10}");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
                    objStudent.StudentIdNo, objStudent.Age,
                    objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo,
                    objStudent.ClassId, objStudent.StuImage, objStudent.StudentId);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));    //【3】执行SQL语句，返回结果
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除学员对象

        public int DeleteStudentById(string studentId)
        {
            string sql = "delete from Students where StudentId=" + studentId;
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该学号被其他实体引用，不能直接删除该学员对象！");
                else
                    throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// 删除学员对象
        ///// </summary>
        ///// <param name="objStudent"></param>
        ///// <returns></returns>
        //public int DeleteStudent(Student objStudent)
        //{
        //    string sql = "delete from Students where StudentId=" + objStudent.StudentId;
        //    try
        //    {
        //        return SQLHelper.Update(sql);
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (ex.Number == 547)
        //            throw new Exception("该学号被其他实体引用，不能直接删除该学员对象！");
        //        else
        //            throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

    }
}
