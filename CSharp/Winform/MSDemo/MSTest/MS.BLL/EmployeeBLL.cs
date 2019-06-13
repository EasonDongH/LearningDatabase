using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MS.Models;
using MS.Base;
using MS.MySQLDAL;

namespace MS.BLL
{
    public class EmployeeBLL
    {
        #region 全局变量
        private EmployeeDAL objEmployeeDAL = new EmployeeDAL();
        #endregion

        public bool UpdateEmployee(OperateMode opm,EmployeeModel employee)
        {
            bool update_Result = false;
            switch (opm)
            {
                case OperateMode.Add:
                    employee.Id = CommonMethod.GetGUID();
                    update_Result = this.objEmployeeDAL.AddEmployee(employee);
                    break;
                case OperateMode.Modify:
                    update_Result = this.objEmployeeDAL.ModfiyEmployeeInfo(employee);
                    break;
            }
            return update_Result;
        }

        #region 删

        public bool DeleteEmployeeByNo(string no)
        {
            return this.objEmployeeDAL.DeleteEmployeeByNo(no);
        }
        #endregion

        #region 查
        private List<EmployeeModel> SortByDNoThenENo(List<EmployeeModel> employees)
        {
            return (from e in employees orderby e.DepartmentId, e.EmployeeNo select e).ToList();
        }

        public List<EmployeeModel> GetEmployees()
        {
            return SortByDNoThenENo(this.objEmployeeDAL.GetEmployees());
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
        public List<EmployeeModel> GetEmployees(int queryMode, string condition)
        {
            List<EmployeeModel> employees = null;

            string queryCondition = "%" + condition + "%";
            switch (queryMode)
            {
                case 0:
                    employees = this.objEmployeeDAL.GetEmployees();
                    break;
                case 1:
                    employees = this.objEmployeeDAL.FuzzyQueryEmployeesByEmployeeNo(queryCondition);
                    break;
                case 2:
                    employees = this.objEmployeeDAL.FuzzyQueryEmployeesByEmployeeName(queryCondition);
                    break;
            }
            return SortByDNoThenENo(employees);
        }

        public EmployeeModel GetSpecifyEmployeeByEmployeeNo(string no)
        {
            return this.objEmployeeDAL.GetSpecifyEmployeeByEmployeeNo(no);
        }


        public bool CheckEmployeeNoIsExist(string employeeNo, EmployeeModel employee)
        {
            if (employee == null)
                return this.objEmployeeDAL.CheckEmployeeNoIsExist(employeeNo);
            else
                return this.objEmployeeDAL.CheckEmployeeNoIsExist(employeeNo, employee.Id);
        }

        #endregion

    }
}
