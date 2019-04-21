using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    /// <summary>
    /// 新闻分类
    /// </summary>
    public class NewsCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public NewsCategory(int id, string name)
        {
            this.CategoryId = id;
            this.CategoryName = name;
        }
    }
}