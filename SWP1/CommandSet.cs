using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWP1
{
	class CommandSet : ICommand
	{
		public CommandSet()
		{
			Clock = SWP1.Clock.Instance;
		}

		public Clock Clock { get; set; }

		public virtual void Execute(EventArgs a) 
		{
			// variables
			//Clock clock = Clock.Instance;
			int h = Clock.Hour;
			int m = Clock.Minute;
			int s = Clock.Second;

			// set clock
			ClockEventArgs args = (ClockEventArgs)a;
			Clock.Set(args.Hour, args.Minute, args.Second);

			// set args for undo/redo
			args.Hour = h;
			args.Minute = m;
			args.Second = s;
		}
	}
}
