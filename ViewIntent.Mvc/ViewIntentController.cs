using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ViewIntent.Mvc {
	public class ViewIntentService {
		public string nome = "ViewInteint ok injecte 2";
		//public HttpContext HttpContext { get; set; }
		public ViewIntentService() { }
		//public string GetQueryKey() {
		//	return this.HttpContext.Request.Query["key"];
		//}
	}


	public static class ViewIntentServiceExtensions {
		public static IServiceCollection AddViewIntent(this IServiceCollection services) {
			services.AddScoped<ViewIntentService>();
			services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
			return services;
		}
	}





	public class ViewIntentController : Controller {
		public ViewIntentService ViewIntentService { get; set; }
		public ActionContext ActionContext { get; set; }

		public ViewIntentController(ViewIntentService viewIntentService) {
			this.ViewIntentService = viewIntentService;
			//this.ViewIntentService.HttpContext = this.HttpContext;
			//ActionContext = new ActionContext(this.HttpContext, this.RouteData, this.ControllerContext.ActionDescriptor);
		}



		//Task ExecuteResultAsync(ActionContext context);
		public class ViewIntentResult : ActionResult {
			private HttpContext HttpContext {get;set;}
			public ViewIntentResult( HttpContext httpContext) {
				this.HttpContext = httpContext;
			}
			public new async Task ExecuteResultAsync(ActionContext context) {
				//await context.HttpContext.Response.WriteAsync("ok", new System.Threading.CancellationToken());
				//using (var sw = new StringWriter()) {
				//	var viewContext = new ViewContext(
				//		context, 
				//	)
				//}
				//throw new NotImplementedException();
				context.HttpContext.Response.StatusCode = 204;
				await context.HttpContext.Response.WriteAsync("ok");
			}
		}
		// Views -----------------------------------------
		//public new ViewIntentResult View() {
		//	return new ViewIntentResult(this.HttpContext);
		//	//throw new NotImplementedException();
		//}
		//public new object View(string viewName, object model) {
			
		//	throw new NotImplementedException();
		//}
		//public new object View(object model) {
		//	throw new NotImplementedException();
		//}
		//public new object View(string viewName) {
			
		//	//Url.Action()

		//	throw new NotImplementedException();
		//}
	}
}
