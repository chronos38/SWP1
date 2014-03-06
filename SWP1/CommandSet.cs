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

		public virtual void Execute(EventArgs args)
		{
		}

		public virtual void Undo()
		{
		}
	}
}
