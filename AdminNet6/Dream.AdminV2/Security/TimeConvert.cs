using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.Security
{
    public class TimeConvert
    {

        public static String GetCurrentUTCTimeSpan()
        {
            return DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");
        }
        public static DateTime TimeSpanToUTCDateTime(string timespan)
        {
            if (DateTime.TryParseExact(timespan,
                            "yyyyMMddHHmmssffff",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime date))
            {
                //valid
                return date;
            }
            else throw new ArgumentException("时间格式不正确");
        }
    }
}
