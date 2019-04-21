using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Security;

namespace HotelWebProject_MVC5_EF6.Areas.HotelWebManage.Controllers
{
    [Authorize]
    public class DishesController : Controller
    {
        private DishesManager objDishesManager = new DishesManager();
        // GET: HotelWebManage/Dishes
        [Authorize]
        public ActionResult DishesPublish()
        {
            List<DishesCategory> dishesCategories = objDishesManager.GetDishesCategories();
            SelectList selectListItems = new SelectList(dishesCategories, "CategoryId", "CategoryName");
            ViewBag.DishesCategoryList = selectListItems;
            return View();
        }

        public ActionResult PublishDishes(Dishes dishes, HttpPostedFileBase dishesImg)
        {
            if (dishesImg == null || dishesImg.FileName.Length == 0)
                return Content("<script>alert('请上传图片！');loaction.href='" + Url.Action("DishesPublish") + "'</script>");
            // 保存图片
            double filesize = dishesImg.ContentLength / (1024.0 * 1024.0);
            if (filesize > 2.0)
                return Content("<script>alert('图片最大不能超过2MB！');location.href='" + Url.Action("DishesPublish") + "'</script>");
            int result = objDishesManager.PublishDishes(dishes);
            if (result == 0)
                return Content("<script>alert('菜品发布失败！');location.href='" + Url.Action("DishesPublish") + "'</script>");
            string filepath = Server.MapPath($"~/Images/dishes/{dishes.DishesId}.png");
            dishesImg.SaveAs(filepath);
            return Content("<script>alert('菜品上传成功！');location.href='" + Url.Action("DishesPublish") + "'</script>");
        }

        public ActionResult DishesManage()
        {
            List<DishesCategory> dishesCategories = objDishesManager.GetDishesCategories();
            SelectList selectListItems = new SelectList(dishesCategories, "CategoryId", "CategoryName");
            ViewBag.DishesCategoryList = selectListItems;
            ViewBag.DishesList = objDishesManager.GetDishesListByCategoryId(0);
            return View();
        }

        public ActionResult QueryDishes(int CategoryId)
        {
            List<DishesCategory> dishesCategories = objDishesManager.GetDishesCategories();
            SelectList selectListItems = new SelectList(dishesCategories, "CategoryId", "CategoryName");
            ViewBag.DishesCategoryList = selectListItems;
            ViewBag.DishesList = objDishesManager.GetDishesListByCategoryId(CategoryId);
            return View("DishesManage");
        }

        public ActionResult ModifyDishes(int DishesId)
        {
            Dishes dishes = objDishesManager.GetDishesById(DishesId);
            List<DishesCategory> dishesCategories = objDishesManager.GetDishesCategories();
            SelectList selectListItems = new SelectList(dishesCategories, "CategoryId", "CategoryName",dishes.CategoryId);
            ViewBag.DishesCategoryList = selectListItems;
            return View("ModifyDishes", dishes);
        }

        public ActionResult SubmitModifyDishes(Dishes dishes, HttpPostedFileBase dishesImg)
        {
            if (dishesImg != null && dishesImg.FileName.Length != 0)
            {
                double filesize = dishesImg.ContentLength / (1024.0 * 1024.0);
                if (filesize > 2.0)
                    return Content("<script>alert('图片最大不能超过2MB！');location.href='" + Url.Action("DishesPublish") + "'</script>");
                string filepath = Server.MapPath($"~/Images/dishes/{dishes.DishesId}.png");
                dishesImg.SaveAs(filepath);
            }
            int result = objDishesManager.ModifyDishes(dishes);
            if (result == 0)
                return Content("<script>alert('菜品更新失败！');location.href='" + Url.Action("DishesPublish") + "'</script>");

            return Content("<script>alert('菜品更新成功！');location.href='" + Url.Action("DishesPublish") + "'</script>");
        }

        public ActionResult DeleteDishes(int dishesId)
        {
            Dishes dishes = objDishesManager.GetDishesById(dishesId);
            string filepath = Server.MapPath($"~/Images/dishes/{dishes.DishesImg}");
            int result = objDishesManager.DeleteDishes(dishesId);
            if (result > 0)
            {
                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                return Content("success");
            }
            else {
                return Content("error");
            }
        }
    }
}