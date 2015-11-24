using Love_JiaYuan.Common;
using Love_JiaYuan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Love_JiaYuan.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var area = Request.Form["area"] == null ? 11 : Convert.ToInt32(Request.Form["area"]);
            var ages = Request.Form["ages"] == null ? 18 : Convert.ToInt32(Request.Form["ages"]);
            var agee = Request.Form["agee"] == null ? 23 : Convert.ToInt32(Request.Form["agee"]);

            var pageindex = Request.Form["i"] == null ? 1 : Convert.ToInt32(Request.Form["i"]);

            string postdata = string.Format("sex=f&key=&stc=1:{0},2:{1}.{2},23:1&sn=default&sv=1&p={3}&f=select&listStyle=bigPhoto&pri_uid=0&jsversion=v5", area, ages, agee, pageindex);
            var list = GetSearchModels(postdata);

            ViewData["area"] = area;
            ViewData["ages"] = ages;
            ViewData["agee"] = agee;
            ViewData["pageindex"] = pageindex;



            return View(list);
        }

        public ActionResult Page()
        {
            var area = Request.QueryString["area"] == null ? 11 : Convert.ToInt32(Request.QueryString["area"]);
            var ages = Request.QueryString["ages"] == null ? 18 : Convert.ToInt32(Request.QueryString["ages"]);
            var agee = Request.QueryString["agee"] == null ? 23 : Convert.ToInt32(Request.QueryString["agee"]);

            var pageindex = Request.QueryString["i"] == null ? 1 : Convert.ToInt32(Request.QueryString["i"]);

            string postdata = string.Format("sex=f&key=&stc=1:{0},2:{1}.{2},23:1&sn=default&sv=1&p={3}&f=select&listStyle=bigPhoto&pri_uid=0&jsversion=v5", area, ages, agee, pageindex);
            var list = GetSearchModels(postdata);

            ViewData["area"] = area;
            ViewData["ages"] = ages;
            ViewData["agee"] = agee;
            ViewData["pageindex"] = pageindex;



            return View("Index",list);
        }


        private SearchModels GetSearchModels(string postdata)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://search.jiayuan.com/v2/search_v2.php",//URL     必需项    
                Method = "Post",//URL     可选项 默认为Get    
                Timeout = 100000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000    
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写    
                Cookie = "",
                UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36",//用户的浏览器类型，版本，操作系统     可选项有默认值    
                Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值    
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8",
                Postdata = postdata,
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;

            var json = html.Replace("##jiayser##", "").Replace(@"##jiayser##//", "");
            json = json.Substring(0, json.Length - 2);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var list = jss.Deserialize(json, typeof(SearchModels)) as SearchModels;
            return list;

        }
    }
}
