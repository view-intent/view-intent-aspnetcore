using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq.Expressions;

namespace ViewIntent.Mvc {
	public interface IViModel {
		ViewOptions ViewOptions { get; set; }
	}
	public interface IViModel<T> : IViModel where T : new() {
		T Postable { get; set; }
	}

	public class ViModel : IViModel {
		public ViewOptions ViewOptions { get; set; }
		public HtmlString ViewRoot() {
			var model = this.MemberwiseClone();
			var modelJson = JsonConvert.SerializeObject(model);
			// ----------------------------
			StringBuilder sb = new StringBuilder();
			sb.Append($"<script type=\"application/json\">");
			sb.Append(modelJson);
			sb.Append($"</script>");
			return new HtmlString(sb.ToString());
		}
	}
}
