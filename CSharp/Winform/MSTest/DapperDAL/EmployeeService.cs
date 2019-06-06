using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Models;
using IDAL;
using MySql.Data.MySqlClient;
using Dapper;
using static Dapper.SimpleCRUD;

namespace DapperDAL
{
    public class EmployeeService : IEmployeeService
    {
        public bool AddEmployee(Employee employee)
        {
            int isjob = employee.IsJob ? 1 : 0;
            string sql = "INSERT INTO ms_employee(Id,DepartmentId,EmployeeNo,EmployeeName,EmployeeSex,EmployeeBirth,IsJob,Remarks)";
            sql += $" VALUES(@Id,@DepartmentId,@EmployeeNo,@EmployeeName,@EmployeeSex,@EmployeeBirth,@IsJob,@Remarks);";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int insert_Result = conn.Execute(sql, employee);
                return insert_Result > 0;
            }
        }

        public bool CheckEmployeeNoIsExist(string employeeNo)
        {
            string sql = $"SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo =@employeeNo;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int select_Result = conn.Execute(sql, new { employeeNo = employeeNo });
                return select_Result > 0;
            }
        }

        public bool CheckEmployeeNoIsExist(string employeeNo, string id)
        {
            string sql = $"SELECT COUNT(*) FROM ms_employee WHERE EmployeeNo = @employeeNo AND Id <> @id;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int select_Result = conn.Execute(sql, new { employeeNo = employeeNo, id = id });
                return select_Result > 0;
            }
        }

        public bool DeleteEmployeeByNo(string employeeNo)
        {
            string sql = $"DELETE FROM ms_employee WHERE EmployeeNo=@employeeNo;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int delete_Result = conn.Execute(sql, new { employeeNo = employeeNo });
                return delete_Result > 0;
            }
        }

        public List<Employee> FuzzyQueryEmployeesByEmployeeName(string name)
        {
            StringBuilder sql = new StringBuilder("SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex");
            sql.Append(",e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append($" WHERE EmployeeName like @name");
            sql.Append(";");

            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                return conn.Query<Employee>(sql.ToString(), new { name = name }).ToList();
            }
        }

        public List<Employee> FuzzyQueryEmployeesByEmployeeNo(string no)
        {
            StringBuilder sql = new StringBuilder("SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex");
            sql.Append(",e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e");
            sql.Append(" INNER JOIN ms_department d ON d.Id = e.DepartmentId");
            sql.Append($" WHERE EmployeeNo like @no");
            sql.Append(";");

            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                return conn.Query<Employee>(sql.ToString(), new { no = no }).ToList();
            }

        }

        public List<Employee> GetEmployees()
        {
            string sql = "SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex,e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e";
            sql += " INNER JOIN ms_department d ON d.Id = e.DepartmentId;";

            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                return conn.Query<Employee>(sql).ToList();
            }
        }

        public Employee GetSpecifyEmployeeByEmployeeNo(string no)
        {
            string sql = "SELECT e.Id,e.DepartmentId,d.DepartmentName,e.EmployeeNo,e.EmployeeName,e.EmployeeSex,e.EmployeeBirth,e.IsJob,e.Remarks FROM ms_employee e";
            sql += " INNER JOIN ms_department d ON d.Id = e.DepartmentId";
            sql += $" WHERE EmployeeNo = @no;";

            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                return conn.Query<Employee>(sql, new { no = no }).SingleOrDefault();
            }
        }

        public bool ModfiyEmployeeInfo(Employee employee)
        {
            // 报语法错误
            //int isJob = employee.IsJob ? 1 : 0;
            //StringBuilder sql = new StringBuilder("UPDATE  ms_employee SET");
            //sql.Append($" DepartmentId=@DepartmentId");
            //sql.Append($" ,EmployeeNo=@EmployeeNo',EmployeeName=@EmployeeName");
            //sql.Append($" ,EmployeeSex=@EmployeeSex,EmployeeBirth=@EmployeeBirth");
            //sql.Append($" ,IsJob=@IsJob,Remarks=@Remarks");
            //sql.Append($" WHERE Id=@Id");
            //sql.Append(";");
            //using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            //{
            //    int modify_Result = conn.Execute(sql.ToString(), new {
            //        DepartmentId = employee.DepartmentId, EmployeeNo = employee.EmployeeNo,
            //        EmployeeName = employee.EmployeeName, EmployeeSex = employee.EmployeeSex,
            //        EmployeeBirth = employee.EmployeeBirth, IsJob = isJob, Remarks = employee.Remarks,
            //        Id = employee.Id});
            //    return modify_Result != 0;
            //}

            int isJob = employee.IsJob ? 1 : 0;
            StringBuilder sql = new StringBuilder("UPDATE  ms_employee SET");
            sql.Append($" DepartmentId='{employee.DepartmentId}'");
            sql.Append($" ,EmployeeNo='{employee.EmployeeNo}',EmployeeName='{employee.EmployeeName}'");
            sql.Append($" ,EmployeeSex='{employee.EmployeeSex}',EmployeeBirth='{employee.EmployeeBirth}'");
            sql.Append($" ,IsJob={isJob},Remarks='{employee.Remarks}'");
            sql.Append($" WHERE Id='{employee.Id}'");
            sql.Append(";");

            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int modify_Result = conn.Execute(sql.ToString());
                return modify_Result != 0;
            }
        }

    }
}