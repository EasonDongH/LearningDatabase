using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Models;


namespace DAL
{
    public class StudentClassService
    {
        public List<StudentClass> GetAllClasses()
        {
            string sql = "select className,classId from StudentClass";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentClass> list = new List<StudentClass>();
            while (objReader.Read())
            {
                list.Add(new StudentClass()
                    {
                        ClassId = Convert.ToInt32(objReader["ClassId"]),
                        ClassName = objReader["ClassName"].ToString()
                    });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 获取所有的班级（存放在数据集里面）
        /// </summary>
        /// <returns></returns>

        public DataSet GetAllClass()
        {

            string sql = "select ClassId,ClassName from StudentClass";
            return SQLHelper.GetDataSet(sql);
        }
    }
}
