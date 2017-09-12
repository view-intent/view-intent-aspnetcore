using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViewIntent.Mvc {
	public class ControllerHelper {
		public async Task<string> Template(HttpContext context) {
			
			return await Task.FromResult<string>("<div>template não carregado</div>");
		}
	}
}
