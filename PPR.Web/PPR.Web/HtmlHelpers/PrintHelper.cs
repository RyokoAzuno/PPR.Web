using PPR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PPR.Web.HtmlHelpers
{
    public static class PrintHelper
    {
        public static MvcHtmlString PrintPage(this HtmlHelper helper, string innerText, object htmlAttributes = null)
        {
            TagBuilder a = new TagBuilder("a");
            a.MergeAttribute("href", "javascript:window.print()");
            a.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            a.SetInnerText(innerText);
            return new MvcHtmlString(a.ToString());
        }

        public static MvcHtmlString PageLinks(this HtmlHelper helper, PagingInfo pagingInfo, Func<int, string> pageUrl, string css)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", pageUrl(i));
                a.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    a.AddCssClass("selected");
                    a.AddCssClass("btn-primary");
                }
                a.AddCssClass(css);
                sb.Append(a.ToString());
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}