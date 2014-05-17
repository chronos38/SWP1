using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWP1;

namespace Tests
{
	//! Diese Testklasse implementiert Unittests für die Klasse ClockEventArgs.
	[TestClass]
	public class ClockEventArgsTest
	{
		/*! Diese Testmethode implementiert Testverhalten für den Konstruktor.
		 * 
		 * Zuerst wird der Standardkonstruktor getestet, die Werte innerhalb der Klasse sollten
		 * dann jeweils 0 sein. Danach werden spezifische Werte eingegeben, in diesem Fall
		 * ClockEventArgs(1, 2, 3). Der Wert für die Stunde muss also gleich 1 sein, der Wert
		 * für die Minuten gleich 2 und der Wert für die Sekunden gleich 3.
		 */
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

		/*! Diese Testmethode implementiert Testverhalten für die Eigenschaftssetzung der Klasse.
		 * 
		 * Die Klasse wurde durch einen Standardkonstruktor erzeugt, die Werte werden jedoch nicht beachtet.
		 * Jetzt werden die Werte über die Eigenschaftsfelder gesetzt, in diesem Fall args.Hour, args.Minute und
		 * args.Seconds. Die Werte werden alle auf int.MaxValue gesetzt und müssen daraufhin mit diesen bei
		 * der Überprüfung übereinstimmen.
		 */
		[TestMethod]
		public void ClockEventArgsAttributesAreMaxSetable()
		{
			ClockEventArgs args = new ClockEventArgs();
			args.Hour = int.MaxValue;
			Assert.AreEqual(int.MaxValue, args.Hour);
			args.Minute = int.MaxValue;
			Assert.AreEqual(int.MaxValue, args.Minute);
			args.Second = int.MaxValue;
			Assert.AreEqual(int.MaxValue, args.Second);
		}

		/*! Diese Testmethode implementiert Testverhalten für die Eigenschaftssetzung der Klasse.
		 * 
		 * Die Klasse wurde durch einen Standardkonstruktor erzeugt, die Werte werden jedoch nicht beachtet.
		 * Jetzt werden die Werte über die Eigenschaftsfelder gesetzt, in diesem Fall args.Hour, args.Minute und
		 * args.Seconds. Die Werte werden alle auf int.MinValue gesetzt und müssen daraufhin mit diesen bei
		 * der Überprüfung übereinstimmen.
		 */
		[TestMethod]
		public void ClockEventArgsAttributesAreMinSetable()
		{
			ClockEventArgs args = new ClockEventArgs();
			args.Hour = int.MinValue;
			Assert.AreEqual(int.MinValue, args.Hour);
			args.Minute = int.MinValue;
			Assert.AreEqual(int.MinValue, args.Minute);
			args.Second = int.MinValue;
			Assert.AreEqual(int.MinValue, args.Second);
		}
	}
}
