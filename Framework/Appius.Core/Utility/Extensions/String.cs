using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appius.Core.Utility.Extensions
{
    public static class StringExtensions
    {
        public static string WithEllipsis(this string str, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var min = Math.Min(str.Length, maxLength);

            return string.Format("{0}...", str.Substring(0, min));
        }

        public static string ToUrlString(this string Input)
        {
            return Input.Replace(" ", "-");
        }

        public static string FromUrlString(this string Input)
        {
            return Input.Replace("-", " ");
        }

        public static string ToTitleCase(this string Input)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Input.ToLower());
        }
    }
}
