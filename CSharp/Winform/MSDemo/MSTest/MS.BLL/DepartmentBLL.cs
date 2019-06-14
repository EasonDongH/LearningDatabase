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
    public class DepartmentBLL
    {
        #region 全局变量
        private DepartmentDAL objDepartmentDAL = new DepartmentDAL();
        #endregion

        #region 增、改

        public bool UpdateDepartment(OperateMode opm, DepartmentModel department)
        {
            int update_Result = 0;
            switch (opm)
            {
                case OperateMode.Add:
                    department.Id = CommonMethod.GetGUID();
                    update_Result = this.objDepartmentDAL.AddDepartment(department);
                    break;
                case OperateMode.Modify:
                    update_Result = this.objDepartmentDAL.ModifyDepartmentInfo(department);
                    break;
            }
            return update_Result > 0;
        }
        #endregion

        #region 删
        public bool DeleteDepartmentByNo(string no)
        {
            return this.objDepartmentDAL.DeleteDepartmentByNo(no) > 0;
        }
        #endregion

        #region 查
        private List<DepartmentModel> SortByDepartmentNo(List<DepartmentModel> departments)
        {
            return departments.OrderBy(dp => dp.DepartmentNo).ToList();
        }

        public List<DepartmentModel> GetDepartments()
        {
            return SortByDepartmentNo(this.objDepartmentDAL.GetDepartments());
        }

        public DepartmentModel GetSpecifyDepartmentByDepartmentNo(string no)
        {
            return this.objDepartmentDAL.GetSpecifyDepartmentByDepartmentNo(no);
        }

        /// <summary>
        /// 根据querymode进行条件查询
        /// 0：根据部门编号查询
        /// 1：根据部门名称查询
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="queryMode"></param>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartments(int queryMode, string condition)
        {
            List<DepartmentModel> departments = null;
            string queryCondition = "%" + condition + "%";
            switch (queryMode)
            {
                case 0:
                    departments = this.objDepartmentDAL.GetDepartments();
                    break;
                case 1:
                    departments = this.objDepartmentDAL.FuzzyQueryDepartmentsByDepartmentNo(queryCondition);
                    break;
                case 2:
                    departments = this.objDepartmentDAL.FuzzyQueryDepartmentsByDepartmentName(queryCondition);
                    break;
            }
            return SortByDepartmentNo(departments);
        }

        /// <summary>
        /// 检查部门编号是否存在
        /// 根据department进行分情况查询
        /// department为null：查询当前部门编号是否已存在
        /// department不为null：查询除当前id外，该部门编号是否已存在
        /// </summary>
        /// <param name="no"></param>
        /// <param name="department"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckDepartmentNoIsExist(string no, DepartmentModel department = null)
        {
            if (department == null)
                return this.objDepartmentDAL.CheckDepartmentNoIsExist(no);
            else
                return this.objDepartmentDAL.CheckDepartmentNoIsExist(no, department.Id);
        }

        #endregion

    }
}
