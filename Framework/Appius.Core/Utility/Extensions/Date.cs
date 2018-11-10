using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Appius.Core.Utility.Extensions
{
    public static class DateExtensions
    {
        const int SECOND = 1;
        const int MINUTE = 60 * SECOND;
        const int HOUR = 60 * MINUTE;
        const int DAY = 24 * HOUR;
        const int MONTH = 30 * DAY;

        public static string GetMessageDate(this DateTime ThisDateTime)
        {
            return ThisDateTime.ToLocalTime().ToString("d MMM yy");
        }

        public static string GetMessageTime(this DateTime ThisDateTime)
        {
            return ThisDateTime.ToLocalTime().ToString("h:mm tt").ToLowerInvariant();
        }

        public static string GetRelativeAlertTime(this DateTime ThisDateTime)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - ThisDateTime.Ticks);
            var delta = (int)Math.Abs(ts.TotalSeconds);

            if (delta < 0)
            {
                return "not yet";
            }
            if (delta < 1 * MINUTE)
            {
                return "Just now";
            }
            if (delta < 2 * MINUTE)
            {
                return "a minute ago";
            }
            if (delta < 45 * MINUTE)
            {
                return Math.Abs((int)ts.TotalMinutes) + "min ago";
            }
            if (delta < 90 * MINUTE)
            {
                return "an hour ago";
            }
            if (delta < 24 * HOUR)
            {
                return Math.Abs((int)ts.TotalHours) + "h ago";
            }
            if (delta < 48 * HOUR)
            {
                return "1 day ago";
            }

            return ThisDateTime.ToString("d MMM yy");
        }

        public static string ToFormattedString(this DateTime Date)
        {
            var dateString = Date.ToString("d# MMMM yyyy");
            return dateString.Replace("#", GetDaySuffix(Date.Day));
        }

        private static string GetDaySuffix(int Day)
        {
            switch (Day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }
    }
}
