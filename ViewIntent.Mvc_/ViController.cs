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
	public class ViController : Controller {
		public string Area {
			get { return RouteData.Values["Area"]?.ToString() ?? "Default"; }
		}
		public string Controller {
			get { return RouteData.Values["Controller"]?.ToString(); }
		}
		public string Action {
			get { return RouteData.Values["Action"]?.ToString(); }
		}
		public string Path {
			get { return HttpContext.Request.Path.Value; }
		}
		public string GetViewName() {
			if (Area.ToString() != "Default") {
				return $"../Areas/{Area}/{Controller}/{Action}";
			} else {
				return $"../{Controller}/{Action}";
			}
		}
		public string RequestHeadInfo() {
			if(Request.Headers["vi"].Count > 0) {
				return (Request.Headers["vi"].Count > 0 ? Request.Headers["vi"][0].ToString().ToLowerInvariant() : null);
			} else {
				return (Request.Query["vi"].Count > 0 ? Request.Query["vi"][0].ToString().ToLowerInvariant() : null);
			}
		}
		public async Task<object> View(ViewOptions options = null) {
			return await this.View(GetViewName(), options);
		}
		public new async Task<object> View(string viewName) {
			return await this.View(viewName, null);
		}
		public new async Task<object> View(object model) {
			return await this.View(GetViewName(), model);
		}
		public new async Task<object> View(string viewName, object model) {
			if(model == null) {
				model = new ViModel();
			}
			if(model is IViModel) {
				IViModel viModel = model as IViModel;
				return View(viewName, model);
			} else {
				
				if(model is ViewOptions) {
					ViewOptions viewOptions = model as ViewOptions;
					return View(viewName, model);
				} else {
					return View(viewName, model);
				}
			}



			//var s = await View(viewName, model);
			//return s;


			








			//string tplUrl = ("http://localhost:50042/login/home/str1/");
			//var c = new System.Net.Http.HttpClient();

			


			//ActionContext ctx = ActionContext();

			//var pv = base.PartialView();
			//pv.ExecuteResult();


			//return Request.Path.Value;
			//var string1 = await c.GetAsync("http://localhost:50042/login/home/str1/");
			//return string1;

			//return PartialViewResult()
			//var b = Response.Body;
			//Response.Body.Flush();


			//string dynamicRequestHeader = (Request.Headers["vi"].Count > 0 ? Request.Headers["vi"][0].ToString().ToLowerInvariant() : null);
			//string dynamicRequestQuery = (Request.Query["vi"].Count > 0 ? Request.Query["vi"][0].ToString().ToLowerInvariant() : null);
			//string typeValue = options.Type.ToString().ToLowerInvariant();
			// properties ---------------------------------------
			//var area = RouteData.Values["Area"];
			//var controller = RouteData.Values["Controller"];
			//var action = RouteData.Values["Action"];
			//var path = HttpContext.Request.Path.Value;
			//// --------------------------------------------------
			//options.ViewId = 



			//// --------------------------------------------------
			//options.ViewId = GetViewId(options.ViewId);
			//options.HolderId = GetHolderId(options.HolderId);
			//ViewData["viewOptions"] = options;
			//// output ----------------------------------------
			//if (dynamicRequestQuery != null) {
			//	var outputModel = new OutputModel() {
			//		Title = options.Title,
			//		Path = path,
			//		Type = options.Type,
			//		Model = model,
			//		ViewId = options.ViewId,
			//		HolderId = options.HolderId,
			//		Cache = options.Cache,
			//		//AllowMultiple = options.AllowMultiple,
			//		PreRequire = options.PreRequire,
			//		PosRequire = options.PosRequire,
			//		PushState = options.PushState,
			//		ActiveViews = options.ActiveViews,
			//		ViewTypes = options.ViewTypes
			//	};

			//	// Headers ------------------------------
			//	Response.Headers.Add("Dynamic", outputModel.GetDynamicHead());
			//	// template and model
			//	if (dynamicRequestQuery == "template" || dynamicRequestQuery == "partial" || (dynamicRequestQuery == "model" && options.Type == DynamicType.Razor)) {
			//		return base.PartialView(viewName, model);
			//	} else if (dynamicRequestQuery == "model") {
			//		outputModel.Model = model;
			//		return Task.FromResult<object>(outputModel).Result;
			//	}
			//}
			// ------------------
			//ViewData["viewOptions"] = options;


			return base.View(viewName, model);
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
