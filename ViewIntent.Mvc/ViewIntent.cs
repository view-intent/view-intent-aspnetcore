using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViewIntent.Mvc {

	public interface IActionIntentResult : IActionResult {
		string ViewId { get; set; }
	}
	public class ViewIntentResult : ViewResult, IActionIntentResult {
		public string ViewId { get; set; }
		public override async Task ExecuteResultAsync(ActionContext context) {


			string ctx = context.RouteData.Values["Action"].ToString();
			//var objectResult = new ObjectResult(_result.Exception ?? _result.Data) {
			//	StatusCode = _result.Exception != null
			//		? StatusCodes.Status500InternalServerError
			//		: StatusCodes.Status200OK
			//};	

			context.HttpContext.Response.Headers.Add("viewId", ctx);



			//await objectResult.ExecuteResultAsync(context);
			//throw new NotImplementedException();
			await base.ExecuteResultAsync(context);

		}
	}
}
