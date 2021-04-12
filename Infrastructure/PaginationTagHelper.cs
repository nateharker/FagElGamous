using FagElGamous.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;
        //Constructor to create url helper factory to use throughout class
        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        public PageNumberingInfo PageInfo { get; set; }

        //Our own dictionary (key value pairs) that we are creating
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        //Properties to help style the pagination numbers
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Overriding inherited Process function
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlInfo.GetUrlHelper(ViewContext);

            TagBuilder finishedTag = new TagBuilder("div");

            for (int i = 1; i <= PageInfo.NumPages; i++) //Loop to dynamically build the number and link for each page of the data
            {
                TagBuilder individualTag = new TagBuilder("a");
                KeyValuePairs["pageNum"] = i;
                individualTag.Attributes["href"] = urlHelper.Action("Index", KeyValuePairs);

                if (PageClassesEnabled) //If Page classes enabled is set to true in an HTML element attribute, do the following
                {
                    individualTag.AddCssClass(PageClass);
                    individualTag.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal); //If number is selected, apply different styling than if it isn't
                }

                individualTag.InnerHtml.AppendHtml(i.ToString());

                finishedTag.InnerHtml.AppendHtml(individualTag);
            }
            output.Content.AppendHtml(finishedTag.InnerHtml);
        }

    }
}