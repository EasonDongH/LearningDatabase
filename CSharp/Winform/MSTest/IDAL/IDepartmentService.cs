using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using MySql.Data.MySqlClient;

namespace IDAL
{
    public interface IDepartmentService
    {
        #region 增
        bool AddDepartment(Department department);

        #endregion

        #region 删
         bool DeleteDepartmentByNo(string no);

        #endregion

        #region 改

         bool ModifyDepartmentInfo(Department department);

        #endregion

        #region 查

        /// <summary>
        /// 查询给定的部门编号是否存在
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <returns>true：已存在 false：未存在</returns>
         bool CheckDepartmentNoIsExist(string departmentNo);

        /// <summary>
        /// 查询给定的部门编号，除当前部门外，是否存在
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <param name="id"></param>
        /// <returns>true：已存在 false：未存在</returns>
         bool CheckDepartmentNoIsExist(string departmentNo, string id);

         List<Department> FuzzyQueryDepartmentsByDepartmentNo(string departmentNo);

         List<Department> FuzzyQueryDepartmentsByDepartmentName(string departmentName);

         List<Department> GetDepartments();
       
        #endregion

    }
}
