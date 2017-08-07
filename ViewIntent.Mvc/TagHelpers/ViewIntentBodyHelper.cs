using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ViewIntent.Mvc.TagHelpers {
	[HtmlTargetElement("view-intent-body", TagStructure = TagStructure.NormalOrSelfClosing)]
	public class ViewIntentBodyHelper : TagHelper {
		private const string ViewId = "{{viewId}}";
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
			output.TagName = "div";
			output.TagMode = TagMode.StartTagAndEndTag;
			var content = await output.GetChildContentAsync();
			var contentString = content.GetContent();
			

			//var target = content.GetContent() + "@" + EmailDomain;
			//output.Attributes.SetAttribute("href", "mailto:" + target);


			output.Content.SetHtmlContent(contentString);
			//output.Content.SetContent(contentString);
		}
	}
}
