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
	public partial class AnalogForm : Form, IObserver
	{
		public AnalogForm(TimeZoneInfo timeZoneInfo, int x, int y)
		{
			InitializeComponent();

			if (timeZoneInfo != null) {
				Offset = timeZoneInfo.BaseUtcOffset.Hours;
			}
		}

		public virtual void Update(ISubject subject)
		{

		}

		private void AnalogForm_Load(object sender, EventArgs e)
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
		}

		private int Offset { set; get; }
		private int X { set; get; }
		private int Y { set; get; }
	}
}
