﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP1
{
	public interface ICommand
	{
		void Execute(EventArgs args);
		void Undo();
	}
}