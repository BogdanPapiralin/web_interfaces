using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text;
using System.Web.Mvc;
using Web_interfaces.Paging;
using HtmlHelper = System.Web.Mvc.HtmlHelper;
using TagBuilder = System.Web.Mvc.TagBuilder;





namespace Web_interfaces.Paging
{ 
    public static class PagingHelpers
    {
        public static IHtmlContent PageLinks(this IHtmlContent html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
               
                tag.MergeAttribute("href", pageUrl(i));
             
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return new HtmlString(result.ToString());
        }
    }
    
}
