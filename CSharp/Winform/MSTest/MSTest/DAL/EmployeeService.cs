using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace MSTest
{
    public class EmployeeService
    {
        #region 增

        public bool AddEmployee(Employee employee)
        {
            int isjob = employee.IsJob ? 1 : 0;
            string sql = "INSERT INTO ms_employee(Id,DepartmentId,EmployeeNo,EmployeeName,EmployeeSex,EmployeeBirth,IsJob,Remarks)";
            sql += $" VALUES('{employee.Id}','{ employee.DepartmentId}','{employee.EmployeeNo}','{employee.EmployeeName}','{employee.EmployeeSex}','{employee.EmployeeBirth}',{isjob},'{employee.Remarks}');";
            bool add_Result = false;
            try
            {
                add_Result = MySQLHelper.Update(sql);
            }
            catch (Exception e)
            {
                throw e;
            }

            return add_Result;
        }
        #endregion

        #region 删

        public bool DeleteEmployeeByNo(string no)
        {
            string sql = $"DELETE FROM ms_employee WHERE EmployeeNo='{no}';";
            return MySQLHelper.Update(sql);
        }
        #endregion

        #region 改

        public bool ModfiyEmployeeInfo(Employee employee)
        {
            int isJob = employee.IsJob ? 1 : 0;
            StringBuilder sql = new StringBuilder("UPDATE  ms_employee SET");
            sql.Append($" DepartmentId='{employee.DepartmentId}'");
            sql.Append($" ,EmployeeNo='{employee.EmployeeNo}',EmployeeName='{employee.EmployeeName}'");
            sql.Append($" ,EmployeeSex='{employee.EmployeeSex}',EmployeeBirth='{employee.EmployeeBirth}'");
            sql.Append($" ,IsJob={isJob},Remarks='{employee.Remarks}'");
            sql.Append($" WHERE Id='{employee.Id}'");
            sql.Append(";");

            return MySQLHelper.Update(sql.ToString());
        }
        #endregion

        #region 查
        private List<Employee> GetEmployeesCommonMethod(string sql, MySqlParameter[] parameters = null)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                MySqlDataReader objReader = MySQLHelper.GetDataReader(sql, parameters);
                while (objReader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = objReader["Id"].ToString(),
                        DepartmentId = objReader["DepartmentId"].ToString(),
                        DepartmentName = objReader["DepartmentName"].ToString(),
                        EmployeeNo = objReader["EmployeeNo"].ToString(),
                        EmployeeName = objReader["EmployeeName"].ToString(),
                        EmployeeSex = objReader["EmployeeSex"].ToString(),
                        EmployeeBirth = Convert.ToDateTime(objReader["EmployeeBirth"]).ToString("yyyy-MM-dd"),
                        IsJob = Convert.ToInt32(objReader["IsJob"]) == 1 ? true : false,
                        Remarks = objReader["Remarks"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employees;
        }

        public Employee GetSpecifyEmployeeByEmployeeNo(string no)
        {
            string sql = "SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex,e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e";
            sql += " INNER JOIN ms_department d ON d.Id = e.DepartmentId";
            sql += $" WHERE EmployeeNo = '{no}';";

            var list = GetEmployeesCommonMethod(sql);
            return list.Count() != 0 ? list[0] : null;
        }

        /// <summary>
        /// 根据员工编号进行模糊查询
        /// 模糊条件：%no%
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public List<Employee> FuzzyQueryEmployeesByEmployeeNo(string no)
        {
            StringBuilder sql = new StringBuilder("SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex");
            sql.Append(",e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append($" WHERE EmployeeNo like '{no}'");
            sql.Append(";");

            return GetEmployeesCommonMethod(sql.ToString());
        }

        /// <summary>
        /// 根据员工姓名进行模糊查询
        /// 模糊条件：%name%
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Employee> FuzzyQueryEmployeesByEmployeeName(string name)
        {
            StringBuilder sql = new StringBuilder("SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex");
            sql.Append(",e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append($" WHERE EmployeeName like '{name}'");
            sql.Append(";");

            return GetEmployeesCommonMethod(sql.ToString());
        }

        /// <summary>
        /// 获取全部员工
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            StringBuilder sql = new StringBuilder("SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName");
            sql.Append(",e.EmployeeSex,e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId;");

            return GetEmployeesCommonMethod(sql.ToString());
        }

        /// <summary>
        /// 查询给定的员工编号是否存在
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckEmployeeNoIsExist(string employeeNo)
        {
            string sql = $"SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo = '{employeeNo}';";
            int query_Result = 1; // 默认值取>0
            try
            {
                query_Result = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return query_Result != 0;
        }

        /// <summary>
        /// 查询给定的员工编号，除当前员工外，是否存在
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="id"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckEmployeeNoIsExist(string employeeNo, string id)
        {
            string sql = $"SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo = '{employeeNo}' AND Id <> '{id}';";
            int query_Result = 1; // 默认值取>0
            try
            {
                query_Result = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return query_Result != 0;
        }
        #endregion

    }
}
