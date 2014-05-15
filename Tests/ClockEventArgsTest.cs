using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWP1;

namespace Tests
{
	[TestClass]
	public class ClockEventArgsTest
	{
		[TestMethod]
		public void ClockEventArgsContructorCreatesCorrectValues()
		{
			ClockEventArgs args = new ClockEventArgs();
			Assert.AreEqual(0, args.Hour);
			Assert.AreEqual(0, args.Minute);
			Assert.AreEqual(0, args.Second);

			args = new ClockEventArgs(1, 2, 3);
			Assert.AreEqual(1, args.Hour);
			Assert.AreEqual(2, args.Minute);
			Assert.AreEqual(3, args.Second);
		}

		[TestMethod]
		public void ClockEventArgsAttributesAreSetable()
		{
			ClockEventArgs args = new ClockEventArgs();
			args.Hour = int.MaxValue;
			Assert.AreEqual(int.MaxValue, args.Hour);
			args.Minute = int.MaxValue;
			Assert.AreEqual(int.MaxValue, args.Minute);
			args.Second = int.MaxValue;
			Assert.AreEqual(int.MaxValue, args.Second);
		}
	}
}
