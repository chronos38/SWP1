using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP1
{
	class IncDecEventArgs : EventArgs
	{
		public IncDecEventArgs() { }

		public bool Hour { get; set; }
		public bool Minute { get; set; }
		public bool Second { get; set; }
	}
}
