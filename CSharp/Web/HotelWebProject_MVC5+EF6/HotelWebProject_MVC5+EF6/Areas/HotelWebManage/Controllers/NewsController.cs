using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace HotelWebProject_MVC5_EF6.Areas.HotelWebManage.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private NewsManager objNewsManager = new NewsManager();
        // GET: HotelWebManage/News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsPublish()
        {
            List<NewsCategory> newsCategories = objNewsManager.GetNewsCategories();
            SelectList selectListItems = new SelectList(newsCategories, "CategoryId", "CategoryName");
            ViewBag.DList = selectListItems;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PublishNews(News news)
        {
            news.PublishTime = DateTime.Now;
            int result = objNewsManager.AddNews(news);
            //int result = 0;
            if (result > 0)
                return Content($"<script>alert('发布成功！');window.location='{Url.Content("~/HotelWebManage/News/NewsManage")}'</script>");
            else
                return Content($"<script>alert('发布失败！');location.href='{Url.Action("NewsPublish")}'</script>");
        }

        public ActionResult NewsManage()
        {
            List<News> newsList = objNewsManager.GetNewsList(10);
            ViewBag.NewsList = newsList;
            return View();
        }

        public ActionResult NewsModify(int NewsId)
        {
            News news = objNewsManager.GetNewsById(NewsId);
            return View("NewsDetail", news);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ModifyNews(News news)
        {
            news.PublishTime = DateTime.Now;
            int result = objNewsManager.ModifyNews(news);
            if(result > 0)
                return Content($"<script>alert('修改成功！');window.location='{Url.Content("~/HotelWebManage/News/NewsManage")}'</script>");
            else
                return Content($"<script>alert('修改失败！');window.location='{Url.Content("~/HotelWebManage/News/NewsManage")}'</script>");
        }

        public ActionResult DeleteNews(int newsId)
        {
            int result = objNewsManager.DeleteNews(newsId);
            if (result > 0)
                return Content("success");
            else
                return Content("error");
        }
    }
}