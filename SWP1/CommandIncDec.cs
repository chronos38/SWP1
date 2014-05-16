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
			Clock = SWP1.Clock.Instance;
		}

		public Clock Clock { get; set; }

		public virtual void Execute(EventArgs a)
		{
			//Clock Clock = Clock.Instance;
			ClockEventArgs args = (ClockEventArgs)a;
			Clock.IncDec(args.Hour, args.Minute, args.Second);
			
			// set arguments for undo/redo
			args.Hour *= -1;
			args.Minute *= -1;
			args.Second *= -1;
		}
	}
}
