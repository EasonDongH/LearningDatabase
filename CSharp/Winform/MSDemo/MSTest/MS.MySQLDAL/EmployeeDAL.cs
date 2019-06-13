using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using log4net;
using MS.Models;
using MS.DBUtil;
using MySql.Data.MySqlClient;

namespace MS.MySQLDAL
{
    public class EmployeeDAL
    {
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region 增

        public bool AddEmployee(EmployeeModel employee)
        {
            int isjob = employee.IsJob ? 1 : 0;
            string sql = "INSERT INTO ms_employee(Id,DepartmentId,EmployeeNo,EmployeeName,EmployeeSex,EmployeeBirth,IsJob,Remarks)";
            sql += string.Format(" VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}');",employee.Id, employee.DepartmentId,employee.EmployeeNo,employee.EmployeeName,employee.EmployeeSex,employee.EmployeeBirth,isjob,employee.Remarks);
            bool add_Result = false;
            try
            {
                add_Result = MySQLHelper.Update(sql);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return add_Result;
        }
        #endregion

        #region 删

        public bool DeleteEmployeeByNo(string no)
        {
            string sql = string.Format("DELETE FROM ms_employee WHERE EmployeeNo='{0}';",no);
            return MySQLHelper.Update(sql);
        }
        #endregion

        #region 改

        public bool ModfiyEmployeeInfo(EmployeeModel employee)
        {
            int isJob = employee.IsJob ? 1 : 0;
            StringBuilder sql = new StringBuilder("UPDATE  ms_employee SET");
            sql.Append(string.Format(" DepartmentId='{0}'",employee.DepartmentId));
            sql.Append(string.Format(" ,EmployeeNo='{0}',EmployeeName='{1}'",employee.EmployeeNo,employee.EmployeeName));
            sql.Append(string.Format(" ,EmployeeSex='{0}',EmployeeBirth='{1}'",employee.EmployeeSex,employee.EmployeeBirth));
            sql.Append(string.Format(" ,IsJob={0},Remarks='{1}'",isJob,employee.Remarks));
            sql.Append(string.Format(" WHERE Id='{0}'",employee.Id));
            sql.Append(";");

            return MySQLHelper.Update(sql.ToString());
        }
        #endregion

        #region 查
        private List<EmployeeModel> GetEmployeesCommonMethod(string sql, MySqlParameter[] parameters = null)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
                MySqlDataReader objReader = MySQLHelper.GetDataReader(sql, parameters);
                while (objReader.Read())
                {
                    employees.Add(new EmployeeModel
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
                log.Error(ex);
            }

            return employees;
        }

        public EmployeeModel GetSpecifyEmployeeByEmployeeNo(string no)
        {
            string sql = "SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex,e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e";
            sql += " INNER JOIN ms_department d ON d.Id = e.DepartmentId";
            sql += string.Format(" WHERE EmployeeNo = '{0}';",no);

            var list = GetEmployeesCommonMethod(sql);
            return list.Count() != 0 ? list[0] : null;
        }

        /// <summary>
        /// 根据员工编号进行模糊查询
        /// 模糊条件：%no%
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public List<EmployeeModel> FuzzyQueryEmployeesByEmployeeNo(string no)
        {
            StringBuilder sql = new StringBuilder("SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex");
            sql.Append(",e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append(string.Format(" WHERE EmployeeNo like '{0}'",no));
            sql.Append(";");

            return GetEmployeesCommonMethod(sql.ToString());
        }

        /// <summary>
        /// 根据员工姓名进行模糊查询
        /// 模糊条件：%name%
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<EmployeeModel> FuzzyQueryEmployeesByEmployeeName(string name)
        {
            StringBuilder sql = new StringBuilder("SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex");
            sql.Append(",e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append(string.Format(" WHERE EmployeeName like '{0}'",name));
            sql.Append(";");

            return GetEmployeesCommonMethod(sql.ToString());
        }

        /// <summary>
        /// 获取全部员工
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployees()
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
            string sql = string.Format("SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo = '{0}';",employeeNo);
            int query_Result = 1; // 默认值取>0
            try
            {
                query_Result = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
            string sql = string.Format("SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo = '{0}' AND Id <> '{1}';", employeeNo, id);
            int query_Result = 1; // 默认值取>0
            try
            {
                query_Result = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return query_Result > 0;
        }

        public string GetIdByNo(string no)
        {
            string sql = string.Format("SELECT Id FROM ms_employee WHERE EmployeeNo='{0}'", no);
            string id = null;
            try
            {
                object obj = MySQLHelper.GetSingleResult(sql);
                if(obj != null)
                    id = obj.ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return id;
        }
        #endregion

    }
}
