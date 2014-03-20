using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWP1
{
	class CommandDecrement : ICommand
	{
		public CommandDecrement()
		{
		}

		public virtual void Execute(EventArgs a)
		{
			Clock clock = Clock.Instance;
			IncDecEventArgs args = (IncDecEventArgs)a;
			clock.Increment(args.Hour, args.Minute, args.Second);
		}

		public virtual void Undo()
		{
		}
	}
}
