using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            //  HttpPostedFileBase testFile = Request.Files[0];
            if (file != null)
            {
                string filePath = Server.MapPath("~/files/") + file.FileName;//获取文件在服务器的路径
                file.SaveAs(filePath);//把文件保存在此路径中
                return Content("<script>alert('文件上传成功！');location.href='" + Url.Content("/File") + "'</script>");
            }
            return View();
        }

    }
}
