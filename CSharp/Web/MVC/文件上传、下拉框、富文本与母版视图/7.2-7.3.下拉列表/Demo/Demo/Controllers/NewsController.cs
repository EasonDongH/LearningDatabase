using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            //和模型交互，获取所有的新闻分类信息
            List<NewsCategory> category = new NewsService().GetNewsCategory();
            SelectList list = new SelectList(category, "CategoryId", "CategoryName", category[0].CategoryId);

            //返回视图（如果需要传递数据，则首先保存数据）
            ViewBag.Category = list;
            return View("AddNews");
        }

    }
}
