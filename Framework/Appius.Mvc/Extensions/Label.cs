using System;
using System.Web.Mvc;

namespace AppiusMVC.Html
{
    public static partial class Extensions
    {
        public static string Label(this HtmlHelper Helper, string Target, string Text, string Class)
        {
            if (!string.IsNullOrEmpty(Class))
            {
                return String.Format("<label for='{0}' class='{1}'>{2}</label>", Target, Class, Text);
            }

            return String.Format("<label for='{0}'>{1}</label>", Target, Text);
        }
    }
}
