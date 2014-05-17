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
			set.Clock = MockClock.Instance;

			set.Execute(args);
			Assert.AreEqual(true, MockClock.Instance.SetExecuted);
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
			incdec.Clock = MockClock.Instance;

			incdec.Execute(args);
			Assert.AreEqual(true, MockClock.Instance.IncDecExecuted);
			Assert.AreEqual(-9, args.Hour);
			Assert.AreEqual(-9, args.Minute);
			Assert.AreEqual(-9, args.Second);
			MockClock.Instance.ResetMock();
		}

		[TestMethod]
		public void CommandSetHourIntervalBeginTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(int.MinValue, 0, 0);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreNotEqual(int.MinValue, com.Clock.Hour);

			args = new ClockEventArgs(-1, 0, 0);
			com.Execute(args);
			Assert.AreNotEqual(-1, com.Clock.Hour);

			args = new ClockEventArgs(0, 0, 0);
			com.Execute(args);
			Assert.AreEqual(0, com.Clock.Hour);

			args = new ClockEventArgs(1, 0, 0);
			com.Execute(args);
			Assert.AreEqual(1, com.Clock.Hour);
		}

		[TestMethod]
		public void CommandSetHourIntervalMiddleTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(11, 0, 0);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreEqual(11, com.Clock.Hour);

			args = new ClockEventArgs(12, 0, 0);
			com.Execute(args);
			Assert.AreEqual(12, com.Clock.Hour);

			args = new ClockEventArgs(13, 0, 0);
			com.Execute(args);
			Assert.AreEqual(13, com.Clock.Hour);
		}

		[TestMethod]
		public void CommandSetHourIntervalEndTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(23, 0, 0);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreEqual(23, com.Clock.Hour);

			args = new ClockEventArgs(24, 0, 0);
			com.Execute(args);
			Assert.AreNotEqual(24, com.Clock.Hour);
			Assert.AreEqual(0, com.Clock.Hour);

			args = new ClockEventArgs(25, 0, 0);
			com.Execute(args);
			Assert.AreNotEqual(25, com.Clock.Hour);

			args = new ClockEventArgs(int.MaxValue, 0, 0);
			com.Execute(args);
			Assert.AreNotEqual(int.MaxValue, com.Clock.Hour);
		}

		[TestMethod]
		public void CommandSetMinuteIntervalBeginTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(0, int.MinValue, 0);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreNotEqual(int.MinValue, com.Clock.Minute);

			args = new ClockEventArgs(0, -1, 0);
			com.Execute(args);
			Assert.AreNotEqual(-1, com.Clock.Minute);

			args = new ClockEventArgs(0, 0, 0);
			com.Execute(args);
			Assert.AreEqual(0, com.Clock.Minute);

			args = new ClockEventArgs(0, 1, 0);
			com.Execute(args);
			Assert.AreEqual(1, com.Clock.Minute);
		}

		[TestMethod]
		public void CommandSetMinuteIntervalMiddleTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(0, 29, 0);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreEqual(29, com.Clock.Minute);

			args = new ClockEventArgs(0, 30, 0);
			com.Execute(args);
			Assert.AreEqual(30, com.Clock.Minute);

			args = new ClockEventArgs(0, 31, 0);
			com.Execute(args);
			Assert.AreEqual(31, com.Clock.Minute);
		}

		[TestMethod]
		public void CommandSetMinuteIntervalEndTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(0, 59, 0);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreEqual(59, com.Clock.Minute);

			args = new ClockEventArgs(0, 60, 0);
			com.Execute(args);
			Assert.AreNotEqual(60, com.Clock.Minute);
			Assert.AreEqual(0, com.Clock.Minute);

			args = new ClockEventArgs(0, 61, 0);
			com.Execute(args);
			Assert.AreNotEqual(61, com.Clock.Minute);

			args = new ClockEventArgs(0, int.MaxValue, 0);
			com.Execute(args);
			Assert.AreNotEqual(int.MaxValue, com.Clock.Minute);
		}

		[TestMethod]
		public void CommandSetSecondIntervalBeginTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(0, 0, int.MinValue);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreNotEqual(int.MinValue, com.Clock.Second);

			args = new ClockEventArgs(0, 0, -1);
			com.Execute(args);
			Assert.AreNotEqual(-1, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 0);
			com.Execute(args);
			Assert.AreEqual(0, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 1);
			com.Execute(args);
			Assert.AreEqual(1, com.Clock.Second);
		}

		[TestMethod]
		public void CommandSetSecondIntervalMiddleTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(0, 0, 29);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreEqual(29, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 30);
			com.Execute(args);
			Assert.AreEqual(30, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 31);
			com.Execute(args);
			Assert.AreEqual(31, com.Clock.Second);
		}

		[TestMethod]
		public void CommandSetSecondIntervalEndTest()
		{
			CommandSet com = new CommandSet();
			ClockEventArgs args = new ClockEventArgs(0, 0, 59);
			// com.Clock = MockClock.Instance;

			com.Execute(args);
			Assert.AreEqual(59, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 60);
			com.Execute(args);
			Assert.AreNotEqual(60, com.Clock.Second);
			Assert.AreEqual(0, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 61);
			com.Execute(args);
			Assert.AreNotEqual(61, com.Clock.Second);

			args = new ClockEventArgs(0, 0, int.MaxValue);
			com.Execute(args);
			Assert.AreNotEqual(int.MaxValue, com.Clock.Second);
		}

		[TestMethod]
		public void IncDecHourIntervalTest()
		{
			CommandIncDec com = new CommandIncDec();
			ClockEventArgs args = new ClockEventArgs(int.MinValue, 0, 0);
			// com.Clock = MockClock.Instance;
			com.Clock.Set(12, 0, 0);

			com.Execute(args);
			Assert.AreEqual(11, com.Clock.Hour);

			args = new ClockEventArgs(-1, 0, 0);
			com.Execute(args);
			Assert.AreEqual(10, com.Clock.Hour);
			
			args = new ClockEventArgs(0, 0, 0);
			com.Execute(args);
			Assert.AreEqual(10, com.Clock.Hour);
			
			args = new ClockEventArgs(1, 0, 0);
			com.Execute(args);
			Assert.AreEqual(11, com.Clock.Hour);
			
			args = new ClockEventArgs(int.MaxValue, 0, 0);
			com.Execute(args);
			Assert.AreEqual(12, com.Clock.Hour);
		}

		[TestMethod]
		public void IncDecMinuteIntervalTest()
		{
			CommandIncDec com = new CommandIncDec();
			ClockEventArgs args = new ClockEventArgs(0, int.MinValue, 0);
			// com.Clock = MockClock.Instance;
			com.Clock.Set(0, 30, 0);

			com.Execute(args);
			Assert.AreEqual(29, com.Clock.Minute);

			args = new ClockEventArgs(0, -1, 0);
			com.Execute(args);
			Assert.AreEqual(28, com.Clock.Minute);

			args = new ClockEventArgs(0, 0, 0);
			com.Execute(args);
			Assert.AreEqual(28, com.Clock.Minute);

			args = new ClockEventArgs(0, 1, 0);
			com.Execute(args);
			Assert.AreEqual(29, com.Clock.Minute);

			args = new ClockEventArgs(0, int.MaxValue, 0);
			com.Execute(args);
			Assert.AreEqual(30, com.Clock.Minute);
		}

		[TestMethod]
		public void IncDecSecondIntervalTest()
		{
			CommandIncDec com = new CommandIncDec();
			ClockEventArgs args = new ClockEventArgs(0, 0, int.MinValue);
			// com.Clock = MockClock.Instance;
			com.Clock.Set(0, 0, 30);

			com.Execute(args);
			Assert.AreEqual(29, com.Clock.Second);

			args = new ClockEventArgs(0, 0, -1);
			com.Execute(args);
			Assert.AreEqual(28, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 0);
			com.Execute(args);
			Assert.AreEqual(28, com.Clock.Second);

			args = new ClockEventArgs(0, 0, 1);
			com.Execute(args);
			Assert.AreEqual(29, com.Clock.Second);

			args = new ClockEventArgs(0, 0, int.MaxValue);
			com.Execute(args);
			Assert.AreEqual(30, com.Clock.Second);
		}
	}
}
