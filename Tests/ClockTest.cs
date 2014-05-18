using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using System.Fakes;
using SWP1;
using System.Threading;
using Tests.Mock;

namespace Tests
{
	//! Diese Testklasse implementiert Unittests für Clock
	[TestClass]
	public class ClockTest
	{
		//! Clock-Instanz fürs testen
		Clock _clock;
		//IDisposable _shimCon;

		//! Initialisiert die Testklasse
		[TestInitialize]
		public void ClockTestSetup()
		{
			_clock = Clock.Instance;
			/*_shimCon = ShimsContext.Create();
			//Shim to set Time always to 0:0:0
			ShimDateTime.UtcNowGet = () => {
					return new DateTime(2000, 1, 1, 0, 0, 0);
				};*/
		}

		//! Beendet die Testklasse
		[TestCleanup]
		public void ClockTestCleanup()
		{
			//_shimCon.Dispose();
		}

		//! Überprüft ob die Clock-Instanz ein Singleton ist.
		[TestMethod]
		public void ClockIsSingleton()
		{
			Assert.AreSame(Clock.Instance, _clock);
		}

		/*! Testcase überprüft allgemein die Set-Funktion der Clock-Instanz
		 * 
		 * Zuerst werden positive Zahlen im gültigen Wertebereich getestet, dann
		 * werden negative Zahlen im ungültigen Wertebereich getestet.
		 */
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

		/*! Testcase überprüft das untere Ende des Wertebereichs für die Stunden
		 * 
		 * Verwendet wurden die Zahlen int.MinValue, -1, 0, 1. Im gültigen Wertebereich
		 * befinden sich 0 und 1. Von daher wurde getestet ob die Zahlen gleichwertig
		 * sind. Bei int.MinValue und -1 wurde getestet ob die Zahlen nicht gleichtwertig
		 * sind.
		 */
		[TestMethod]
		public void SetHourIntervalBeginTest()
		{
			// min
			_clock.Set(int.MinValue, 0, 0);
			Assert.AreNotEqual(int.MinValue, _clock.Hour);

			// -1
			_clock.Set(-1, 0, 0);
			Assert.AreNotEqual(-1, _clock.Hour);

			// 0
			_clock.Set(0, 0, 0);
			Assert.AreEqual(0, _clock.Hour);

			// 1
			_clock.Set(1, 0, 0);
			Assert.AreEqual(1, _clock.Hour);
		}

		/*! Testcase überprüft die mitte des Wertebereichs für die Stunden
		 * 
		 * Verwendet wurden die Zahlen 11, 12, 13. Alle Werte sollten sich im
		 * gültigen Wertebereich befinden. Von daher sollen die Werte
		 * gleichwertig den gesetzten Werten sein.
		 */
		[TestMethod]
		public void SetHourIntervalMiddleTest()
		{
			// 11
			_clock.Set(11, 0, 0);
			Assert.AreEqual(11, _clock.Hour);

			// 12
			_clock.Set(12, 0, 0);
			Assert.AreEqual(12, _clock.Hour);

			// 13
			_clock.Set(13, 0, 0);
			Assert.AreEqual(13, _clock.Hour);
		}

		/*! Testcase überprüft das obere Ende des Wertebereichs für die Stunden
		 * 
		 * Verwendet wurden die Zahlen 23, 24, 25, int.MaxValue. Im gültigen Wertebereich
		 * befinden sich 23 und 24. Von daher wurde getestet ob die Zahlen gleichwertig
		 * sind. Bei int.MaxValue und 25 wurde getestet ob die Zahlen nicht gleichtwertig
		 * sind.
		 */
		[TestMethod]
		public void SetHourIntervalEndTest()
		{
			// 23
			_clock.Set(23, 0, 0);
			Assert.AreEqual(23, _clock.Hour);

			// 24
			_clock.Set(24, 0, 0);
			Assert.AreNotEqual(24, _clock.Hour);
			Assert.AreEqual(0, _clock.Hour);

			// 25
			_clock.Set(25, 0, 0);
			Assert.AreNotEqual(25, _clock.Hour);

			// Max
			_clock.Set(int.MaxValue, 0, 0);
			Assert.AreNotEqual(int.MaxValue, _clock.Hour);
		}

