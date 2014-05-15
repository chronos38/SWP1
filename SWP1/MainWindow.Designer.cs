namespace SWP1
{
	partial class MainWindow
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
			if (disposing && (components != null))
			{
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
			this.grpSet = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.numSetSeconds = new System.Windows.Forms.NumericUpDown();
			this.numSetMinutes = new System.Windows.Forms.NumericUpDown();
			this.numSetHours = new System.Windows.Forms.NumericUpDown();
			this.btnSet = new System.Windows.Forms.Button();
			this.grpIncDec = new System.Windows.Forms.GroupBox();
			this.chkSeconds = new System.Windows.Forms.CheckBox();
			this.chkMinutes = new System.Windows.Forms.CheckBox();
			this.chkHours = new System.Windows.Forms.CheckBox();
			this.btnDec = new System.Windows.Forms.Button();
			this.btnInc = new System.Windows.Forms.Button();
			this.grpUndoRedo = new System.Windows.Forms.GroupBox();
			this.btnShowAll = new System.Windows.Forms.Button();
			this.btnRedo = new System.Windows.Forms.Button();
			this.btnUndo = new System.Windows.Forms.Button();
			this.grpShow = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.numPosY = new System.Windows.Forms.NumericUpDown();
			this.numPosX = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbTimezone = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.btnShow = new System.Windows.Forms.Button();
			this.btnHelp = new System.Windows.Forms.Button();
			this.grpSet.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numSetSeconds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSetMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSetHours)).BeginInit();
			this.grpIncDec.SuspendLayout();
			this.grpUndoRedo.SuspendLayout();
			this.grpShow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
			this.SuspendLayout();
			// 
			// grpSet
			// 
			this.grpSet.Controls.Add(this.label3);
			this.grpSet.Controls.Add(this.label2);
			this.grpSet.Controls.Add(this.label1);
			this.grpSet.Controls.Add(this.numSetSeconds);
			this.grpSet.Controls.Add(this.numSetMinutes);
			this.grpSet.Controls.Add(this.numSetHours);
			this.grpSet.Controls.Add(this.btnSet);
			this.grpSet.Location = new System.Drawing.Point(13, 13);
			this.grpSet.Name = "grpSet";
			this.grpSet.Size = new System.Drawing.Size(224, 111);
			this.grpSet.TabIndex = 0;
			this.grpSet.TabStop = false;
			this.grpSet.Text = "Set Values";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(150, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Seconds";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Minutes";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(150, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Hours";
			// 
			// numSetSeconds
			// 
			this.numSetSeconds.Location = new System.Drawing.Point(89, 76);
			this.numSetSeconds.Name = "numSetSeconds";
			this.numSetSeconds.Size = new System.Drawing.Size(55, 20);
			this.numSetSeconds.TabIndex = 3;
			// 
			// numSetMinutes
			// 
			this.numSetMinutes.Location = new System.Drawing.Point(89, 49);
			this.numSetMinutes.Name = "numSetMinutes";
			this.numSetMinutes.Size = new System.Drawing.Size(55, 20);
			this.numSetMinutes.TabIndex = 2;
			// 
			// numSetHours
			// 
			this.numSetHours.Location = new System.Drawing.Point(89, 22);
			this.numSetHours.Name = "numSetHours";
			this.numSetHours.Size = new System.Drawing.Size(55, 20);
			this.numSetHours.TabIndex = 1;
			// 
			// btnSet
			// 
			this.btnSet.Location = new System.Drawing.Point(7, 20);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(75, 23);
			this.btnSet.TabIndex = 0;
			this.btnSet.Text = "Set";
			this.btnSet.UseVisualStyleBackColor = true;
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			// 
			// grpIncDec
			// 
			this.grpIncDec.Controls.Add(this.chkSeconds);
			this.grpIncDec.Controls.Add(this.chkMinutes);
			this.grpIncDec.Controls.Add(this.chkHours);
			this.grpIncDec.Controls.Add(this.btnDec);
			this.grpIncDec.Controls.Add(this.btnInc);
			this.grpIncDec.Location = new System.Drawing.Point(13, 131);
			this.grpIncDec.Name = "grpIncDec";
			this.grpIncDec.Size = new System.Drawing.Size(224, 100);
			this.grpIncDec.TabIndex = 1;
			this.grpIncDec.TabStop = false;
			this.grpIncDec.Text = "Inc / Dec";
			// 
			// chkSeconds
			// 
			this.chkSeconds.AutoSize = true;
			this.chkSeconds.Location = new System.Drawing.Point(89, 68);
			this.chkSeconds.Name = "chkSeconds";
			this.chkSeconds.Size = new System.Drawing.Size(68, 17);
			this.chkSeconds.TabIndex = 4;
			this.chkSeconds.Text = "Seconds";
			this.chkSeconds.UseVisualStyleBackColor = true;
			// 
			// chkMinutes
			// 
			this.chkMinutes.AutoSize = true;
			this.chkMinutes.Location = new System.Drawing.Point(89, 44);
			this.chkMinutes.Name = "chkMinutes";
			this.chkMinutes.Size = new System.Drawing.Size(63, 17);
			this.chkMinutes.TabIndex = 3;
			this.chkMinutes.Text = "Minutes";
			this.chkMinutes.UseVisualStyleBackColor = true;
			// 
			// chkHours
			// 
			this.chkHours.AutoSize = true;
			this.chkHours.Location = new System.Drawing.Point(89, 20);
			this.chkHours.Name = "chkHours";
			this.chkHours.Size = new System.Drawing.Size(54, 17);
			this.chkHours.TabIndex = 2;
			this.chkHours.Text = "Hours";
			this.chkHours.UseVisualStyleBackColor = true;
			// 
			// btnDec
			// 
			this.btnDec.Location = new System.Drawing.Point(7, 50);
			this.btnDec.Name = "btnDec";
			this.btnDec.Size = new System.Drawing.Size(75, 23);
			this.btnDec.TabIndex = 1;
			this.btnDec.Text = "Decrement";
			this.btnDec.UseVisualStyleBackColor = true;
			this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
			// 
			// btnInc
			// 
			this.btnInc.Location = new System.Drawing.Point(7, 20);
			this.btnInc.Name = "btnInc";
			this.btnInc.Size = new System.Drawing.Size(75, 23);
			this.btnInc.TabIndex = 0;
			this.btnInc.Text = "Increment";
			this.btnInc.UseVisualStyleBackColor = true;
			this.btnInc.Click += new System.EventHandler(this.btnInc_Click);
			// 
			// grpUndoRedo
			// 
			this.grpUndoRedo.Controls.Add(this.btnHelp);
			this.grpUndoRedo.Controls.Add(this.btnShowAll);
			this.grpUndoRedo.Controls.Add(this.btnRedo);
			this.grpUndoRedo.Controls.Add(this.btnUndo);
			this.grpUndoRedo.Location = new System.Drawing.Point(244, 169);
			this.grpUndoRedo.Name = "grpUndoRedo";
			this.grpUndoRedo.Size = new System.Drawing.Size(346, 62);
			this.grpUndoRedo.TabIndex = 2;
			this.grpUndoRedo.TabStop = false;
			this.grpUndoRedo.Text = "Various";
			// 
			// btnShowAll
			// 
			this.btnShowAll.Location = new System.Drawing.Point(171, 19);
			this.btnShowAll.Name = "btnShowAll";
			this.btnShowAll.Size = new System.Drawing.Size(75, 23);
			this.btnShowAll.TabIndex = 2;
			this.btnShowAll.Text = "Show All";
			this.btnShowAll.UseVisualStyleBackColor = true;
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			// 
			// btnShowAll
			// 
			this.btnShowAll.Location = new System.Drawing.Point(171, 19);
			this.btnShowAll.Name = "btnShowAll";
			this.btnShowAll.Size = new System.Drawing.Size(75, 23);
			this.btnShowAll.TabIndex = 2;
			this.btnShowAll.Text = "Show All";
			this.btnShowAll.UseVisualStyleBackColor = true;
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			// 
			// btnRedo
			// 
			this.btnRedo.Location = new System.Drawing.Point(89, 20);
			this.btnRedo.Name = "btnRedo";
			this.btnRedo.Size = new System.Drawing.Size(75, 23);
			this.btnRedo.TabIndex = 1;
			this.btnRedo.Text = "Redo";
			this.btnRedo.UseVisualStyleBackColor = true;
			this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
			// 
			// btnUndo
			// 
			this.btnUndo.Location = new System.Drawing.Point(7, 20);
			this.btnUndo.Name = "btnUndo";
			this.btnUndo.Size = new System.Drawing.Size(75, 23);
			this.btnUndo.TabIndex = 0;
			this.btnUndo.Text = "Undo";
			this.btnUndo.UseVisualStyleBackColor = true;
			this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
			// 
			// grpShow
			// 
			this.grpShow.Controls.Add(this.label7);
			this.grpShow.Controls.Add(this.label6);
			this.grpShow.Controls.Add(this.numPosY);
			this.grpShow.Controls.Add(this.numPosX);
			this.grpShow.Controls.Add(this.label5);
			this.grpShow.Controls.Add(this.cmbTimezone);
			this.grpShow.Controls.Add(this.label4);
			this.grpShow.Controls.Add(this.cmbType);
			this.grpShow.Controls.Add(this.btnShow);
			this.grpShow.Location = new System.Drawing.Point(244, 13);
			this.grpShow.Name = "grpShow";
			this.grpShow.Size = new System.Drawing.Size(346, 150);
			this.grpShow.TabIndex = 3;
			this.grpShow.TabStop = false;
			this.grpShow.Text = "Show";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(276, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Y Position";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(276, 78);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "X Position";
			// 
			// numPosY
			// 
			this.numPosY.Location = new System.Drawing.Point(149, 102);
			this.numPosY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.numPosY.Name = "numPosY";
			this.numPosY.Size = new System.Drawing.Size(121, 20);
			this.numPosY.TabIndex = 6;
			this.numPosY.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			// 
			// numPosX
			// 
			this.numPosX.Location = new System.Drawing.Point(149, 76);
			this.numPosX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.numPosX.Name = "numPosX";
			this.numPosX.Size = new System.Drawing.Size(121, 20);
			this.numPosX.TabIndex = 5;
			this.numPosX.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(276, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Timezone";
			// 
			// cmbTimezone
			// 
			this.cmbTimezone.FormattingEnabled = true;
			this.cmbTimezone.Location = new System.Drawing.Point(7, 49);
			this.cmbTimezone.Name = "cmbTimezone";
			this.cmbTimezone.Size = new System.Drawing.Size(263, 21);
			this.cmbTimezone.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(276, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Type";
			// 
			// cmbType
			// 
			this.cmbType.DisplayMember = "(none)";
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange(new object[] {
            "Digital",
            "Analog"});
			this.cmbType.Location = new System.Drawing.Point(88, 22);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(182, 21);
			this.cmbType.TabIndex = 1;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(6, 20);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(75, 23);
			this.btnShow.TabIndex = 0;
			this.btnShow.Text = "Show";
			this.btnShow.UseVisualStyleBackColor = true;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(252, 19);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(602, 260);
			this.Controls.Add(this.grpShow);
			this.Controls.Add(this.grpUndoRedo);
			this.Controls.Add(this.grpIncDec);
			this.Controls.Add(this.grpSet);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "SWP1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.grpSet.ResumeLayout(false);
			this.grpSet.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numSetSeconds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSetMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSetHours)).EndInit();
			this.grpIncDec.ResumeLayout(false);
			this.grpIncDec.PerformLayout();
			this.grpUndoRedo.ResumeLayout(false);
			this.grpShow.ResumeLayout(false);
			this.grpShow.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpSet;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numSetSeconds;
		private System.Windows.Forms.NumericUpDown numSetMinutes;
		private System.Windows.Forms.NumericUpDown numSetHours;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.GroupBox grpIncDec;
		private System.Windows.Forms.Button btnDec;
		private System.Windows.Forms.Button btnInc;
		private System.Windows.Forms.CheckBox chkSeconds;
		private System.Windows.Forms.CheckBox chkMinutes;
		private System.Windows.Forms.CheckBox chkHours;
		private System.Windows.Forms.GroupBox grpUndoRedo;
		private System.Windows.Forms.Button btnRedo;
		private System.Windows.Forms.Button btnUndo;
		private System.Windows.Forms.GroupBox grpShow;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbTimezone;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numPosX;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numPosY;
		private System.Windows.Forms.Button btnShowAll;
		private System.Windows.Forms.Button btnHelp;

	}
}

