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
			SetEventArgs args = (SetEventArgs)a;
			clock.Set(args.Hour, args.Minute, args.Second);
		}

		public virtual void Undo()
		{
		}
	}
}
