using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWP1;

namespace Tests
{
	[TestClass]
	public class MainControlTest
	{
		MainWindow _window = new MainWindow();

		[TestInitialize]
		[TestMethod]
		public void MainControlTestSetup()
		{
			MainControl control = new MainControl(_window);
			Assert.AreSame(control.Window, _window);

			_window.Control = control;
			Assert.AreSame(control, _window.Control);
		}

		[TestMethod]
		public void FormLoadSetExpectedValues()
		{
			var control = _window.Control;
			control.FormLoad(new Object(), new EventArgs());

			Assert.AreEqual(23, _window.SetHours.Maximum);
			Assert.AreEqual(59, _window.SetMinutes.Maximum);
			Assert.AreEqual(59, _window.SetSeconds.Maximum);

			Assert.AreEqual(-1, _window.SetHours.Minimum);
			Assert.AreEqual(-1, _window.SetMinutes.Minimum);
			Assert.AreEqual(-1, _window.SetSeconds.Minimum);

			Assert.AreEqual(-1, _window.SetHours.Value);
			Assert.AreEqual(-1, _window.SetMinutes.Value);
			Assert.AreEqual(-1, _window.SetSeconds.Value);

			Assert.AreEqual(0, _window.Type.SelectedIndex);
		}

		[TestMethod]
		public void SetClickResetsValues()
		{
			var control = _window.Control;
			control.FormLoad(new Object(), new EventArgs());
			_window.SetHours.Value = 23;
			_window.SetMinutes.Value = 59;
			_window.SetSeconds.Value = 59;

			control.SetClick(new Object(), new EventArgs());

			Assert.AreEqual(-1, _window.SetHours.Value);
			Assert.AreEqual(-1, _window.SetMinutes.Value);
			Assert.AreEqual(-1, _window.SetSeconds.Value);
		}

	}
}
