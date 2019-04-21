using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BSDataPageDemo.Handlers
{
    /// <summary>
    /// 通用数据分页类
    /// </summary>
    public class SqlDataPager
    {
        public SqlDataPager() { }
        /// <summary>
        /// 需要显示的字段（以逗号分隔）
        /// </summary>
        public string FiledName { get; set; }
        /// <summary>
        /// 数据表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 表的主键或唯一键
        /// </summary>
        public string PrimaryKey { get; set; }
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
                    this.CurrentPageIndex = 1;
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
        /// 查询条件
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 排序条件
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 获取分页的SQL语句
        /// </summary>
        /// <param name="pageSize">每页显示的条数</param>
        /// <param name="currentPageIndex">当前页的页码</param>
        /// <param name="filedName">需要显示的字段</param>
        /// <param name="tableName">表名称</param>
        /// <param name="condition">查询条件</param>
        /// <param name="keyWord">主键名称</param>
        /// <param name="sort">排序条件</param>
        /// <returns></returns>
        public string GetPagedSQL()
        {
            //需要过滤的总数
            string filterCount = (PageSize * (CurrentPageIndex - 1)).ToString();
            //组合SQL语句
            string sql = "Select Top " + PageSize + " " + FiledName + " from " +
                TableName + " where " + Condition +
                " and " + PrimaryKey + " not in (Select Top " + filterCount + " " +
                PrimaryKey + " from " + TableName +
                " where " + Condition + " order by " + Sort + ") order by " + Sort;
            sql += ";select count(*) from " + TableName + " where " + Condition;
            return sql;
        }
        /// <summary>
        /// 执行分页查询，返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable GetPagedData()
        {
            //执行查询
            DataSet ds = DAL.SQLHelper.GetDataSet(GetPagedSQL());
            //获取满足条件的记录总数
            this.RecordsCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            //返回数据列表
            return ds.Tables[0];
        }
    }
}