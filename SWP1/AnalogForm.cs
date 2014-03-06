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

		}

		private void AnalogForm_Load(object sender, EventArgs e)
		{

		}

		private int mOffset = 0;
	}
}
