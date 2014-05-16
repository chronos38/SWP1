using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWP1;

namespace Tests.Mock
{
	class MockClock : Clock
	{
		private static readonly MockClock sInstance = new MockClock();
		public override int Hour { get { return 0; } }
		public override int Minute { get { return 0; } }
		public override int Second { get { return 0; } }

		private MockClock()
		{

		}

		public static MockClock Instance
		{
			get
			{
				return sInstance;
			}
		}

		public override void Start()
		{

		}

		public override void Stop()
		{

		}

		public override void Set(int h, int m, int s)
		{

		}

		public override void IncDec(int h, int m, int s)
		{

		}
		public override void Attach(IObserver observer)
		{
			
		}

		public override void Detach(IObserver observer)
		{

		}

		public override void Notify()
		{

		}
	}
}
