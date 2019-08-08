using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.DataAccess
{
    public class Procedure
    {
        public static string GetUserByUnionId => "GetUserByUnionId";
        public static string GetRecommentByUnionId => "GetRecommentByUnionId";
        public static string GetClickLogByItemIdAndClickTime => "GetClickLogByItemIdAndClickTime";
    }
}
