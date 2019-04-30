using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace HotelWebProject_MVC5_EF6.Controllers
{
    public class NewsController : Controller
    {
        private NewsManager objNewsManager = new NewsManager();
        // GET: News
        public ActionResult NewsList()
        {
            ViewBag.NewsList = objNewsManager.GetNewsList(8);
            return View();
        }

        public ActionResult NewsDetail(int newsId)
        {
            News news = objNewsManager.GetNewsById(newsId);
            return View("NewsDetail", news);
        }
    }
}