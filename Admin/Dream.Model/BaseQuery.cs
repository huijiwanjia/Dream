using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model
{
    public class BaseQuery
    {
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string OrderBy { get; set; }
        public bool NeedTotalCount { get; set; }
        public string Fields { get; set; }
    }
}
