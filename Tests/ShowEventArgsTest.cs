using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWP1;

namespace Tests
{
	//! Diese Testklasse überprüft die SchoEventArgs
	[TestClass]
	public class ShowEventArgsTest
	{
		//! Testcase überprüft ob die Standardwerte korrekt gesetzt wurden.
		[TestMethod]
		public void ShowEventArgsContructorCreatesCorrectValues()
		{
			ShowEventArgs args = new ShowEventArgs();
			Assert.AreEqual(null, args.Timezone);
			Assert.AreEqual(0, args.X);
			Assert.AreEqual(0, args.Y);
			Assert.AreEqual(null, args.Type);
		}

		//! Testcase überprüft ob die Klasse Werteänderungen erlaubt.
		[TestMethod]
		public void ShowEventArgsAttributesAreSetable()
		{
			ShowEventArgs args = new ShowEventArgs();
			args.Type = "test";
			Assert.AreEqual("test", args.Type);
			args.X = 1;
			Assert.AreEqual(1, args.X);
			args.Y = 1;
			Assert.AreEqual(1, args.Y);
			args.Timezone = TimeZoneInfo.Local;
			Assert.AreEqual(TimeZoneInfo.Local, args.Timezone);

		}
	}
}
