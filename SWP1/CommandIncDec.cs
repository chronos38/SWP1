using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWP1
{
	class CommandIncDec : ICommand
	{
		public CommandIncDec()
		{
		}

		public virtual void Execute(EventArgs a)
		{
			Clock clock = Clock.Instance;
			ClockEventArgs args = (ClockEventArgs)a;
			clock.IncDec(args.Hour, args.Minute, args.Second);
			
			// set arguments for undo/redo
			args.Hour *= -1;
			args.Minute *= -1;
			args.Second *= -1;
		}
	}
}
