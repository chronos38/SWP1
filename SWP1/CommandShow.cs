using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SWP1
{
	class CommandShow : ICommand
	{
		public CommandShow()
		{
		}

		public virtual void Execute(EventArgs a)
		{
			// variables
			Form form = null;
			ShowEventArgs args = (ShowEventArgs)a;

			// execution logic
			if (args.Type == "Digital") {
				// new window
				form = new DigitalForm(args.Timezone, args.X, args.Y);
			} else if (args.Type == "Analog") {
				// new window
				form = new AnalogForm(args.Timezone, args.X, args.Y);
			}

			// set closing event
			form.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs arg) => {
				Clock.Instance.Detach((IObserver)sender);
			});

			// attach window
			Clock.Instance.Attach((IObserver)form);

			// run window
			form.Show();
		}
	}
}
