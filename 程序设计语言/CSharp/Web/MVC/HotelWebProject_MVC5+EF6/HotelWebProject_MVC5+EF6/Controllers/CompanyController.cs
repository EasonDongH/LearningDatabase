using BLL;
using Models;
using System.Web.Mvc;

namespace HotelWebProject_MVC5_EF6.Controllers
{
    public class CompanyController : Controller
    {
        private NewsManager objNewsManager = new NewsManager();
        private CompanyManager objCompanyManager = new CompanyManager();

        // GET: Company
        public ActionResult Index()
        {
            ViewBag.NewsList = objNewsManager.GetNewsList(5);
            return View();
        }

        public ActionResult CompanyDesc()
        {
            return View();
        }

        public ActionResult Suggestions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Suggestions(Suggestion suggestion, string vCode)
        {
            // 使用MVC验证特性
            if (ModelState.IsValid)
            {
                if (vCode.ToLower() != Session["validateCode"].ToString())
                {
                    ModelState.AddModelError("vCode", "验证码错误");
                    return View("Suggestions", suggestion);
                }
                int result = objCompanyManager.AddSuggestion(suggestion);
                if (result > 0)
                    return Content($"<script>alert('投诉提交成功！');window.location='{Url.Content("~/") }'</script>");
                else
                    return Content($"<script>alert('投诉提交失败！');window.location='{Url.Content("~/Company/Suggestions") }'</script>");
            }

            return View("Suggestions", suggestion);
        }

        public ActionResult Environment()
        {
            return View();
        }

        public ActionResult JoinUs()
        {
            return View();
        }

        public ActionResult RecruitmentList()
        {
            ViewBag.RecruitmentList = objCompanyManager.GetRecruitmentList();
            return View();
        }

        public ActionResult RecruitmentDetail(int PostId)
        {
            Recruitment recruitment = objCompanyManager.GetRecruitmentById(PostId);
            return View("RecruitmentDetail", recruitment);
        }

        public ActionResult AboutUs()
        {
            return View();
        }
    }
}