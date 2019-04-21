using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BLL;
using System.Web.Script.Serialization;
namespace BSDataPageDemo.Handlers
{
    /// <summary>
    /// PagerHandler 的摘要说明
    /// </summary>
    public class PagerHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //获取页面提交的参数
            string pageSize = context.Request.Params["pageSize"];//每页显示条数
            string currentPage = context.Request.Params["currentPage"];//当前页码
            string birthday = context.Request.Params["birthday"];//出生日期（查询条件）
            //获取查询结果
            int pages = 0;
            int records = 0;
            List<Student> stuList = new StudentManager().GetPagedData(
                Convert.ToInt32(pageSize), Convert.ToDateTime(birthday), Convert.ToInt32(currentPage),
                out records, out pages);
            //将学员集合序列化为JSON格式的数据
            if (stuList.Count != 0)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string stringList = jss.Serialize(stuList);//将当前list对象转换成字符串（JSON格式）
                stringList += "||" + pages + "||" + records;
                //返回结果
                context.Response.Write(stringList);
            }
            else
                context.Response.Write("0");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}