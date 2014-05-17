using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWP1
{
	public partial class MainWindow : Form
	{
		public Button ButtonSet { get; private set; }
		public Button ButtonInc { get; private set; }
		public Button ButtonDec { get; private set; }
		public Button ButtonUndo { get; private set; }
		public Button ButtonRedo { get; private set; }
		public Button ButtonShow { get; private set; }
		public Button ButtonShowAll { get; private set; }
		public Button ButtonHelp { get; private set; }

		public NumericUpDown SetHours { get; private set; }
		public NumericUpDown SetMinutes { get; private set; }
		public NumericUpDown SetSeconds { get; private set; }

		public NumericUpDown PositionX { get; private set; }
		public NumericUpDown PositionY { get; private set; }

		public ComboBox TimeZones { get; private set; }
		public ComboBox Type { get; private set; }

		public CheckBox Hours { get; private set; }
		public CheckBox Minutes { get; private set; }
		public CheckBox Seconds { get; private set; }

		public MainControl Control { get; private set; }

		public MainWindow()
		{
			InitializeComponent();

			ButtonSet = this.btnSet;
			ButtonInc = this.btnInc;
			ButtonDec = this.btnDec;
			ButtonUndo = this.btnUndo;
			ButtonRedo = this.btnRedo;
			ButtonShow = this.btnShow;
			ButtonShowAll = this.btnShowAll;
			ButtonHelp = this.btnHelp;

			SetHours = this.numSetHours;
			SetMinutes = this.numSetMinutes;
			SetSeconds = this.numSetSeconds;

			PositionX = this.numPosX;
			PositionY = this.numPosY;

			TimeZones = this.cmbTimezone;
			Type = this.cmbType;

			Hours = this.chkHours;
			Minutes = this.chkMinutes;
			Seconds = this.chkSeconds;

			Control = new MainControl(this);
		}
	}
}
