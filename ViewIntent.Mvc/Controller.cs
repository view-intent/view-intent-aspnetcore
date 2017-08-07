using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace ViewIntent.Mvc {
	public class ViewIntentController : Controller {
		public string GetViewName() {
			var area = RouteData.Values["Area"] ?? "Default";
			var controller = RouteData.Values["Controller"];
			var action = RouteData.Values["Action"];
			if (area.ToString() != "Default") {
				return $"../Areas/{area}/{controller}/{action}";
			} else {
				return $"../{controller}/{action}";
			}
		}

		public ViewIntentResult ViewIntent(string viewId) {

			

			return new ViewIntentResult() {
				ViewId = viewId
			};
		}

		//public string View() {
		//	return "viewId";
		//}

		//public new async Task<object> View(ViewOptions options = null) {
		//	return await this.View(GetViewName(), options);
		//}
		//public new async Task<object> View(string viewName, ViewOptions options = null) {
		//	return await this.View(viewName, null, options);
		//}
		//public new async Task<object> View(object model, ViewOptions options = null) {
		//	return await this.View(GetViewName(), model, options);
		//}
	}
}
