using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using System.Fakes;
using SWP1;

namespace Tests
{
	[TestClass]
	public class ClockTest
	{
		Clock _clock;
		IDisposable _shimCon;

		[TestInitialize]
		public void ClockTestSetup()
		{
			_clock = Clock.Instance;
			_shimCon = ShimsContext.Create();
			//Shim to set Time always to 0:0:0
			ShimDateTime.UtcNowGet = () =>
				{
					return new DateTime(2000,1,1,0,0,0);
				};
		}

		[TestCleanup]
		public void ClockTestCleanup()
		{
			_shimCon.Dispose();
		}

		[TestMethod]
		public void ClockIsSingleton()
		{
			Assert.AreSame(Clock.Instance, _clock);
		}

		[TestMethod]
		public void SetIsSettingTimeWorksCorrectly()
		{
			//numbers working
			_clock.Set(1, 2, 3);

			//negative numbers have no effect
			_clock.Set(-12, -1, -23);

			Assert.AreEqual(1, _clock.Hour);
			Assert.AreEqual(2, _clock.Minute);
			Assert.AreEqual(3, _clock.Second);

			// > 24
			_clock.Set(25, 0, 0);
			Assert.AreEqual(1, _clock.Hour);

			// > 60
			_clock.Set(0, 61, 0);
			Assert.AreEqual(1, _clock.Minute);

			_clock.Set(0, 0, 61);
			Assert.AreEqual(1, _clock.Second);
		}
		
		[TestMethod]
		public void IncDecIsProperlyRollingOverWhenIncrementing()
		{
			//Test depends on Set. Merge this test with Set Test?
			_clock.Set(0, 0, 0);

			//seconds rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0,0,1);
			}
			Assert.AreEqual(0, _clock.Hour);
			Assert.AreEqual(2, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);
			
			//minutes rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0,1,0);
			}
			Assert.AreEqual(2, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);
			
			//hours rollover
			for (int i = 0; i < 24; i++) {
				_clock.IncDec(1,0,0);
			}
			Assert.AreEqual(0, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);
		}

		[TestMethod]
		public void IncDecIsProperlyRollingOverWhenDecrementing()
		{
			//Test depends on Set. Merge this test with Set Test?
			_clock.Set(0, 0, 0);

			//seconds rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0,0,-1);
			}
			Assert.AreEqual(23, _clock.Hour);
			Assert.AreEqual(58, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);
			
			//minutes rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0,-1,0);
			}
			Assert.AreEqual(22, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);
			
			//hours rollover
			for (int i = 0; i < 24; i++) {
				_clock.IncDec(-1,0,0);
			}
			Assert.AreEqual(0, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);
		}

	}
}
