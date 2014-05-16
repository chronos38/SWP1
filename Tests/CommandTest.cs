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
			_context = ShimsContext.Create();
			var shim = new ShimClock(MockClock.Instance);
			ShimClock.InstanceGet = () => {
				return MockClock.Instance; 
			};


		}

		[TestCleanup]
		public void CommandTestCleanup()
		{
			_context.Dispose();
		}

		[TestMethod]
		public void CommandSetExecutesCorrectly()
		{
			CommandSet set = new CommandSet();
			ClockEventArgs args = new ClockEventArgs();
			args.Hour = 9;
			args.Minute = 9;
			args.Second = 9;

			set.Execute(args);
			Assert.AreEqual(0, args.Hour);
			Assert.AreEqual(0, args.Minute);
			Assert.AreEqual(0, args.Second);
		}
	}
}
