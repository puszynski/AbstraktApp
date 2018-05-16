using AbstraktApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AbstraktApp.WebUI.HtmlHelpers
{
    /// <summary>
    /// Własna metoda pomocnicza HTML odnosząca się do ViewModelu PagignInfoViewModel
    /// </summary>
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, 
            PagingInfoViewModel pagingInfo, 
            Func<int, string> PageUrl) // gotowy delegat
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // tworzy znacznik <a>
                tag.MergeAttribute("href", PageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}