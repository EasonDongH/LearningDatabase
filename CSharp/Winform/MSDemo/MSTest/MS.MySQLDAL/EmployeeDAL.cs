using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using log4net;
using Dapper;
using MS.Models;
using MS.DBUtil;
using MySql.Data.MySqlClient;

namespace MS.MySQLDAL
{
    public class EmployeeDAL
    {
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private IDbConnection Conn
        {
            get { return MySQLHelper.Conn; }
        }
        #region 增
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmployee(EmployeeModel employee)
        {
            StringBuilder sql = new StringBuilder("INSERT INTO ms_employee(Id,DepartmentId,EmployeeNo,EmployeeName,EmployeeSex,EmployeeBirth,IsJob,Remarks)");
            sql.Append(" VALUES(@Id,@DepartmentId,@EmployeeNo,@EmployeeName,@EmployeeSex,@EmployeeBirth,@IsJob,@Remarks);");
            int add_Result = 0;
            try
            {
                using (this.Conn)
                {
                    add_Result = this.Conn.Execute(sql.ToString(), employee);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return add_Result;
        }
        #endregion

        #region 删
        /// <summary>
        /// 根据Id（主键），删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEmployeeById(string id)
        {
            int delete_Result = 0;
            EmployeeModel model = new EmployeeModel();
            model.Id = id;
            try
            {
                using (this.Conn)
                {
                    delete_Result = this.Conn.Delete(model);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return delete_Result;
        }
        /// <summary>
        /// 根据员工编号（唯一键），删除员工
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <returns></returns>
        public int DeleteEmployeeByNo(string employeeNo)
        {
            int delete_Result = 0;
            string sql = "DELETE FROM ms_employee WHERE EmployeeNo=@EmployeeNo;";
            try
            {
                using (this.Conn)
                {
                    delete_Result = this.Conn.Execute(sql, new { EmployeeNo = employeeNo });
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return delete_Result;
        }
        #endregion

        #region 改
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int ModfiyEmployeeInfo(EmployeeModel employee)
        {
            int modify_Result = 0;
            try
            {
                using (this.Conn)
                {
                    modify_Result = this.Conn.Update(employee);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return modify_Result;
        }
        #endregion

        #region 查
        /// <summary>
        /// 获取全部员工
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployees()
        {
            StringBuilder sql = new StringBuilder("SELECT * FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d");
            sql.Append(" ON d.Id = e.DepartmentId;");

            List<EmployeeModel> models = new List<EmployeeModel>();
            try
            {
                using (this.Conn)
                {
                    models = this.Conn.Query<EmployeeModel, DepartmentModel, EmployeeModel>(sql.ToString(), (employee, dp) =>
                        {
                            employee.DepartmentName = dp.DepartmentName;
                            employee.CorrespondingDepartment = dp;
                            return employee;
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return models;
        }
        /// <summary>
        /// 根据员工编号（唯一键），查询员工
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <returns></returns>
        public EmployeeModel GetSpecifyEmployeeByEmployeeNo(string employeeNo)
        {
            StringBuilder sql = new StringBuilder("SELECT");
            sql.Append(" e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex,e.EmployeeBirth,e.IsJob,e.Remarks");
            sql.Append(" ,d.Id, d.DepartmentNo, d.DepartmentName, d.Remarks");
            sql.Append(" FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append(" WHERE EmployeeNo = @EmployeeNo;");
            EmployeeModel model = null;
            try
            {
                using (this.Conn)
                {
                    model = this.Conn.Query<EmployeeModel, DepartmentModel, EmployeeModel>(sql.ToString(), (employee, dp) =>
                    {
                        employee.CorrespondingDepartment = dp;
                        return employee;
                    }, new { EmployeeNo = employeeNo }, splitOn: "Id").SingleOrDefault();
                    /* splitOn：从查询的字段列表最后向前，到splitOn指定的第一个列名，映射到最后一张表
                     * 接着到splitOn指定的第二个列名，映射到最后第二张表，以此类推
                     * splitOn:"列名1，列名2，..."
                     */
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return model;
        }
        /// <summary>
        /// 根据员工编号进行模糊查询
        /// 模糊条件：%no%
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public List<EmployeeModel> FuzzyQueryEmployeesByEmployeeNo(string employeeNo)
        {
            StringBuilder sql = new StringBuilder("SELECT * FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append(" WHERE EmployeeNo like @EmployeeNo");
            sql.Append(";");
            List<EmployeeModel> models = new List<EmployeeModel>();
            try
            {
                using (this.Conn)
                {
                    models = this.Conn.Query<EmployeeModel, DepartmentModel, EmployeeModel>(sql.ToString(), (employee, dp) =>
                    {
                        employee.DepartmentName = dp.DepartmentName;
                        return employee;
                    }, new { EmployeeNo = employeeNo }).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return models;
        }

        /// <summary>
        /// 根据员工姓名进行模糊查询
        /// 模糊条件：%name%
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<EmployeeModel> FuzzyQueryEmployeesByEmployeeName(string employeeName)
        {
            StringBuilder sql = new StringBuilder("SELECT * FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append(" WHERE EmployeeName like @EmployeeName");
            sql.Append(";");
            List<EmployeeModel> models = new List<EmployeeModel>();
            try
            {
                using (this.Conn)
                {
                    models = this.Conn.Query<EmployeeModel, DepartmentModel, EmployeeModel>(sql.ToString(), (employee, dp) =>
                    {
                        employee.DepartmentName = dp.DepartmentName;
                        return employee;
                    }, new { EmployeeName = employeeName }).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return models;
        }
        /// <summary>
        /// 检查Id（主键）是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true：已存在 false：不存在</returns>
        public bool CheckIdIsExist(string id)
        {
            bool result = true;
            try
            {
                using (this.Conn)
                {
                    EmployeeModel model = this.Conn.Get<EmployeeModel>(id);
                    result = model != null;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 查询给定的员工编号是否存在
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckEmployeeNoIsExist(string employeeNo)
        {
            string sql = "SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo = @EmployeeNo;";
            int query_Result = 1; // 默认值取>0
            try
            {
                using (this.Conn)
                {
                    query_Result = this.Conn.ExecuteScalar<int>(sql, new { EmployeeNo = employeeNo });
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
            string sql = "SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo = @EmployeeNo AND Id <> @Id;";
            int query_Result = 1; // 默认值取>0
            try
            {
                using (this.Conn)
                {
                    query_Result = this.Conn.ExecuteScalar<int>(sql, new { EmployeeNo = employeeNo, Id = id });
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
            return query_Result > 0;
        }

        public string GetIdByNo(string employeeNo)
        {
            string id = null;
            EmployeeModel model = null;
            string sql = string.Format("SELECT * FROM ms_employee WHERE EmployeeNo = @EmployeeNo");
            try
            {
                using (this.Conn)
                {
                    model = this.Conn.Query<EmployeeModel>(sql, new { EmployeeNo = employeeNo }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            if (model != null)
                id = model.Id;
            return id;
        }
        #endregion

    }
}
