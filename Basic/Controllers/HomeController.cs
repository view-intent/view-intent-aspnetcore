using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewIntent.Mvc;

namespace Basic.Controllers {
	public class HomeController : ViewIntentController {
		public IActionIntentResult Index() {
			var s = Status();
			//return s.ViewId;

			return Status();
		}
		//public IActionResult Status() {
		//	return View();
		//}
		public IActionIntentResult Status() {

			return ViewIntent("status");
		}
	}
}
