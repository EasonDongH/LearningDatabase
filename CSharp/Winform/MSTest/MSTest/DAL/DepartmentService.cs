using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace MSTest
{
    public class DepartmentService
    {
        #region 增
        public bool AddDepartment(Department department)
        {
            string sql = "INSERT INTO ms_department(Id,DepartmentNo,DepartmentName,Remarks) VALUES(?Id,?DepartmentNo,?DepartmentName,?Remarks);";
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("?Id", department.Id),
                    new MySqlParameter("?DepartmentNo", department.DepartmentNo),
                    new MySqlParameter("?DepartmentName", department.DepartmentName),
                    new MySqlParameter("?Remarks", department.Remarks)
                };
            bool add_Result = false;
            try
            {
                add_Result = MySQLHelper.Update(sql, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }

            return add_Result;
        }
        #endregion

        #region 删
        public bool DeleteDepartmentByNo(string no)
        {
            string sql = $"DELETE FROM ms_department WHERE DepartmentNo='{no}';";
            return MySQLHelper.Update(sql);
        }
        #endregion

        #region 改

        public bool ModifyDepartmentInfo(Department department)
        {
            string sql = $"UPDATE ms_department SET DepartmentNo='{department.DepartmentNo}',DepartmentName='{department.DepartmentName}',Remarks='{department.Remarks}' where Id='{department.Id}';";
            return MySQLHelper.Update(sql);
        }
        #endregion

        #region 查

        /// <summary>
        /// 查询给定的部门编号是否存在
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckDepartmentNoIsExist(string departmentNo)
        {
            string sql = "SELECT COUNT(*) FROM ms_department WHERE DepartmentNo=?DepartmentNo;";
            MySqlParameter[] parameters = new MySqlParameter[] {
                new MySqlParameter("?DepartmentNo",departmentNo)
            };
            try
            {
                int result = Convert.ToInt32(MySQLHelper.GetSingleResult(sql, parameters));
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询给定的部门编号，除当前部门外，是否存在
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <param name="id"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckDepartmentNoIsExist(string departmentNo, string id)
        {
            string sql = "SELECT COUNT(*) FROM ms_department WHERE DepartmentNo=?DepartmentNo AND Id <> ?Id ;";
            MySqlParameter[] parameters = new MySqlParameter[] {
                new MySqlParameter("?DepartmentNo",departmentNo),
                new MySqlParameter("?Id", id)
            };
            try
            {
                int result = Convert.ToInt32(MySQLHelper.GetSingleResult(sql, parameters));
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Department> GetDepartmetsCommonMethod(string sql, MySqlParameter[] parameters = null)
        {
            List<Department> departments = new List<Department>();
            try
            {
                MySqlDataReader objReader = MySQLHelper.GetDataReader(sql, parameters);
                while (objReader.Read())
                {
                    departments.Add(new Department
                    {
                        Id = objReader["Id"].ToString(),
                        DepartmentNo = objReader["DepartmentNo"].ToString(),
                        DepartmentName = objReader["DepartmentName"].ToString(),
                        Remarks = objReader["Remarks"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return departments;
        }

        public List<Department> FuzzyQueryDepartmentsByDepartmentNo(string departmentNo)
        {
            string sql = $"SELECT Id,DepartmentNo,DepartmentName,Remarks FROM ms_department WHERE DepartmentNo like '{departmentNo}';";
            return GetDepartmetsCommonMethod(sql);
        }

        public List<Department> FuzzyQueryDepartmentsByDepartmentName(string departmentName)
        {
            string sql = $"SELECT Id,DepartmentNo,DepartmentName,Remarks FROM ms_department WHERE DepartmentName like '{departmentName}';";
            return GetDepartmetsCommonMethod(sql);
        }

        public List<Department> GetDepartments()
        {
            string sql = "SELECT Id,DepartmentNo,DepartmentName,Remarks FROM ms_department;";
            return GetDepartmetsCommonMethod(sql);
        }
        #endregion

    }
}
