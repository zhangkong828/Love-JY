using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Love_JiaYuan.Models
{
    public class SearchModels
    {
        public bool isLogin { get; set; }
        public int count { get; set; }
        public int pageTotal { get; set; }
        public List<UserModel> userInfo { get; set; }
        public int second_search { get; set; }
        public List<Express_searchUserModel> express_search { get; set; }
        public CondiModel condi { get; set; }
    }
}