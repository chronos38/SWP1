using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mock;
using SWP1;
using SWP1.Fakes;
using Microsoft.QualityTools.Testing.Fakes;

namespace Tests
{
	[TestClass]
	public class MockClockTest
	{
		//IDisposable _context;

		[TestInitialize]
		public void MockClockTestSetup()
		{
			/*_context = ShimsContext.Create();
			var shim = new ShimClock(MockClock.Instance);
			ShimClock.InstanceGet = () => {
				return MockClock.Instance; 
			};*/

		}

		[TestCleanup]
		public void MockClockTestCleanup()
		{
			//_context.Dispose();
		}

		[TestMethod]
		public void MockClockIsReplacingClock()
		{
			//Assert.AreEqual(MockClock.Instance.GetType(), Clock.Instance.GetType());
		}
	}
}
