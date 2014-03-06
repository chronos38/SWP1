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
			Point point = new Point();

			if (x != -1) { 
				point.X = x;
			} else {
				point.X = Location.X;
			}
			
			if (y != -1) { 
				point.Y = y;
			} else {
				point.Y = Location.Y;
			}

			Location = point;

			if (timeZoneInfo != null) {
				mOffset = timeZoneInfo.BaseUtcOffset.Hours;
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
			int adjustment = 0;
			Clock clock = Clock.Instance;

			// set time
			this.lblClock.Text = String.Format("{0:00}:{1:00}:{2:00}", clock.Hour + mOffset, clock.Minute, clock.Second);
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
			this.lblClock.Text = String.Format("{0:00}:{1:00}:{2:00}", clock.Hour + mOffset, clock.Minute, clock.Second);
			this.lblClock.Left = this.Size.Width / 2 - this.lblClock.Size.Width / 2;
		}

		private int mOffset = 0;
	}
}
