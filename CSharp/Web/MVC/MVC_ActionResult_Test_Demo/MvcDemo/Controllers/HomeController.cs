using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Detail()
    {
        return View();
    }
    //【1】输出简单文本内容
    public ActionResult ContentTest()
    {
        string content = "<h1>Welcome to ASP.NET MVC!</h1>";
        return Content(content);
    }
    //【2】输出JSON字符串
    public ActionResult JsonTest()
    {
        var book = new
        {
            bookid = 1,
            bookName = "ASP.NET MVC动态网站开发VIP课程",
            author = "常老师",
            publishData = DateTime.Now
        };
        return Json(book, JsonRequestBehavior.AllowGet);
    }
    //【3】输出JavaScript文件
    public ActionResult JavaScriptTest()
    {
        string js = "alert('Welcome to ASP.NET MVC!')";
        return JavaScript(js);
    }

    #region 跳转控制

    //【4】重定向页面跳转
    public ActionResult RedirectTest()
    {
        return Redirect("/Home/Detail");
    }
    //【5】跳转到指定的Action（也可以到其他控制器）
    public ActionResult RedirectToActionTest()
    {
        return RedirectToAction("Detail", new { id = 1, cate = "test" });
    }
    //【6】使用指定的路由值跳转到指定的路由
    public ActionResult RedirectToRouteTest()
    {
        return RedirectToRoute(new
        {
            controller = "Home",
            action = "Detail",
            id = 1,
            cate = "test"
        });
    }

    #endregion

    #region 文件输出


    //【7】按文件路径输出文件
    public ActionResult FilePathTest()
    {
        return File("~/Content/rain.mp3", "audio/mp3");//参数：文件名，内容类型
    }
    //【8】对字符串编码，并输出文件
    public ActionResult FileContentTest()
    {
        string content = "Welcome to ASP.NET MVC!";
        byte[] contents = System.Text.Encoding.UTF8.GetBytes(content);

        return File(contents, "text/plain");
    }
    //【9】用文件流输出文件
    public ActionResult FileStreamTest()
    {     
        FileStream fs = new FileStream(
            Server.MapPath("~/Content/控制器详解.pdf"), FileMode.Open);
        return File(fs, "application/pdf");
    }

    #endregion
}

