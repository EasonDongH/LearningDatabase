using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    public class StudentManager
    {
        //创建数据访问对象
        private StudentService objService = new StudentService();

        /// <summary>
        /// 分页查询学员信息
        /// </summary>
        /// <param name="pageSize">每页显示的条数</param>
        /// <param name="birthday">出生日期（查询条件）</param>
        /// <param name="currentPage">当前页码</param>
        /// <param name="recordsCount">输出参数：记录总数</param>
        /// <param name="pageCount">输出参数：总页数</param>
        /// <returns></returns>
        public List<Student> GetPagedData(int pageSize, DateTime birthday, int currentPage,
            out int recordsCount,out int pageCount)
        {
            //获取查询列表
            int records = 0;            
            List<Student> list = objService.GetPagedData(pageSize, birthday, currentPage, out records);
            //计算符合要求的记录总页数
            int pages = 0;
            if (records != 0)
            {
                if (records % pageSize != 0)
                    pages= records / pageSize + 1;
                else
                    pages= records / pageSize;
            }
            //设置返回参数和结果
            recordsCount = records;
            pageCount = pages;
            return list;           
        }
    }
}
