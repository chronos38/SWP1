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

		public new void Start()
		{

		}

		public new void Stop()
		{

		}

		public new void Set(int h, int m, int s)
		{

		}

		public new void IncDec(int h, int m, int s)
		{

		}
		public new virtual void Attach(IObserver observer)
		{
			
		}

		public new virtual void Detach(IObserver observer)
		{

		}

		public new virtual void Notify()
		{

		}
	}
}