		/*! Testcase überprüft das untere Ende des Wertebereichs für die Minuten
		 * 
		 * Verwendet wurden die Zahlen int.MinValue, -1, 0, 1. Im gültigen Wertebereich
		 * befinden sich 0 und 1. Von daher wurde getestet ob die Zahlen gleichwertig
		 * sind. Bei int.MinValue und -1 wurde getestet ob die Zahlen nicht gleichtwertig
		 * sind.
		 */
		[TestMethod]
		public void SetMinuteIntervalBeginTest()
		{
			// min
			_clock.Set(0, int.MinValue, 0);
			Assert.AreNotEqual(int.MinValue, _clock.Minute);

			// -1
			_clock.Set(0, -1, 0);
			Assert.AreNotEqual(-1, _clock.Minute);

			// 0
			_clock.Set(0, 0, 0);
			Assert.AreEqual(0, _clock.Minute);

			// 1
			_clock.Set(0, 1, 0);
			Assert.AreEqual(1, _clock.Minute);
		}

		/*! Testcase überprüft die mitte des Wertebereichs für die Minuten
		 * 
		 * Verwendet wurden die Zahlen 29, 30, 31. Alle Werte sollten sich im
		 * gültigen Wertebereich befinden. Von daher sollen die Werte
		 * gleichwertig den gesetzten Werten sein.
		 */
		[TestMethod]
		public void SetMinuteIntervalMiddleTest()
		{
			// 29
			_clock.Set(0, 29, 0);
			Assert.AreEqual(29, _clock.Minute);

			// 30
			_clock.Set(0, 30, 0);
			Assert.AreEqual(30, _clock.Minute);

			// 31
			_clock.Set(0, 31, 0);
			Assert.AreEqual(31, _clock.Minute);
		}

		/*! Testcase überprüft das obere Ende des Wertebereichs für die Minuten
		 * 
		 * Verwendet wurden die Zahlen 59, 60, 61, int.MaxValue. Im gültigen Wertebereich
		 * befinden sich 59 und 60. Von daher wurde getestet ob die Zahlen gleichwertig
		 * sind. Bei int.MaxValue und 61 wurde getestet ob die Zahlen nicht gleichtwertig
		 * sind.
		 */
		[TestMethod]
		public void SetMinuteIntervalEndTest()
		{
			// 59
			_clock.Set(0, 59, 0);
			Assert.AreEqual(59, _clock.Minute);

			// 60
			_clock.Set(0, 60, 0);
			Assert.AreNotEqual(60, _clock.Minute);
			Assert.AreEqual(0, _clock.Minute);

			// 61
			_clock.Set(0, 61, 0);
			Assert.AreNotEqual(61, _clock.Minute);

			// Max
			_clock.Set(0, int.MaxValue, 0);
			Assert.AreNotEqual(int.MaxValue, _clock.Minute);
		}

		/*! Testcase überprüft das untere Ende des Wertebereichs für die Sekunden
		 * 
		 * Verwendet wurden die Zahlen int.MinValue, -1, 0, 1. Im gültigen Wertebereich
		 * befinden sich 0 und 1. Von daher wurde getestet ob die Zahlen gleichwertig
		 * sind. Bei int.MinValue und -1 wurde getestet ob die Zahlen nicht gleichtwertig
		 * sind.
		 */
		[TestMethod]
		public void SetSecondIntervalBeginTest()
		{
			// min
			_clock.Set(0, 0, int.MinValue);
			Assert.AreNotEqual(int.MinValue, _clock.Second);

			// -1
			_clock.Set(0, 0, -1);
			Assert.AreNotEqual(-1, _clock.Second);

			// 0
			_clock.Set(0, 0, 0);
			Assert.AreEqual(0, _clock.Second);

			// 1
			_clock.Set(0, 0, 1);
			Assert.AreEqual(1, _clock.Second);
		}

		/*! Testcase überprüft die mitte des Wertebereichs für die Sekunden
		 * 
		 * Verwendet wurden die Zahlen 29, 30, 31. Alle Werte sollten sich im
		 * gültigen Wertebereich befinden. Von daher sollen die Werte
		 * gleichwertig den gesetzten Werten sein.
		 */
		[TestMethod]
		public void SetSecondIntervalMiddleTest()
		{
			// 29
			_clock.Set(0, 0, 29);
			Assert.AreEqual(29, _clock.Second);

			// 30
			_clock.Set(0, 0, 30);
			Assert.AreEqual(30, _clock.Second);

			// 31
			_clock.Set(0, 0, 31);
			Assert.AreEqual(31, _clock.Second);
		}

