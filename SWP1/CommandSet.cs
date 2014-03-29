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
		}

		public virtual void Execute(EventArgs a)
		{
			// variables
			Clock clock = Clock.Instance;
			int h = clock.Hour;
			int m = clock.Minute;
			int s = clock.Second;

			// set clock
			ClockEventArgs args = (ClockEventArgs)a;
			clock.Set(args.Hour, args.Minute, args.Second);

			// set args for undo/redo
			args.Hour = h;
			args.Minute = m;
			args.Second = s;
		}
	}
}
