namespace SWP1
{
	partial class AnalogForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlClock = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// pnlClock
			// 
			this.pnlClock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlClock.Location = new System.Drawing.Point(0, 0);
			this.pnlClock.Name = "pnlClock";
			this.pnlClock.Size = new System.Drawing.Size(256, 256);
			this.pnlClock.TabIndex = 0;
			// 
			// AnalogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(256, 256);
			this.Controls.Add(this.pnlClock);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AnalogForm";
			this.Text = "AnalogForm";
			this.Load += new System.EventHandler(this.AnalogForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogForm_Paint);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlClock;
	}
}