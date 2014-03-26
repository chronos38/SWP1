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
				Title = timeZoneInfo.DisplayName;
			} else {
				Offset = 0;
				Title = "UTC";
			}
		}

		public virtual void Update(ISubject subject)
		{
			try {
				// invoke label
				Invoke(new Action(UpdateClock));
			} catch {
				// haha, there is no error handling here
			}
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

			_radius = this.pnlClock.Width / 2;
			this.Location = point;
			this.Text = String.Format("Digital: {0}", Title);

			UpdateClock();
		}

		private void AnalogForm_Paint(object sender, PaintEventArgs e)
		{
			// variables
			Brush cyan = Brushes.Cyan;
			Brush magenta = Brushes.Magenta;
			Pen pen = new Pen(Color.Black);

			// drawing
			e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.ClipRectangle);
			DrawClock(e, pen);
			DrawMinute(e, pen, cyan);
			DrawHour(e, pen, magenta);
			DrawSecond(e, pen);

			// update
			Update();
		}

		private void DrawHour(PaintEventArgs e, Pen pen, Brush brush)
		{
			// variables
			int hour = (Hour % 12);
			double adjustment = ((hour - 2) % 12) * HOUR + (Minute / 2) * ARC;
			double adjustmentMirror = ((hour + 4) % 12) * HOUR + (Minute / 2) * ARC;
			double radius = _radius - 64;
			Rectangle clip = e.ClipRectangle;
			PointF start = new PointF(
				(float)((radius / 8) * Math.Cos(adjustmentMirror)) + clip.Width / 2,
				(float)((radius / 8) * Math.Sin(adjustmentMirror)) + clip.Height / 2
			), end = new PointF(
				(float)(radius * Math.Cos(adjustment)) + clip.Width / 2,
				(float)(radius * Math.Sin(adjustment)) + clip.Height / 2
			), left = new PointF(
				(float)((radius / 16) * Math.Cos(ARC * hour)) + clip.Width / 2,
				(float)((radius / 16) * Math.Sin(ARC * hour)) + clip.Height / 2
			), right = new PointF(
				-1 * (float)((radius / 16) * Math.Cos(ARC * hour)) + clip.Width / 2,
				-1 * (float)((radius / 16) * Math.Sin(ARC * hour)) + clip.Height / 2
			);
			PointF[] points = new PointF[4] { start, left, end, right };

			// drawing
			e.Graphics.FillPolygon(brush, points);
			e.Graphics.DrawPolygon(pen, points);
		}

		private void DrawMinute(PaintEventArgs e, Pen pen, Brush brush)
		{
			// variables
			int adjustment = (Minute - 15) % 60;
			int adjustmentMirror = (adjustment + 30) % 60;
			double radius = _radius - 32;
			Rectangle clip = e.ClipRectangle;
			PointF start = new PointF(
				(float)((radius / 8) * Math.Cos(UNIT * adjustmentMirror)) + clip.Width / 2,
				(float)((radius / 8) * Math.Sin(UNIT * adjustmentMirror)) + clip.Height / 2
			), end = new PointF(
				(float)(radius * Math.Cos(UNIT * adjustment)) + clip.Width / 2,
				(float)(radius * Math.Sin(UNIT * adjustment)) + clip.Height / 2
			), left = new PointF(
				(float)((radius / 16) * Math.Cos(UNIT * Minute)) + clip.Width / 2,
				(float)((radius / 16) * Math.Sin(UNIT * Minute)) + clip.Height / 2
			), right = new PointF(
				-1 * (float)((radius / 16) * Math.Cos(UNIT * Minute)) + clip.Width / 2,
				-1 * (float)((radius / 16) * Math.Sin(UNIT * Minute)) + clip.Height / 2
			);

			PointF[] points = new PointF[4] { start, left, end, right };

			// drawing
			e.Graphics.FillPolygon(brush, points);
			e.Graphics.DrawPolygon(pen, points);
		}

		private void DrawSecond(PaintEventArgs e, Pen pen)
		{
			// variables
			int adjustment = (Second - 15) % 60;
			int adjustmentMirror = (adjustment + 30) % 60;
			double radius = _radius - 8;
			Rectangle clip = e.ClipRectangle;
			PointF start = new PointF(
				(float)((radius / 4) * Math.Cos(UNIT * adjustmentMirror)) + clip.Width / 2,
				(float)((radius / 4) * Math.Sin(UNIT * adjustmentMirror)) + clip.Height / 2
			), end = new PointF(
				(float)(radius * Math.Cos(UNIT * adjustment)) + clip.Width / 2,
				(float)(radius * Math.Sin(UNIT * adjustment)) + clip.Height / 2
			);

			// drawing
			e.Graphics.DrawLine(pen, start, end);
			e.Graphics.FillEllipse(
				new SolidBrush(Color.Black), 
				new Rectangle(
					clip.Width / 2 - 4,
					clip.Height / 2 - 4,
					8,
					8
				)
			);
		}

		private void DrawClock(PaintEventArgs e, Pen pen)
		{
			// variables
			double radius = _radius - 16;
			Rectangle c = e.ClipRectangle;
			Graphics g = e.Graphics;

			// draw circle
			g.DrawEllipse(pen, e.ClipRectangle);

			// draw lines
			for (int i = 0; i < 12; i++) {
				g.DrawLine(
					pen,
					new PointF(
						(float)((radius) * Math.Cos(HOUR * i)) + c.Width / 2,
						(float)((radius) * Math.Sin(HOUR * i)) + c.Height / 2
					),
					new PointF(
						(float)((_radius) * Math.Cos(HOUR * i)) + c.Width / 2,
						(float)((_radius) * Math.Sin(HOUR * i)) + c.Height / 2
					)
				);
			}
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
		private string Title { set; get; }

		private double _radius = 0;
		private static readonly double UNIT = 3.141592654 / 30.0;
		private static readonly double HOUR = 3.141592654 / 6.0;
		private static readonly double ARC = 3.141592654 / 180.0;
	}
}
