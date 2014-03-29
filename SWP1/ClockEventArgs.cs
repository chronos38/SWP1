using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP1
{
	class ClockEventArgs : EventArgs
	{
		public ClockEventArgs() { }

		public ClockEventArgs(int h, int m, int s)
		{
			Hour = h;
			Minute = m;
			Second = s;
		}

		public int Hour { get; set; }
		public int Minute { get; set; }
		public int Second { get; set; }
	}
}
