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
    public class CompanyController : Controller
    {
        private DishesManager objDishesManager = new DishesManager();
        private CompanyManager objCompanyManager = new CompanyManager();
        // GET: HotelWebManage/Company
        public ActionResult BookManage()
        {
            ViewBag.DishesBookList = objDishesManager.GetDishesBookList();
            return View();
        }

        public ActionResult ModifyDishesBookStatus(int bookId, int status)
        {
            int result = objDishesManager.ModifyDishesBookStatus(bookId, status);
            if (result > 0)
                return Content($"<script>alert('修改成功！');location.href='{Url.Action("BookManage")}'</script>");
            else
                return Content($"<script>alert('修改失败！');location.href='{Url.Action("BookManage")}'</script>");
        }

        public ActionResult SuggestionManage()
        {
            ViewBag.SuggestionList = objCompanyManager.GetSuggestionsList();
            return View();
        }

        public ActionResult HandleSuggestion(int suggestionId)
        {
            int result = objCompanyManager.DeleteSuggestionById(suggestionId);
            return Content($"<script>location.href='{Url.Action("SuggestionManage")}'</script>");
        }

        public ActionResult RecruitmentPublish()
        {
            return View();
        }

        public ActionResult SubmitRecruimentInfo(Recruitment recruitment)
        {
            int result = objCompanyManager.AddRecruitment(recruitment);
            if (result > 0)
            {
                ViewBag.RecruitmentList = objCompanyManager.GetRecruitmentList();
                return View("RecruitmentManage");
            }
            else
            {
                ViewBag.PublishError = true;
                return View("RecruitmentPublish", recruitment);
            }
        }

        public ActionResult RecruitmentManage()
        {
            ViewBag.RecruitmentList = objCompanyManager.GetRecruitmentList();
            return View();
        }

        public ActionResult DeleteRecruitment(int postId)
        {
            int result = objCompanyManager.DeleteRecruitmentById(postId);
            ViewBag.RecruitmentList = objCompanyManager.GetRecruitmentList();
            return View("RecruitmentManage");
        }

        public ActionResult RecruitmentModify(int postId)
        {
            Recruitment recruitment = objCompanyManager.GetRecruitmentById(postId);
            return View("ModifyRecruitment", recruitment);
        }

        public ActionResult ModifyRecruitment(Recruitment recruitment)
        {
            objCompanyManager.ModifyRecruitment(recruitment);
            ViewBag.RecruitmentList = objCompanyManager.GetRecruitmentList();
            return View("RecruitmentManage");
        }
    }
}