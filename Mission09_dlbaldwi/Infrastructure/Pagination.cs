using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission09_dlbaldwi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dlbaldwi.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class Pagination : TagHelper
    {
        //returning null
        private IUrlHelperFactory uhf;
        public Pagination(IUrlHelperFactory helper)
        {
            uhf = helper;
        }

        [ViewContext][HtmlAttributeNotBound] public ViewContext vc { get; set; }
        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div");
            for (int i = 1; i < PageModel.NumPages + 1; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrPage
                        ? PageClassSelected : PageClassNormal);
                }
                tb.InnerHtml.Append(i.ToString());
                final.InnerHtml.AppendHtml(tb);
            }

            output.Content.AppendHtml(final.InnerHtml);
        }
    }
}
