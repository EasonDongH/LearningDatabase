using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHotel.Models;
using Models;
using BLL;

namespace HotelWebProject_MVC5_EF6.Controllers
{
    public class DishesController : Controller
    {
        private DishesManager objDishesManager = new DishesManager();
        // GET: Dishes
        public ActionResult DishesBook()
        {
            return View();
        }

        public ActionResult ValidateCode()
        {
            CreateValidateCode createValidate = new CreateValidateCode();
            string validateCode = createValidate.CreateRandomCode(6);
            Session["validateCode"] = validateCode.ToLower();
            return File(createValidate.CreateValidateGraphic(validateCode),"Images/jpeg");
        }

        public ActionResult CheckValidate()
        {
            string inputValidateCode = Request["value"]; // 框架自动映射
            if (string.Compare(inputValidateCode, Session["validateCode"].ToString()) == 0)
                return Content("1"); // “1”表示正确；“0”表示错误
            else
                return Content("0");
        }

        public ActionResult Book(DishesBook book)
        {
            book.OrderStatus = 0;
            int result = objDishesManager.DishesBook(book);
            if (result > 0)
                return Content("success");
            else
                return Content("error");
        }

        public ActionResult DishesShow()
        {
            ViewBag.DishesList = objDishesManager.GetDishesListByCategoryId();
            return View();
        }
    }
}