using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CSDataPager
{
    /// <summary>
    /// 通用数据分页类
    /// </summary>
    public class SqlDataPager
    {
        public SqlDataPager() { }
        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>      
        public int TotalPages
        {
            get
            {
                if (RecordsCount != 0)
                {
                    if (RecordsCount % PageSize != 0)
                        return RecordsCount / PageSize + 1;
                    else
                        return RecordsCount / PageSize;
                }
                else
                {
                    this.CurrentPageIndex = 1;//设置默认页
                    return 0;
                }
            }
        }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordsCount { get; set; }
        /// <summary>
        /// 当前页的页码
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 获取分页的SQL语句
        /// </summary>
        private string GetPagedSQL()
        {           
            //组合SQL语句
            string sql =
                     "Select Top  (@PageSize) StudentId,StudentName,Gender,Birthday,PhoneNumber from Students " +
                      "where  Birthday>@Birthday and StudentId not in" +
                     " (Select Top  (@filterCount) StudentId from Students where  Birthday>@Birthday order by StudentId ASC)" +
                     "order by StudentId ASC;" +
                     "select count(*) from Students where  Birthday>@Birthday";          
            return sql;
        }
        /// <summary>
        /// 执行分页查询，返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable GetPagedData(string birthday)
        {    
            //封装查询需要的参数
            SqlParameter[] param = new SqlParameter[]
            {
                  new SqlParameter("@PageSize",this.PageSize),
                  new SqlParameter("@filterCount",(PageSize * (CurrentPageIndex - 1))),
                  new SqlParameter("@Birthday",birthday)
            };
            //执行查询
            DataSet ds = SQLHelper.GetDataSet(this.GetPagedSQL(), param);
            //获取满足条件的记录总数
            this.RecordsCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            //返回数据列表
            return ds.Tables[0];
        }
    }
}
