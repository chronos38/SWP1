using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SWP1
{
	class Clock : ISubject
	{
		private Clock()
		{
			// set initial values
			Second = DateTime.UtcNow.Second;
			Minute = DateTime.UtcNow.Minute;
			Hour = DateTime.UtcNow.Hour;

			// start timer
			mTimer.Interval = 1000;
			mTimer.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs args) => {
				DateTime utc = DateTime.UtcNow;

				Second = utc.Second;
				Minute = utc.Minute;
				Hour = utc.Hour;

				// notify all observer
				Notify();
			});

			mTimer.Start();
		}

		public static Clock Instance
		{
			get
			{
				return sInstance;
			}
		}

		public int Hour { get; private set; }
		public int Minute { get; private set; }
		public int Second { get; private set; }

		public virtual void Attach(IObserver observer)
		{
			lock (mObserver) {
				mObserver.Add(observer);
				mObserver = mObserver.Distinct().ToList();
			}
		}

		public virtual void Detach(IObserver observer)
		{
			lock (mObserver) {
				if (!mObserver.Remove(observer)) {
					throw new ApplicationException("Couldn't detach observer from list.");
				}
			}
		}

		public virtual void Notify()
		{
			lock (mObserver) {
				foreach (IObserver observer in mObserver) {
					observer.Update(this);
				}
			}
		}

		private static readonly Clock sInstance = new Clock();
		private List<IObserver> mObserver = new List<IObserver>();
		private Timer mTimer = new Timer();
	}
}
