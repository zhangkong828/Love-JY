using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Love_JiaYuan.Models
{
    public class CondiModel
    {
        public List<string> work_sublocation { get; set; }
        public List<string> work_location { get; set; }
        public AgeModel age { get; set; }
        public int avatar { get; set; }
    }
}