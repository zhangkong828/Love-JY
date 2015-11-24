using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Love_JiaYuan.Models
{
    public class UserModel
    {
        public int uid { get; set; }
        public int realUid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string sexValue { get; set; }
        public string randAttr { get; set; }
        public string marriage { get; set; }
        public int height { get; set; }
        public string education { get; set; }
        public string income { get; set; }
        public string work_location { get; set; }
        public string work_sublocation { get; set; }
        public int age { get; set; }
        public string image { get; set; }
        public int count { get; set; }
        public int online { get; set; }
        public string randTag { get; set; }
        public string randListTag { get; set; }
        public string userIcon { get; set; }
        public string helloUrl { get; set; }
        public string sendMsgUrl { get; set; }
        public string shortnote { get; set; }
        public string matchCondition { get; set; }
    }
}