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
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// variables
			ReadOnlyCollection<TimeZoneInfo> timeZoneInfo = TimeZoneInfo.GetSystemTimeZones();

			// commands
			mCommands.Add("incdec", new CommandIncDec());
			mCommands.Add("set", new CommandSet());
			mCommands.Add("show", new CommandShow());

			// num upper bound
			this.numSetHours.Maximum = 23;
			this.numSetMinutes.Maximum = this.numSetSeconds.Maximum = 59;
			// num lower bound
			this.numSetHours.Minimum = this.numSetMinutes.Minimum = this.numSetSeconds.Minimum = -1;
			// num default value
			this.numSetHours.Value = this.numSetMinutes.Value = this.numSetSeconds.Value = -1;

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
			Clock clock = Clock.Instance;
			ClockEventArgs args = new ClockEventArgs();

			// set argument
			args.Hour = (int)this.numSetHours.Value;
			args.Minute = (int)this.numSetMinutes.Value;
			args.Second = (int)this.numSetSeconds.Value;
			
			// reset values
			this.numSetHours.Value = this.numSetMinutes.Value = this.numSetSeconds.Value = -1;

			// call command
			mCommands["set"].Execute(args);

			// set undo/redo
			mUndoBuffer.Add(new Tuple<ICommand, EventArgs>(mCommands["set"], args));
			mRedo = null;
		}

		private void btnInc_Click(object sender, EventArgs e)
		{
			// variables
			ClockEventArgs args = new ClockEventArgs();

			// set arguments
			args.Hour = this.chkHours.Checked ? 1 : 0;
			args.Minute = this.chkMinutes.Checked ? 1 : 0;
			args.Second = this.chkSeconds.Checked ? 1 : 0;

			// call command
			mCommands["incdec"].Execute(args);

			// set undo/redo
			mUndoBuffer.Add(new Tuple<ICommand, EventArgs>(mCommands["incdec"], args));
			mRedo = null;
		}

		private void btnDec_Click(object sender, EventArgs e)
		{
			// variables
			ClockEventArgs args = new ClockEventArgs();

			// set arguments
			args.Hour = this.chkHours.Checked ? -1 : 0;
			args.Minute = this.chkMinutes.Checked ? -1 : 0;
			args.Second = this.chkSeconds.Checked ? -1 : 0;

			// call command
			mCommands["incdec"].Execute(args);

			// set undo/redo
			mUndoBuffer.Add(new Tuple<ICommand, EventArgs>(mCommands["incdec"], args));
			mRedo = null;
		}

		private void btnUndo_Click(object sender, EventArgs e)
		{
			if (mUndoBuffer.Count <= 0) {
				return;
			}

			// variables
			Tuple<ICommand, EventArgs> undo = mUndoBuffer.Last();
			mUndoBuffer.Remove(undo);

			// exucute
			undo.Item1.Execute(undo.Item2);

			// set redo
			mRedo = undo;
		}

		private void btnRedo_Click(object sender, EventArgs e)
		{
			if (mRedo == null) {
				return;
			}

			mRedo.Item1.Execute(mRedo.Item2);
			mUndoBuffer.Add(mRedo);
			mRedo = null;
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
			mCommands["show"].Execute(args);
		}

		private void btnShowAll_Click(object sender, EventArgs e)
		{
			// variables
			ICommand show = mCommands["show"];
			int current = 0;

			// show all
			foreach (TimeZoneInfo item in this.cmbTimezone.Items) {
				if (current == item.BaseUtcOffset.Hours) {
					continue;
				}

				ShowEventArgs args = new ShowEventArgs();

				args.Type = (string)this.cmbType.SelectedItem;
				args.Timezone = item;
				args.X = -1;
				args.Y = -1;
				current = item.BaseUtcOffset.Hours;
				
				show.Execute(args);
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This program is pretty much straight forward.", "Help");
		}

		private Dictionary<string, ICommand> mCommands = new Dictionary<string, ICommand>();
		private List<Tuple<ICommand, EventArgs>> mUndoBuffer = new List<Tuple<ICommand, EventArgs>>();
		private Tuple<ICommand, EventArgs> mRedo = new Tuple<ICommand, EventArgs>(null, null);
	}
}
