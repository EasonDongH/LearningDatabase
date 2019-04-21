using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class StudentService
    {
        /// <summary>
        /// 分页查询学员信息
        /// </summary>
        /// <param name="pageSize">每页显示的条数</param>
        /// <param name="birthday">出生日期（查询条件）</param>
        /// <param name="currentPage">当前页码</param>
        /// <param name="recordsCount">返回的记录总数</param>
        /// <returns>返回记录列表</returns>
        public List<Student> GetPagedData(int pageSize, DateTime birthday, int currentPage, out int recordsCount)
        {
            //需要过滤的总数
            int filterCount = pageSize * (currentPage - 1);
            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PageSize",pageSize ),
                new SqlParameter ("@Birthday",birthday ),
                new SqlParameter ("@filterCount",filterCount)
            };
            //执行查询
            SqlDataReader objReader = DAL.SQLHelper.GetReader("usp_DataPager", param);
            //封装返回结果
            List<Student> list = new List<Student>();
            while (objReader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    PhoneNumber = objReader["PhoneNumber"].ToString()
                });
            }
            recordsCount = 0;
            if (objReader.NextResult())
            {
                if (objReader.Read())//返回记录总数
                    recordsCount = Convert.ToInt32(objReader["recordsCount"]);            
            }
            objReader.Close();
            return list;  //返回数据列表
        }
    }
}
