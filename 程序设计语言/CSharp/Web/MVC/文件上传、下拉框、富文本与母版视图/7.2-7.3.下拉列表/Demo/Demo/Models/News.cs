using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{

    /// <summary>
    /// 新闻实体类
    /// </summary>
    public class News
    {
        public string NewsTitle { get; set; }
        public int NewsCategory { get; set; }
        public string NewsContent { get; set; }
    }
}