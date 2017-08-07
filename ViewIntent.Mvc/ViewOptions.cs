using System;
using System.Collections.Generic;
using System.Text;

namespace ViewIntent.Mvc {
	public enum ViewIntentType { Razor, Vuejs, Reactjs, Ractivejs };
	public class ViewOptions {
		public string Title { get; set; }
		public string ViewId { get; set; }
		public string HolderId { get; set; }

		public ViewIntentType Type { get; set; }
		public bool Cache { get; set; }
		public List<string> Require { get; set; }
		public List<string> ActiveViews { get; set; }

		//public enum DynamicType { Razor, Vue };

		//public string Path { get; set; }
	}
}
