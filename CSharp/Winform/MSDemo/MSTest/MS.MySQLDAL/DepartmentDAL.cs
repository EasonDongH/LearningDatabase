﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Reflection;

using log4net;
using Dapper;
using Dapper.Mapper;
using MySql.Data.MySqlClient;

using MS.Models;
using MS.DBUtil;

namespace MS.MySQLDAL
{
    public class DepartmentDAL
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
        /// <param name="department"></param>
        /// <returns></returns>
        public int AddDepartment(DepartmentModel department)
        {
            string sql = "INSERT INTO ms_department(Id,DepartmentNo,DepartmentName,Remarks) VALUES(@Id,?DepartmentNo,@DepartmentName,@Remarks);";

            int add_Result = 0;
            try
            {
                using (this.Conn)
                {
                    add_Result = this.Conn.Execute(sql, department);
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
        /// 根据主键Id进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteDepartment(string id)
        {
            DepartmentModel model = new DepartmentModel();
            model.Id = id;
            int delete_Result = 0;
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
        /// 根据唯一键DepartmentNo进行删除
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public int DeleteDepartmentByNo(string no)
        {
            string sql = "DELETE FROM ms_department WHERE DepartmentNo=@no;";
            int delete_Result = 0;
            try
            {
                using (this.Conn)
                {
                    delete_Result = this.Conn.Execute(sql, new { no = no });
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
        /// 修改部门信息
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int ModifyDepartmentInfo(DepartmentModel department)
        {
            int modify_Result = 0;
            try
            {
                using (this.Conn)
                {
                    //modify_Result = this.Conn.Update(department) > 0;
                    string sql = "UPDATE ms_department SET DepartmentNo=@DepartmentNo,DepartmentName=@DepartmentName,Remarks=@Remarks where Id=@Id;";
                    modify_Result = this.Conn.Execute(sql, department);
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
        /// 查询给定的部门编号是否存在
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckDepartmentNoIsExist(string departmentNo)
        {
            bool result = true;
            try
            {
                using (this.Conn)
                {
                    string sql = "SELECT * FROM ms_department WHERE DepartmentNo=@DepartmentNo;";
                    List<DepartmentModel> models = this.Conn.Query<DepartmentModel>(sql, new { DepartmentNo = departmentNo }).ToList();
                    result = models.Count() > 0;
                    //int cnt = this.Conn.Execute(sql, new { DepartmentNo = departmentNo });
                    //result = this.Conn.Execute(sql,new {DepartmentNo=departmentNo}) > 0;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 查询给定的部门编号，除当前部门外，是否存在
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <param name="id"></param>
        /// <returns>true：已存在 false：未存在</returns>
        public bool CheckDepartmentNoIsExist(string departmentNo, string id)
        {
            bool result = true;
            try
            {
                using (this.Conn)
                {
                    string sql = "SELECT * FROM ms_department WHERE DepartmentNo=@DepartmentNo AND Id <> @Id;";
                    List<DepartmentModel> models = this.Conn.Query<DepartmentModel>(sql, new { DepartmentNo = departmentNo, Id = id }).ToList();
                    result = models.Count() > 0;
                    //int cnt = this.Conn.Execute(sql, new { DepartmentNo = departmentNo, Id = id });
                    //result = this.Conn.Execute(sql, new { DepartmentNo = departmentNo, Id = id }) > 0;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 获取部门列表的公共私有方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private List<DepartmentModel> GetDepartmetsCommonMethod(string sql, MySqlParameter[] parameters = null)
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                using (this.Conn)
                {
                    departments = this.Conn.Query<DepartmentModel>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return departments;
        }
        /// <summary>
        /// 根据部门编号进行模糊查询
        /// 模糊条件：%no%
        /// </summary>
        /// <param name="departmentNo"></param>
        /// <returns></returns>
        public List<DepartmentModel> FuzzyQueryDepartmentsByDepartmentNo(string departmentNo)
        {
            string sql = string.Format("SELECT * FROM ms_department WHERE DepartmentNo like '{0}';", departmentNo);
            return GetDepartmetsCommonMethod(sql);
        }
        /// <summary>
        /// 根据部门名称进行模糊查询
        /// 模糊条件：%name%
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public List<DepartmentModel> FuzzyQueryDepartmentsByDepartmentName(string departmentName)
        {
            string sql = string.Format("SELECT * FROM ms_department WHERE DepartmentName like '{0}';", departmentName);
            return GetDepartmetsCommonMethod(sql);
        }
        /// <summary>
        /// 获取所有部门信息
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartments()
        {
            string sql = "SELECT * FROM ms_department;";
            return GetDepartmetsCommonMethod(sql);
        }
        /// <summary>
        /// 根据唯一键部门编号，获取逐渐Id
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string GetIdByNo(string no)
        {
            string sql = string.Format("SELECT Id FROM ms_department WHERE DepartmentNo='{0}'", no);
            string id = null;
            try
            {
                using (this.Conn)
                {
                    DepartmentModel model = this.Conn.Query<DepartmentModel>(sql).SingleOrDefault();
                    if (model != null)
                        id = model.Id;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return id;
        }
        /// <summary>
        /// 根据唯一键部门编号，获取指定部门
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public DepartmentModel GetSpecifyDepartmentByDepartmentNo(string no)
        {
            DepartmentModel model = null;
            try
            {
                using (this.Conn)
                {
                    string sql = "SELECT * FROM ms_department WHERE DepartmentNo = @DepartmentNo;";
                    model = this.Conn.Query<DepartmentModel>(sql, new { DepartmentNo = no }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return model;
        }
        /// <summary>
        /// 根据主键Id获取指定部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DepartmentModel GetSpecifyDepartmentById(string id)
        {
            DepartmentModel model = null;
            try
            {
                using (this.Conn)
                {
                    model = this.Conn.Get<DepartmentModel>(id);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return model;
        }
        #endregion
    }
}
