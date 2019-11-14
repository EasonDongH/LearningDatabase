using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    /// <summary>
    /// 新闻模块数据访问类
    /// </summary>
    public class NewsService
    {
        /// <summary>
        /// 从数据库里面查询所有的新闻分类信息
        /// </summary>
        /// <returns></returns>
        public List<NewsCategory> GetNewsCategory()
        {
            List<NewsCategory> list = new List<NewsCategory>();
            list.Add(new NewsCategory(1, "教育"));
            list.Add(new NewsCategory(2, "影视"));
            list.Add(new NewsCategory(3, "汽车"));
            list.Add(new NewsCategory(4, "军事"));           
            return list;
        }
    }
}