		/*! Testcase überprüft das obere Ende des Wertebereichs für die Sekunden
		 * 
		 * Verwendet wurden die Zahlen 59, 60, 61, int.MaxValue. Im gültigen Wertebereich
		 * befinden sich 59 und 60. Von daher wurde getestet ob die Zahlen gleichwertig
		 * sind. Bei int.MaxValue und 61 wurde getestet ob die Zahlen nicht gleichtwertig
		 * sind.
		 */
		[TestMethod]
		public void SetSecondIntervalEndTest()
		{
			// 59
			_clock.Set(0, 0, 59);
			Assert.AreEqual(59, _clock.Second);

			// 60
			_clock.Set(0, 0, 60);
			Assert.AreNotEqual(60, _clock.Second);
			Assert.AreEqual(0, _clock.Second);

			// 61
			_clock.Set(0, 0, 61);
			Assert.AreNotEqual(61, _clock.Second);

			// Max
			_clock.Set(0, 0, int.MaxValue);
			Assert.AreNotEqual(int.MaxValue, _clock.Second);
		}

		/*! Dieser Testcase überprüft ob die IncDec-Funktion
		 * 
		 * Überprüft wird ob die Funktion die Werte im gültigen Wertebereich
		 * inkrementiert. Hierfür werden zuerst die Werte auf 0 gesetzt. Danach
		 * werden die Sekunden 120 mal inkrementiert. Die gültigen Werte sollten
		 * also für die Stunden 0, die Minuten 2 und die Sekunden 0 sein.
		 * 
		 * Analoges wird für die Minuten und Stunden durchgeführt.
		 */
		[TestMethod]
		public void IncDecIsProperlyRollingOverWhenIncrementing()
		{
			//Test depends on Set. Merge this test with Set Test?
			_clock.Set(0, 0, 0);

			//seconds rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0, 0, 1);
			}
			Assert.AreEqual(0, _clock.Hour);
			Assert.AreEqual(2, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);

			//minutes rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0, 1, 0);
			}
			Assert.AreEqual(2, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);

