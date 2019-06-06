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
    public class DepartmentService : IDepartmentService
    {
        #region 增

        public bool AddDepartment(Department department)
        {
            string sql = "INSERT INTO ms_department(Id,DepartmentNo,DepartmentName,Remarks) VALUES(@Id,?DepartmentNo,@DepartmentName,@Remarks);";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int insert_Result = conn.Execute(sql, department);
                return insert_Result > 0;
            }
        }
        #endregion

        #region 删

        public bool DeleteDepartmentByNo(string no)
        {
            string sql = $"DELETE FROM ms_department WHERE DepartmentNo=@no;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int delete_Result = conn.Execute(sql, new { no = no });
                return delete_Result > 0;
            }
        }

        #endregion

        #region 改

        public bool ModifyDepartmentInfo(Department department)
        {
            string sql = $"UPDATE ms_department SET DepartmentNo=@DepartmentNo,DepartmentName=@DepartmentName,Remarks=@Remarks where Id=@Id;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int modify_Result = conn.Execute(sql, department);
                return modify_Result > 0;
            }
        }
        #endregion

        #region 查

        public bool CheckDepartmentNoIsExist(string departmentNo)
        {
            string sql = "SELECT COUNT(*) FROM ms_department WHERE DepartmentNo=@DepartmentNo;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int select_Result = conn.Execute(sql, new { DepartmentNo = departmentNo });
                return select_Result > 0;
            }
        }

        public bool CheckDepartmentNoIsExist(string departmentNo, string id)
        {
            string sql = "SELECT COUNT(*) FROM ms_department WHERE DepartmentNo=?DepartmentNo AND Id <> ?Id ;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                int select_Result = conn.Execute(sql, new { DepartmentNo = departmentNo, Id = id });
                return select_Result != 0;
            }
        }

        public List<Department> FuzzyQueryDepartmentsByDepartmentName(string departmentName)
        {
            string sql = $"SELECT Id,DepartmentNo,DepartmentName,Remarks FROM ms_department WHERE DepartmentName like @DepartmentName;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                return conn.Query<Department>(sql, new { DepartmentName = departmentName }).ToList();
            }
        }

        public List<Department> FuzzyQueryDepartmentsByDepartmentNo(string departmentNo)
        {
            string sql = $"SELECT Id,DepartmentNo,DepartmentName,Remarks FROM ms_department WHERE DepartmentNo like @DepartmentNo;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                return conn.Query<Department>(sql, new { DepartmentNo = departmentNo }).ToList();
            }
        }

        public List<Department> GetDepartments()
        {
            string sql = $"SELECT Id,DepartmentNo,DepartmentName,Remarks FROM ms_department;";
            using (IDbConnection conn = new MySqlConnection(MySQLHelper.ConnectionString))
            {
                return conn.Query<Department>(sql).ToList();
            }
        }
        #endregion

    }
}