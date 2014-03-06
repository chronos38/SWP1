using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP1
{
	class ShowEventArgs : EventArgs
	{
		public ShowEventArgs() { }

		public string Type { get; set; }
		public TimeZoneInfo Timezone { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
	}
}