			//hours rollover
			for (int i = 0; i < 24; i++) {
				_clock.IncDec(1, 0, 0);
			}
			Assert.AreEqual(0, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);
		}

		/*! Dieser Testcase überprüft ob die IncDec-Funktion
		 * 
		 * Überprüft wird ob die Funktion die Werte im gültigen Wertebereich
		 * dekrementiert. Hierfür werden zuerst die Werte auf 0 gesetzt. Danach
		 * werden die Sekunden 120 mal dekrementiert. Die gültigen Werte sollten
		 * also für die Stunden 23, die Minuten 58 und die Sekunden 0 sein.
		 * 
		 * Analoges wird für die Minuten und Stunden durchgeführt.
		 */
		[TestMethod]
		public void IncDecIsProperlyRollingOverWhenDecrementing()
		{
			//Test depends on Set. Merge this test with Set Test?
			_clock.Set(0, 0, 0);

			//seconds rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0, 0, -1);
			}
			Assert.AreEqual(23, _clock.Hour);
			Assert.AreEqual(58, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);

			//minutes rollover
			for (int i = 0; i < 120; i++) {
				_clock.IncDec(0, -1, 0);
			}
			Assert.AreEqual(22, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);

			_clock.Set(0, 0, 0);

			//hours rollover
			for (int i = 0; i < 24; i++) {
				_clock.IncDec(-1, 0, 0);
			}
			Assert.AreEqual(0, _clock.Hour);
			Assert.AreEqual(0, _clock.Minute);
			Assert.AreEqual(0, _clock.Second);
		}

		/*! Dieser Testcase testet die Wertebereiche der IncDec Funktion für die Stunden
		 * 
		 * Überprüft wurden die Werte int.MinValue, -1, 0, 1, int.MaxValue.
		 * Bei allen Werten unter 0 sollten dekrementiert werden, bei allen
		 * Werten über 0 sollte inkrementiert werden. Bei den Wert 0 sollte
		 * die Funktion keine Änderung machen.
		 */
		[TestMethod]
		public void IncDecHourIntervalTest()
		{
			_clock.Set(12, 0, 0);

			_clock.IncDec(int.MinValue, 0, 0);
			Assert.AreEqual(11, _clock.Hour);

			_clock.IncDec(-1, 0, 0);
			Assert.AreEqual(10, _clock.Hour);

			_clock.IncDec(0, 0, 0);
			Assert.AreEqual(10, _clock.Hour);

			_clock.IncDec(1, 0, 0);
			Assert.AreEqual(11, _clock.Hour);

			_clock.IncDec(int.MaxValue, 0, 0);
			Assert.AreEqual(12, _clock.Hour);
		}

		/*! Dieser Testcase testet die Wertebereiche der IncDec Funktion für die Minuten
		 * 
		 * Überprüft wurden die Werte int.MinValue, -1, 0, 1, int.MaxValue.
		 * Bei allen Werten unter 0 sollten dekrementiert werden, bei allen
		 * Werten über 0 sollte inkrementiert werden. Bei den Wert 0 sollte
		 * die Funktion keine Änderung machen.
		 */
		[TestMethod]
		public void IncDecMinuteIntervalTest()
		{
			_clock.Set(0, 30, 0);

			_clock.IncDec(0, int.MinValue, 0);
			Assert.AreEqual(29, _clock.Minute);

			_clock.IncDec(0, -1, 0);
			Assert.AreEqual(28, _clock.Minute);

			_clock.IncDec(0, 0, 0);
			Assert.AreEqual(28, _clock.Minute);

			_clock.IncDec(0, 1, 0);
			Assert.AreEqual(29, _clock.Minute);

			_clock.IncDec(0, int.MaxValue, 0);
			Assert.AreEqual(30, _clock.Minute);
		}

		/*! Dieser Testcase testet die Wertebereiche der IncDec Funktion für die Sekunden
		 * 
		 * Überprüft wurden die Werte int.MinValue, -1, 0, 1, int.MaxValue.
		 * Bei allen Werten unter 0 sollten dekrementiert werden, bei allen
		 * Werten über 0 sollte inkrementiert werden. Bei den Wert 0 sollte
		 * die Funktion keine Änderung machen.
		 */
		[TestMethod]
		public void IncDecSecondIntervalTest()
		{
			_clock.Set(0, 0, 30);

			_clock.IncDec(0, 0, int.MinValue);
			Assert.AreEqual(29, _clock.Second);

			_clock.IncDec(0, 0, -1);
			Assert.AreEqual(28, _clock.Second);

			_clock.IncDec(0, 0, 0);
			Assert.AreEqual(28, _clock.Second);

			_clock.IncDec(0, 0, 1);
			Assert.AreEqual(29, _clock.Second);

			_clock.IncDec(0, 0, int.MaxValue);
			Assert.AreEqual(30, _clock.Second);
		}

		//! Testcase überprüft Detach für einen Observer.
		[TestMethod]
		[ExpectedException(typeof(ApplicationException))]
		public void DetachThrowsExceptionWhenDetachingUnknownObserver()
		{
			MockOberserver observer = new Mock.MockOberserver();
			_clock.Detach(observer);
		}

		//! Testcase überprüft IncDec für einen Observer.
		[TestMethod]
		public void ObserverGetsUpdatedByIncDecAndSet()
		{
			MockOberserver observer = new Mock.MockOberserver();
			try {
				_clock.Attach(observer);
				_clock.IncDec(1, 0, 0);
				Assert.IsTrue(ObserverUpdated(observer));
				observer.UpdateOccured = false;
				_clock.Set(1, 2, 3);
				Assert.IsTrue(ObserverUpdated(observer));
			} finally {
				_clock.Detach(observer);
			}

		}

		//! Testcase überprüft ob Update korrekt für Observer funktioniert.
		[TestMethod]
		public void OberserverGetsUpdatedByTimer()
		{
			_clock.Start();
			MockOberserver observer = new Mock.MockOberserver();
			_clock.Attach(observer);

			try {

				Assert.IsTrue(ObserverUpdated(observer));

				observer.UpdateOccured = false;
				_clock.Stop();

				Assert.IsFalse(ObserverUpdated(observer));

			} finally {
				_clock.Detach(observer);
				_clock.Stop();
			}
		}

		//! Testcase überprüft ...
		private bool ObserverUpdated(MockOberserver observer)
		{
			bool ret = false;
			AutoResetEvent evt = new AutoResetEvent(false);
			Timer t = new Timer(state => {
				while (!observer.UpdateOccured) ;
				evt.Set();
			}, null, 1000, Timeout.Infinite);

			if (evt.WaitOne(2000)) {
				ret = true;
			}
			return ret;
		}
	}
}
