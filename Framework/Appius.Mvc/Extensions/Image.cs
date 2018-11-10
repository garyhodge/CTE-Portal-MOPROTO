using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AppiusMVC.Html
{
    public static partial class Extensions
    {
        public static string Image(this HtmlHelper Helper, string Src, string Alt, string Class)
        {
            var builder = new TagBuilder("img");

            builder.MergeAttribute("src", Src);
            builder.MergeAttribute("alt", Alt);

            if (!string.IsNullOrEmpty(Class))
            {
                builder.MergeAttribute("class", Class);
            }

            var mvcHtml = MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));

            return mvcHtml.ToHtmlString();
        }
    }
}
