using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP1
{
	public interface ICommand
	{
		Clock Clock { get; set; }
		void Execute(EventArgs args);
	}
}
