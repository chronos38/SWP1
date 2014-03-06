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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// variables
			ReadOnlyCollection<TimeZoneInfo> timeZoneInfo = TimeZoneInfo.GetSystemTimeZones();

			// commands
			mCommands.Add(this.btnInc, new CommandIncrement());
			mCommands.Add(this.btnDec, new CommandDecrement());
			mCommands.Add(this.btnSet, new CommandSet());
			mCommands.Add(this.btnShow, new CommandShow());

			// set combo boxes
			this.cmbType.SelectedIndex = 0;

			foreach (var info in timeZoneInfo) {
				this.cmbTimezone.Items.Add(info);

				if (info.BaseUtcOffset.Hours == 0) {
					this.cmbTimezone.SelectedItem = info;
				}
			}

			// set position values
			this.numPosX.Maximum = SystemInformation.VirtualScreen.Width - 256;
			this.numPosY.Maximum = SystemInformation.VirtualScreen.Height - 256;
		}

		private void btnSet_Click(object sender, EventArgs e)
		{
			// variables
			SetEventArgs args = new SetEventArgs();

			// set argument
			args.Hour = (int)this.numSetHours.Value;
			args.Minute = (int)this.numSetMinutes.Value;
			args.Second = (int)this.numSetSeconds.Value;
			
			// reset values
			this.numSetHours.Value = this.numSetMinutes.Value = this.numSetSeconds.Value = 0;

			// call command
			mLastCommand = mCommands[sender];
			mLastCommand.Execute(args);
			mLastArgs = args;
		}

		private void btnInc_Click(object sender, EventArgs e)
		{
			// variables
			IncDecEventArgs args = new IncDecEventArgs();

			// set arguments
			args.Hour = this.chkHours.Checked;
			args.Minute = this.chkMinutes.Checked;
			args.Second = this.chkSeconds.Checked;

			// reset values
			this.chkHours.Checked = this.chkMinutes.Checked = this.chkSeconds.Checked = false;

			// call command
			mLastCommand = mCommands[sender];
			mLastCommand.Execute(args);
			mLastArgs = args;
		}

		private void btnDec_Click(object sender, EventArgs e)
		{
			// variables
			IncDecEventArgs args = new IncDecEventArgs();

			// set arguments
			args.Hour = this.chkHours.Checked;
			args.Minute = this.chkMinutes.Checked;
			args.Second = this.chkSeconds.Checked;

			// reset values
			this.chkHours.Checked = this.chkMinutes.Checked = this.chkSeconds.Checked = false;

			// call command
			mLastCommand = mCommands[sender];
			mLastCommand.Execute(args);
			mLastArgs = args;
		}

		private void btnUndo_Click(object sender, EventArgs e)
		{
			mLastCommand.Undo();
		}

		private void btnRedo_Click(object sender, EventArgs e)
		{
			mLastCommand.Execute(mLastArgs);
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			// variables
			ShowEventArgs args = new ShowEventArgs();

			// set arguments
			args.Type = (string)this.cmbType.SelectedItem;
			args.Timezone = (TimeZoneInfo)this.cmbTimezone.SelectedItem;
			args.X = (int)this.numPosX.Value;
			args.Y = (int)this.numPosY.Value;

			// call command
			mLastCommand = mCommands[sender];
			mLastCommand.Execute(args);
			mLastArgs = args;
		}

		private Dictionary<object, ICommand> mCommands = new Dictionary<object, ICommand>();
		private ICommand mLastCommand = null;
		private EventArgs mLastArgs = null;
	}
}
