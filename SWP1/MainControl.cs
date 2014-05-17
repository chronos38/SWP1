using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWP1
{
	public class MainControl
	{
		public MainWindow Window { get; private set; }

		public MainControl(MainWindow window)
		{
			Window = window;

			window.Load += new EventHandler(FormLoad);
			window.ButtonSet.Click += new EventHandler(SetClick);
			window.ButtonInc.Click += new EventHandler(IncClick);
			window.ButtonDec.Click += new EventHandler(DecClick);
			window.ButtonUndo.Click += new EventHandler(UndoClick);
			window.ButtonRedo.Click += new EventHandler(RedoClick);
			window.ButtonShow.Click += new EventHandler(ShowClick);
			window.ButtonShowAll.Click += new EventHandler(ShowAllClick);
			window.ButtonHelp.Click += new EventHandler(HelpClick);
		}

		public void FormLoad(object sender, EventArgs e)
		{
			// variables
			ReadOnlyCollection<TimeZoneInfo> timeZoneInfo = TimeZoneInfo.GetSystemTimeZones();

			// commands
			mCommands.Add("incdec", new CommandIncDec());
			mCommands.Add("set", new CommandSet());
			mCommands.Add("show", new CommandShow());

			// num upper bound
			Window.SetHours.Maximum = 23;
			Window.SetMinutes.Maximum = Window.SetSeconds.Maximum = 59;
			// num lower bound
			Window.SetHours.Minimum = Window.SetMinutes.Minimum = Window.SetSeconds.Minimum = -1;
			// num default value
			Window.SetHours.Value = Window.SetMinutes.Value = Window.SetSeconds.Value = -1;

			// set combo boxes
			Window.Type.SelectedIndex = 0;

			foreach (var info in timeZoneInfo) {
				Window.TimeZones.Items.Add(info);

				if (info.BaseUtcOffset.Hours == 0) {
					Window.TimeZones.SelectedItem = info;
				}
			}

			// set position values
			Window.PositionX.Maximum = SystemInformation.VirtualScreen.Width - 256;
			Window.PositionY.Maximum = SystemInformation.VirtualScreen.Height - 256;
		}

		public void SetClick(object sender, EventArgs e)
		{
			// variables
			ClockEventArgs args = new ClockEventArgs();

			// set argument
			args.Hour = (int)Window.SetHours.Value;
			args.Minute = (int)Window.SetMinutes.Value;
			args.Second = (int)Window.SetSeconds.Value;
			
			// reset values
			Window.SetHours.Value = Window.SetMinutes.Value = Window.SetSeconds.Value = -1;

			// call command
			mCommands["set"].Execute(args);

			// set undo/redo
			mUndoBuffer.Add(new Tuple<ICommand, EventArgs>(mCommands["set"], args));
			mRedo = null;
		}

		public void IncClick(object sender, EventArgs e)
		{
			// variables
			ClockEventArgs args = new ClockEventArgs();

			// set arguments
			args.Hour = Window.Hours.Checked ? 1 : 0;
			args.Minute = Window.Minutes.Checked ? 1 : 0;
			args.Second = Window.Seconds.Checked ? 1 : 0;

			// call command
			mCommands["incdec"].Execute(args);

			// set undo/redo
			mUndoBuffer.Add(new Tuple<ICommand, EventArgs>(mCommands["incdec"], args));
			mRedo = null;
		}

		public void DecClick(object sender, EventArgs e)
		{
			// variables
			ClockEventArgs args = new ClockEventArgs();

			// set arguments
			args.Hour = Window.Hours.Checked ? -1 : 0;
			args.Minute = Window.Minutes.Checked ? -1 : 0;
			args.Second = Window.Seconds.Checked ? -1 : 0;

			// call command
			mCommands["incdec"].Execute(args);

			// set undo/redo
			mUndoBuffer.Add(new Tuple<ICommand, EventArgs>(mCommands["incdec"], args));
			mRedo = null;
		}

		public void UndoClick(object sender, EventArgs e)
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

		public void RedoClick(object sender, EventArgs e)
		{
			if (mRedo == null) {
				return;
			}

			mRedo.Item1.Execute(mRedo.Item2);
			mUndoBuffer.Add(mRedo);
			mRedo = null;
		}

		public void ShowClick(object sender, EventArgs e)
		{
			// variables
			ShowEventArgs args = new ShowEventArgs();

			// set arguments
			args.Type = (string)Window.Type.SelectedItem;
			args.Timezone = (TimeZoneInfo)Window.TimeZones.SelectedItem;
			args.X = (int)Window.PositionX.Value;
			args.Y = (int)Window.PositionY.Value;

			// call command
			mCommands["show"].Execute(args);
		}

		public void ShowAllClick(object sender, EventArgs e)
		{
			// variables
			ICommand show = mCommands["show"];
			int current = 0;

			// show all
			foreach (TimeZoneInfo item in Window.TimeZones.Items) {
				if (current == item.BaseUtcOffset.Hours) {
					continue;
				}

				ShowEventArgs args = new ShowEventArgs();

				args.Type = (string)Window.Type.SelectedItem;
				args.Timezone = item;
				args.X = -1; // position is system defined
				args.Y = -1; // position is system defined
				current = item.BaseUtcOffset.Hours;
				
				show.Execute(args);
			}
		}

		public void HelpClick(object sender, EventArgs e)
		{
			MessageBox.Show("Window program is pretty much straight forward.", "Help");
		}

		private IDictionary<string, ICommand> mCommands = new Dictionary<string, ICommand>();
		private IList<Tuple<ICommand, EventArgs>> mUndoBuffer = new List<Tuple<ICommand, EventArgs>>();
		private Tuple<ICommand, EventArgs> mRedo = new Tuple<ICommand, EventArgs>(null, null);
	}
}
