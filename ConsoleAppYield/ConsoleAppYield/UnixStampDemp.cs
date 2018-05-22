using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    /// <summary>
    /// 时间戳
    /// </summary>
    public class UnixStampDemp
    {
        public static DateTime StampToDataTime(string timeStamp)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);

            return dateTimeStart.Add(toNow);

        }

        public static int DateTimeToStamp(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
