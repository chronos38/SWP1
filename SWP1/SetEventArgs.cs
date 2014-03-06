using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP1
{
	class SetEventArgs : EventArgs
	{
		public SetEventArgs() { }

		public int Hour { get; set; }
		public int Minute { get; set; }
		public int Second { get; set; }
	}
}
