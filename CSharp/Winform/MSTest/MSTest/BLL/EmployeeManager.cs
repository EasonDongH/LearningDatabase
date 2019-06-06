using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using IDAL;

namespace MSTest
{
    public class EmployeeManager
    {
        #region 全局变量
        // private EmployeeService objEmployeeService = new EmployeeService();
        private  IEmployeeService objEmployeeService = DALFactory.CreateService<IEmployeeService>("EmployeeService");
        #endregion

        #region 增

        public bool AddEmployee(Employee employee)
        {
            employee.Id = CommonMethod.GetGUID();
            return objEmployeeService.AddEmployee(employee);
        }
        #endregion

        #region 删

        public bool DeleteEmployeeByNo(string no)
        {
            return this.objEmployeeService.DeleteEmployeeByNo(no);
        }
        #endregion

        #region 改
        public bool ModfiyEmployeeInfo(Employee employee)
        {
            return this.objEmployeeService.ModfiyEmployeeInfo(employee);
        }
        #endregion

        #region 查
        private List<Employee> SortByDNoThenENo(List<Employee> employees)
        {
            return (from e in employees orderby e.DepartmentId, e.EmployeeNo select e).ToList();
        }

        public List<Employee> GetEmployees()
        {
            return SortByDNoThenENo(this.objEmployeeService.GetEmployees());
        }

        /// <summary>
        /// 分情况进行查询
        /// 情况1：condition为空，查询全部数据
        /// 情况2：
        /// 按queryMode分类
        /// 1. 为0，按员工编号查询
        /// 2. 为1，按员工名称查询
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="queryMode"></param>
        /// <returns></returns>
        public List<Employee> GetEmployees(string condition, int queryMode)
        {
            List<Employee> employees = null;
            if (condition == string.Empty)
            {
                employees = this.objEmployeeService.GetEmployees();
            }
            else
            {
                string queryCondition = "%" + condition + "%";
                switch (queryMode)
                {
                    case 0:
                        employees = this.objEmployeeService.FuzzyQueryEmployeesByEmployeeNo(queryCondition);
                        break;
                    case 1:
                        employees = this.objEmployeeService.FuzzyQueryEmployeesByEmployeeName(queryCondition);
                        break;
                }
            }
            return SortByDNoThenENo(employees);
        }

        public Employee GetSpecifyEmployeeByEmployeeNo(string no)
        {
            return this.objEmployeeService.GetSpecifyEmployeeByEmployeeNo(no);
        }


        /// <summary>
        /// 查询给定的员工编号是否存在
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckEmployeeNoIsExist(string employeeNo)
        {
            return this.objEmployeeService.CheckEmployeeNoIsExist(employeeNo);
        }

        /// <summary>
        /// 查询给定的员工编号，除当前员工外，是否存在
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="id"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckEmployeeNoIsExist(string employeeNo, string id)
        {
            return this.objEmployeeService.CheckEmployeeNoIsExist(employeeNo, id);
        }
        #endregion

    }
}
