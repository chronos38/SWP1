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
		public int Hour { get; private set; }
		public int Minute { get; private set; }
		public int Second { get; private set; }
		public int HourOffset { get; private set; }
		public int MinuteOffset { get; private set; }
		public int SecondOffset { get; private set; }

		private Clock()
		{
			// variables
			DateTime utc = DateTime.UtcNow;

			// set initial values
			Second = utc.Second;
			Minute = utc.Minute;
			Hour = utc.Hour;
			HourOffset = MinuteOffset = SecondOffset = 0;

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

		public void Set(int h, int m, int s)
		{
			mUndoBuffer.Add(new Tuple<int, int, int>(Hour, Minute, Second));
			mRedoBuffer.Clear();
			if (h != -1) { Hour = h; }
			if (m != -1) { Minute = m; }
			if (s != -1) { Second = s; }
			Notify();
		}

		public void Increment(bool h, bool m, bool s)
		{
			mUndoBuffer.Add(new Tuple<int, int, int>(Hour, Minute, Second));
			mRedoBuffer.Clear();
			if (h) { Hour += 1; }
			if (m) { Minute += 1; }
			if (s) { Second += 1; }
			Notify();
		}

		public void Decrement(bool h, bool m, bool s)
		{
			mUndoBuffer.Add(new Tuple<int, int, int>(Hour, Minute, Second));
			mRedoBuffer.Clear();
			if (h) { Hour -= 1; }
			if (m) { Minute -= 1; }
			if (s) { Second -= 1; }
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

			foreach (IObserver observer in mObserver) {
				observer.Update(this);
			}
		}

		public void Undo()
		{
			if (mUndoBuffer.Count <= 0) {
				return;
			}
			// variables
			Tuple<int, int, int> undo = mUndoBuffer.Last();

			// set time
			Hour = undo.Item1;
			Minute = undo.Item2;
			Second = undo.Item3;

			// push into redo
			mRedoBuffer.Add(undo);

			// remove last
			mUndoBuffer.RemoveAt(mUndoBuffer.Count - 1);

			Notify();
		}

		public void Redo()
		{
			if (mRedoBuffer.Count <= 0) {
				return;
			}
			// variables
			Tuple<int, int, int> redo = mRedoBuffer.Last();

			// set time
			Hour = redo.Item1;
			Minute = redo.Item2;
			Second = redo.Item3;

			// push into redo
			mUndoBuffer.Add(redo);

			// remove last
			mRedoBuffer.RemoveAt(mUndoBuffer.Count - 1);

			Notify();
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
				Hour = 23 + h;
				Minute = Second = 59;
			} else if (h > 23) {
				Hour = h - 23;
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
				Second = 59;
			} else if (m > 59) {
				Hour += 1;
				Minute = 60 - m;
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
		private List<Tuple<int, int, int>> mUndoBuffer = new List<Tuple<int,int,int>>();
		private List<Tuple<int, int, int>> mRedoBuffer = new List<Tuple<int,int,int>>();
	}
}
