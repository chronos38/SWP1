using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SWP1
{
	public class Clock : ISubject
	{
		public int Hour { get; private set; }
		public int Minute { get; private set; }
		public int Second { get; private set; }
		public int HourOffset { get; private set; }
		public int MinuteOffset { get; private set; }
		public int SecondOffset { get; private set; }

		protected Clock()
		{
			// variables
			DateTime utc = DateTime.UtcNow;

			// set initial values
			Second = utc.Second;
			Minute = utc.Minute;
			Hour = utc.Hour;
			HourOffset = MinuteOffset = SecondOffset = 0;


		}

		~Clock()
		{
			mTimer.Stop();
		}

		public static Clock Instance
		{
			get
			{
				return sInstance;
			}
		}

		public void Start()
		{
			// start timer
			mTimer.Interval = 1000;
			mTimer.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs args) => {
				// increment seconds
				Second += 1;
				// notify all observer
				Notify();
			});
			mTimer.Start();
		}

		public void Stop()
		{
			mTimer.Stop();
		}

		public void Set(int h, int m, int s)
		{
			if (!(h < 0)) { Hour = h; }
			if (!(m < 0)) { Minute = m; }
			if (!(s < 0)) { Second = s; }
			Notify();
		}

		public void IncDec(int h, int m, int s)
		{
			if (h > 0) { Hour += 1; } 
			else if (h < 0) { Hour -= 1; }
			if (m > 0) { Minute += 1; } 
			else if (m < 0) { Minute -= 1; }
			if (s > 0) { Second += 1; } 
			else if (s < 0) { Second -= 1; }
			Notify();
		}

		public virtual void Attach(IObserver observer)
		{
			mObserver.Add(observer);
		}

		public virtual void Detach(IObserver observer)
		{
			if (!mObserver.Remove(observer)) {
				throw new ApplicationException("Couldn't detach observer from list.");
			}
		}

		public virtual void Notify()
		{
			ComputeTime();

			try {
				foreach (IObserver observer in mObserver) {
					observer.Update(this);
				}
			} catch {
				// why? because I can!
			}
		}

		private void ComputeTime()
		{
			// compute result
			ComputeSeconds();
			ComputeMinutes();
			ComputeHours();
		}

		private void ComputeHours()
		{
			int h = (Hour);

			if (h < 0) {
				Hour = 24 + h;
			} else if (h > 23) {
				Hour = h - 24;
				Minute = Second = 0;
			} else {
				Hour = h;
			}
		}

		private void ComputeMinutes()
		{
			int m = (Minute);

			if (m < 0) {
				Hour -= 1;
				Minute = 60 + m;
			} else if (m > 59) {
				Hour += 1;
				Minute = m - 60;
				Second = 0;
			} else {
				Minute = m;
			}
		}

		private void ComputeSeconds()
		{
			int s = (Second);

			if (s < 0) {
				Minute -= 1;
				Second = 60 + s;
			} else if (s > 59) {
				Minute += 1;
				Second = s - 60;
			} else {
				Second = s;
			}
		}

		private static readonly Clock sInstance = new Clock();
		private List<IObserver> mObserver = new List<IObserver>();
		private Timer mTimer = new Timer();
	}
}
