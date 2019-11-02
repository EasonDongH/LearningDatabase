using System.Web.Mvc;

namespace HotelWebProject_MVC5_EF6.Areas.HotelWebManage
{
    public class HotelWebManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HotelWebManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HotelWebManage_default",
                "HotelWebManage/{controller}/{action}/{id}",
                new { Controller= "SysAdmin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}