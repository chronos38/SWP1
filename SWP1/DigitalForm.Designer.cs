namespace SWP1
{
	partial class DigitalForm
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
			this.lblClock = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblClock
			// 
			this.lblClock.AutoSize = true;
			this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClock.Location = new System.Drawing.Point(12, 9);
			this.lblClock.Name = "lblClock";
			this.lblClock.Size = new System.Drawing.Size(210, 51);
			this.lblClock.TabIndex = 0;
			this.lblClock.Text = "hh:mm:ss";
			// 
			// DigitalForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(235, 73);
			this.Controls.Add(this.lblClock);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DigitalForm";
			this.Text = "DigitalForm";
			this.Load += new System.EventHandler(this.DigitalForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblClock;
	}
}