using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest
{
    public class DempartmentManager
    {
        #region 全局变量
        private DepartmentService objDepartmentService = new DepartmentService();
        #endregion

        #region 增
        public bool AddDepartment(Department department)
        {
            department.Id = CommonMethod.GetGUID();
            return objDepartmentService.AddDepartment(department);
        }
        #endregion

        #region 删
        public bool DeleteDepartmentByNo(string no)
        {
            return objDepartmentService.DeleteDepartmentByNo(no);
        }
        #endregion

        #region 改

        public bool ModifyDepartmentInfo(Department department)
        {
            return objDepartmentService.ModifyDepartmentInfo(department);
        }
        #endregion

        #region 查
        private List<Department> SortByDepartmentNo(List<Department> departments)
        {
            return (from d in departments orderby d.DepartmentNo select d).ToList();
        }

        public List<Department> GetDepartments()
        {
            return SortByDepartmentNo(objDepartmentService.GetDepartments());
        }

        /// <summary>
        /// 根据query mode进行条件查询
        /// 0：根据部门编号查询
        /// 1：根据部门名称查询
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="queryMode"></param>
        /// <returns></returns>
        public List<Department> GetDepartments(string condition, int queryMode)
        {
            List<Department> departments = null;
            if (condition == string.Empty)
            {
                departments = SortByDepartmentNo(this.objDepartmentService.GetDepartments());
            }
            else
            {
                string queryCondition = "%" + condition + "%";
                switch (queryMode)
                {
                    case 0:
                        departments = SortByDepartmentNo(this.objDepartmentService.FuzzyQueryDepartmentsByDepartmentNo(queryCondition));
                        break;
                    case 1:
                        departments = SortByDepartmentNo(this.objDepartmentService.FuzzyQueryDepartmentsByDepartmentName(queryCondition));
                        break;
                }
            }
            return departments;
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
        public bool CheckDepartmentNoIsExist(string no, Department department = null)
        {
            if (department == null)
                return this.objDepartmentService.CheckDepartmentNoIsExist(no);
            else
                return this.objDepartmentService.CheckDepartmentNoIsExist(no, department.Id);
        }

        #endregion

    }
}
