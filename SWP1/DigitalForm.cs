using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWP1
{
	public partial class DigitalForm : Form, IObserver
	{
		public DigitalForm(TimeZoneInfo timeZoneInfo, int x, int y)
		{
			InitializeComponent();

			// location
			X = x;
			Y = y;

			if (timeZoneInfo != null) {
				Offset = timeZoneInfo.BaseUtcOffset.Hours;
			}
		}

		public virtual void Update(ISubject subject)
		{
			// variables
			Clock clock = (Clock)subject;

			// invoke label
			Invoke(new Action(UpdateClock));
		}

		private void DigitalForm_Load(object sender, EventArgs e)
		{
			// variables
			Clock clock = Clock.Instance;

			// location
			Point point = new Point();

			if (X != -1) {
				point.X = X;
			} else {
				point.X = Location.X;
			}

			if (Y != -1) {
				point.Y = Y;
			} else {
				point.Y = Location.Y;
			}

			Location = point;

			// set time
			this.lblClock.Text = String.Format("{0:00}:{1:00}:{2:00}", clock.Hour + Offset, clock.Minute, clock.Second);
			this.lblClock.Left = this.Size.Width / 2 - this.lblClock.Size.Width / 2;
			this.lblClock.Top = 16;

			// register window
			clock.Attach(this);
		}

		private void UpdateClock()
		{
			// variables
			Clock clock = Clock.Instance;

			// set time
			this.lblClock.Text = String.Format("{0:00}:{1:00}:{2:00}", clock.Hour + Offset, clock.Minute, clock.Second);
			this.lblClock.Left = this.Size.Width / 2 - this.lblClock.Size.Width / 2;
		}

		private int Offset { set; get; }
		private int X { set; get; }
		private int Y { set;get; }
	}
}
