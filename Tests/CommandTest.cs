using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mock;
using SWP1;
using SWP1.Fakes;
using Microsoft.QualityTools.Testing.Fakes;

namespace Tests
{
	[TestClass]
	public class CommandTest
	{
		IDisposable _context;

		[TestInitialize]
		public void CommandTestSetup()
		{
			/*_context = ShimsContext.Create();
			var shim = new ShimClock(MockClock.Instance);
			ShimClock.InstanceGet = () => {
				return MockClock.Instance; 
			};*/
		}

		[TestCleanup]
		public void CommandTestCleanup()
		{
			//_context.Dispose();
		}

		[TestMethod]
		public void CommandSetExecutesCorrectly()
		{
			CommandSet set = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(9,9,9);
			Clock.Instance.Set(0, 0, 0);

			set.Execute(args);
			//Assert.AreEqual(true, MockClock.Instance.SetExecuted);
			Assert.AreEqual(0, args.Hour);
			Assert.AreEqual(0, args.Minute);
			Assert.AreEqual(0, args.Second);
			MockClock.Instance.ResetMock();
		}

		[TestMethod]
		public void CommandIncDecExecutesCorrectly()
		{
			CommandIncDec incdec = new CommandIncDec();
			ClockEventArgs args = new ClockEventArgs(9,9,9);

			incdec.Execute(args);
			//Assert.AreEqual(true, MockClock.Instance.IncDecExecuted);
			Assert.AreEqual(-9, args.Hour);
			Assert.AreEqual(-9, args.Minute);
			Assert.AreEqual(-9, args.Second);
			MockClock.Instance.ResetMock();
		}
	}
}
