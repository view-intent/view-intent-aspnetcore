using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewIntent.Mvc {
	public enum ViewIntentType { Razor, Vue, React, Ractive };
	public class ViewOptions {
		public string Title { get; set; }
		public string ViewId { get; set; }
		public string HolderId { get; set; }
		public ViewIntentType Type { get; set; }
		public bool Cache { get; set; }
		public List<string> Require { get; set; }
		public List<string> ActiveViews { get; set; }
		public ViewOptions() {
			this.Type = ViewIntentType.Razor;
		}
		public HtmlString Register() {
			StringBuilder tag = new StringBuilder();
			//tag.Append("<script type=\"");
			//str.Append("data-view-info=");

			return new HtmlString($"<script type=\"text/javascript\"></script>");
		}
		private object model = null;
		public void SetModel(object model) {
			
		}
		public string GetModelJson() {
			return Newtonsoft.Json.JsonConvert.SerializeObject(model);
		}
		
		//public enum DynamicType { Razor, Vue };

		//public string Path { get; set; }
	}
}
