using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Love_JiaYuan.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoLogin
    {
        /// <summary>
        /// 自动登录
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string Login(string uname="1154592077@qq.com", string pwd="jiayuanoppzk")
        {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://passport.jiayuan.com/dologin.php?host=www.jiayuan.com&new_header=1&channel=index");
            request.Method = "Post";
            request.Headers[HttpRequestHeader.Cookie] = "user_access=1;";
            request.CookieContainer = cookies;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36";
            string param = "channel=200&position=201&name=" + uname + "&password=" + pwd;
            byte[] bs = Encoding.ASCII.GetBytes(param);
            string responseData = String.Empty;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bs.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string cookie = response.Headers.Get("Set-Cookie");
            var m = response.Headers["set-cookie"];
            var n2 = cookies.GetCookies(new Uri("http://passport.jiayuan.com"));
            var n = cookies.GetCookies(new Uri("http://jiayuan.com"));
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string code = sr.ReadToEnd();
            sr.Dispose();


            n2.Add(new Cookie("is_searchv2", "1","http://jiayuan.com"));
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://search.jiayuan.com/v2/search_v2.php",//URL     必需项    
                Method = "Post",//URL     可选项 默认为Get    
                Timeout = 100000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000    
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写    
                //Cookie = n,//字符串Cookie     可选项    
                CookieCollection=n2,
                UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36",//用户的浏览器类型，版本，操作系统     可选项有默认值    
                Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值    
                ContentType = "text/html",//返回类型    可选项有默认值    
                Referer = "http://www.sufeinet.com",//来源URL     可选项    
                //Allowautoredirect = true,//是否根据３０１跳转     可选项    
                //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数    
                //Connectionlimit = 1024,//最大连接数     可选项 默认为1024    
                Postdata = "sex=f&key=&stc=1:11,2:18.24,23:1&sn=default&sv=1&p=1&f=select&listStyle=bigPhoto&pri_uid=0&jsversion=v5",//Post数据     可选项GET时不需要写    
                //ProxyIp = "192.168.1.105",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
                //ProxyPwd = "123456",//代理服务器密码     可选项    
                //ProxyUserName = "administrator",//代理服务器账户名     可选项    
                //ResultType = ResultType.String,//返回数据类型，是Byte还是String    
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;


            //HttpHelper http = new HttpHelper();
            //HttpItem item = new HttpItem()
            //{
            //    URL = "https://passport.jiayuan.com/dologin.php?host=www.jiayuan.com&new_header=1&channel=index",//URL     必需项    
            //    Method = "Post",//URL     可选项 默认为Get    
            //    Timeout = 100000,//连接超时时间     可选项默认为100000    
            //    ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000    
            //    IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写    
            //    //Cookie = "",//字符串Cookie     可选项    
            //    UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36",//用户的浏览器类型，版本，操作系统     可选项有默认值    
            //   // Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值    
            //    //ContentType = "text/html",//返回类型    可选项有默认值    
            //    Referer = "http://www.jiayuan.com/",//来源URL     可选项  
            //    Host="passport.jiayuan.com",
            //    Allowautoredirect = true,//是否根据３０１跳转     可选项    
            //    //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数    
            //    //Connectionlimit = 1024,//最大连接数     可选项 默认为1024    
            //    Postdata = "channel=200&position=201&name=" + uname + "&password=" + pwd ,//Post数据     可选项GET时不需要写    
            //    //ProxyIp = "192.168.1.105",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
            //    //ProxyPwd = "123456",//代理服务器密码     可选项    
            //    //ProxyUserName = "administrator",//代理服务器账户名     可选项    
            //    //ResultType = ResultType.String,//返回数据类型，是Byte还是String    
            //};
            //HttpResult result = http.GetHtml(item);
            //string html = result.Html;
            
            ////取得跳转url
            //string jumpurl = Regex.Match(html, @"\('(.+?)'\)").Groups[1].Value;


           



            //HttpHelper http2 = new HttpHelper();
            //HttpItem item2 = new HttpItem() {
            //    URL = jumpurl,    
            //    Method = "Get",
            //    Cookie=result.Cookie,
            //    UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36",
            //    Host = "www.jiayuan.com"
            //};
            //HttpResult result2 = http2.GetHtml(item2);
            //string html2 = result2.Html;

            ////登录http://usercp.jiayuan.com
            //HttpHelper http3 = new HttpHelper();
            //HttpItem item3 = new HttpItem()
            //{
            //    URL = "http://usercp.jiayuan.com",
            //    Method = "Get",
            //    UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36",
            //    //Host = "www.jiayuan.com"
            //};
            //HttpResult result3 = http3.GetHtml(item3);
            //string html3 = result3.Html;
            return "";
        }


    }
}