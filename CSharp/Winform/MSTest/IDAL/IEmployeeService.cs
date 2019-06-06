using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using MySql.Data.MySqlClient;

namespace IDAL
{
    public interface IEmployeeService
    {
        #region 增

        bool AddEmployee(Employee employee);

        #endregion

        #region 删

        bool DeleteEmployeeByNo(string no);

        #endregion

        #region 改

        bool ModfiyEmployeeInfo(Employee employee);

        #endregion

        #region 查
        Employee GetSpecifyEmployeeByEmployeeNo(string no);

        /// <summary>
        /// 根据员工编号进行模糊查询
        /// 模糊条件：%no%
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        List<Employee> FuzzyQueryEmployeesByEmployeeNo(string no);

        /// <summary>
        /// 根据员工姓名进行模糊查询
        /// 模糊条件：%name%
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Employee> FuzzyQueryEmployeesByEmployeeName(string name);

        /// <summary>
        /// 获取全部员工
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployees();

        /// <summary>
        /// 查询给定的员工编号是否存在
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <returns>true：已存在 false：未存在</returns>
        bool CheckEmployeeNoIsExist(string employeeNo);

        /// <summary>
        /// 查询给定的员工编号，除当前员工外，是否存在
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="id"></param>
        /// <returns>true：已存在 false：未存在</returns>
        bool CheckEmployeeNoIsExist(string employeeNo, string id);
        #endregion
    }
}
