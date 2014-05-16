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
		[TestMethod]
		public void MockClockIsReplacingClock()
		{
			using (ShimsContext.Create()) {
				ShimClock.InstanceGet = () => { return MockClock.Instance; };
				Assert.AreEqual(MockClock.Instance.GetType(), Clock.Instance.GetType());
			}
		}
	}
}
