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
			X = x;
			Y = y;

			if (timeZoneInfo != null) {
				Offset = timeZoneInfo.BaseUtcOffset.Hours;
			}
		}

		public virtual void Update(ISubject subject)
		{
			// invoke label
			Invoke(new Action(UpdateClock));
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			AnalogForm_Paint(this.pnlClock, new PaintEventArgs(this.pnlClock.CreateGraphics(), this.pnlClock.DisplayRectangle));
			base.OnPaint(e);
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

			UpdateClock();
		}

		private void AnalogForm_Paint(object sender, PaintEventArgs e)
		{
			// variables
			Brush cyan = Brushes.Cyan;
			Brush magenta = Brushes.Magenta;
			Pen pen = new Pen(Color.Black);

			// drawing
			DrawClock(e, pen);
			DrawSecond(e, pen);
			DrawMinute(e, pen, cyan);
			DrawHour(e, pen, magenta);

			// update
			Update();
		}

		private void DrawHour(PaintEventArgs e, Pen pen, Brush magenta)
		{
		}

		private void DrawMinute(PaintEventArgs e, Pen pen, Brush cyan)
		{
		}

		private void DrawSecond(PaintEventArgs e, Pen pen)
		{
		}

		private void DrawClock(PaintEventArgs e, Pen pen)
		{
			e.Graphics.DrawEllipse(pen, e.ClipRectangle);
		}

		private void UpdateClock()
		{
			// variables
			Clock clock = Clock.Instance;

			// compute time
			ComputeTime(clock.Hour + Offset);

			// draw
			RaisePaintEvent(this.pnlClock, new PaintEventArgs(this.pnlClock.CreateGraphics(), this.pnlClock.DisplayRectangle));
		}

		private void ComputeTime(int h)
		{
			// variables
			Clock clock = Clock.Instance;

			// compute result
			if (h < 0) {
				Hour = h + 24;
			} else if (h > 23) {
				Hour = h - 24;
			} else {
				Hour = h;
			}

			// minutes and seconds
			Minute = clock.Minute;
			Second = clock.Second;
		}

		private int Offset { get; set; }
		private int Hour { get; set; }
		private int Minute { get; set; }
		private int Second { get; set; }
		private int X { set; get; }
		private int Y { set; get; }
	}
}
