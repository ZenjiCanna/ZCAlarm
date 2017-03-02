namespace ZCAlarm
{
	partial class FrmDefineKTimer
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
			this.components = new System.ComponentModel.Container();
			this.buOK = new System.Windows.Forms.Button();
			this.txTitle = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txMemo = new System.Windows.Forms.TextBox();
			this.rdTaniHour = new System.Windows.Forms.RadioButton();
			this.pnlOptTani = new System.Windows.Forms.Panel();
			this.rdTaniSec = new System.Windows.Forms.RadioButton();
			this.rdTaniMin = new System.Windows.Forms.RadioButton();
			this.lbTime = new System.Windows.Forms.Label();
			this.buCancel = new System.Windows.Forms.Button();
			this.chkTemplate = new System.Windows.Forms.CheckBox();
			this.txTime = new ZCAlarm.TCountEditor(this.components);
			this.chkRepeat = new System.Windows.Forms.CheckBox();
			this.buSound = new System.Windows.Forms.Button();
			this.pnlOptTani.SuspendLayout();
			this.SuspendLayout();
			// 
			// buOK
			// 
			this.buOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buOK.Location = new System.Drawing.Point(270, 269);
			this.buOK.Name = "buOK";
			this.buOK.Size = new System.Drawing.Size(75, 24);
			this.buOK.TabIndex = 7;
			this.buOK.Text = "OK";
			this.buOK.UseVisualStyleBackColor = true;
			this.buOK.Click += new System.EventHandler(this.buOK_Click);
			// 
			// txTitle
			// 
			this.txTitle.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txTitle.Location = new System.Drawing.Point(53, 42);
			this.txTitle.MaxLength = 48;
			this.txTitle.Name = "txTitle";
			this.txTitle.Size = new System.Drawing.Size(374, 19);
			this.txTitle.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "タイトル";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 9;
			this.label2.Text = "時間";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 12);
			this.label3.TabIndex = 11;
			this.label3.Text = "メモ";
			// 
			// txMemo
			// 
			this.txMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txMemo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txMemo.Location = new System.Drawing.Point(53, 72);
			this.txMemo.Multiline = true;
			this.txMemo.Name = "txMemo";
			this.txMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txMemo.Size = new System.Drawing.Size(381, 132);
			this.txMemo.TabIndex = 3;
			// 
			// rdTaniHour
			// 
			this.rdTaniHour.AutoSize = true;
			this.rdTaniHour.Location = new System.Drawing.Point(3, 3);
			this.rdTaniHour.Name = "rdTaniHour";
			this.rdTaniHour.Size = new System.Drawing.Size(35, 16);
			this.rdTaniHour.TabIndex = 0;
			this.rdTaniHour.Text = "時";
			this.rdTaniHour.UseVisualStyleBackColor = true;
			this.rdTaniHour.CheckedChanged += new System.EventHandler(this.rdTaniHour_CheckedChanged);
			// 
			// pnlOptTani
			// 
			this.pnlOptTani.Controls.Add(this.rdTaniSec);
			this.pnlOptTani.Controls.Add(this.rdTaniMin);
			this.pnlOptTani.Controls.Add(this.rdTaniHour);
			this.pnlOptTani.Location = new System.Drawing.Point(103, 10);
			this.pnlOptTani.Name = "pnlOptTani";
			this.pnlOptTani.Size = new System.Drawing.Size(126, 23);
			this.pnlOptTani.TabIndex = 1;
			this.pnlOptTani.TabStop = true;
			// 
			// rdTaniSec
			// 
			this.rdTaniSec.AutoSize = true;
			this.rdTaniSec.Location = new System.Drawing.Point(83, 3);
			this.rdTaniSec.Name = "rdTaniSec";
			this.rdTaniSec.Size = new System.Drawing.Size(35, 16);
			this.rdTaniSec.TabIndex = 2;
			this.rdTaniSec.Text = "秒";
			this.rdTaniSec.UseVisualStyleBackColor = true;
			this.rdTaniSec.CheckedChanged += new System.EventHandler(this.rdTaniSec_CheckedChanged);
			// 
			// rdTaniMin
			// 
			this.rdTaniMin.AutoSize = true;
			this.rdTaniMin.Location = new System.Drawing.Point(43, 3);
			this.rdTaniMin.Name = "rdTaniMin";
			this.rdTaniMin.Size = new System.Drawing.Size(35, 16);
			this.rdTaniMin.TabIndex = 1;
			this.rdTaniMin.Text = "分";
			this.rdTaniMin.UseVisualStyleBackColor = true;
			this.rdTaniMin.CheckedChanged += new System.EventHandler(this.rdTaniMin_CheckedChanged);
			// 
			// lbTime
			// 
			this.lbTime.Location = new System.Drawing.Point(256, 15);
			this.lbTime.Name = "lbTime";
			this.lbTime.Size = new System.Drawing.Size(135, 16);
			this.lbTime.TabIndex = 12;
			this.lbTime.Text = "00000:00:00";
			// 
			// buCancel
			// 
			this.buCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buCancel.Location = new System.Drawing.Point(351, 269);
			this.buCancel.Name = "buCancel";
			this.buCancel.Size = new System.Drawing.Size(75, 24);
			this.buCancel.TabIndex = 8;
			this.buCancel.Text = "ｷｬﾝｾﾙ";
			this.buCancel.UseVisualStyleBackColor = true;
			// 
			// chkTemplate
			// 
			this.chkTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkTemplate.AutoSize = true;
			this.chkTemplate.Location = new System.Drawing.Point(53, 229);
			this.chkTemplate.Name = "chkTemplate";
			this.chkTemplate.Size = new System.Drawing.Size(102, 16);
			this.chkTemplate.TabIndex = 5;
			this.chkTemplate.Text = "テンプレート登録";
			this.chkTemplate.UseVisualStyleBackColor = true;
			// 
			// txTime
			// 
			this.txTime.CountTani = 0;
			this.txTime.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txTime.Location = new System.Drawing.Point(53, 11);
			this.txTime.MaxLength = 8;
			this.txTime.Name = "txTime";
			this.txTime.Size = new System.Drawing.Size(44, 19);
			this.txTime.TabIndex = 0;
			this.txTime.TextChanged += new System.EventHandler(this.txTime_TextChanged);
			// 
			// chkRepeat
			// 
			this.chkRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkRepeat.AutoSize = true;
			this.chkRepeat.Location = new System.Drawing.Point(53, 210);
			this.chkRepeat.Name = "chkRepeat";
			this.chkRepeat.Size = new System.Drawing.Size(65, 16);
			this.chkRepeat.TabIndex = 4;
			this.chkRepeat.Text = "繰り返し";
			this.chkRepeat.UseVisualStyleBackColor = true;
			// 
			// buSound
			// 
			this.buSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buSound.Location = new System.Drawing.Point(372, 210);
			this.buSound.Name = "buSound";
			this.buSound.Size = new System.Drawing.Size(62, 24);
			this.buSound.TabIndex = 6;
			this.buSound.Text = "サウンド...";
			this.buSound.UseVisualStyleBackColor = true;
			this.buSound.Click += new System.EventHandler(this.buSound_Click);
			// 
			// FrmDefineKTimer
			// 
			this.AcceptButton = this.buOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buCancel;
			this.ClientSize = new System.Drawing.Size(443, 295);
			this.Controls.Add(this.chkRepeat);
			this.Controls.Add(this.chkTemplate);
			this.Controls.Add(this.lbTime);
			this.Controls.Add(this.pnlOptTani);
			this.Controls.Add(this.txTime);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txMemo);
			this.Controls.Add(this.txTitle);
			this.Controls.Add(this.buSound);
			this.Controls.Add(this.buCancel);
			this.Controls.Add(this.buOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmDefineKTimer";
			this.Text = "カウントダウンタイマー起動";
			this.Load += new System.EventHandler(this.FrmDefineKTimer_Load);
			this.pnlOptTani.ResumeLayout(false);
			this.pnlOptTani.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buOK;
		private System.Windows.Forms.TextBox txTitle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txMemo;
		private TCountEditor txTime;
		private System.Windows.Forms.RadioButton rdTaniHour;
		private System.Windows.Forms.Panel pnlOptTani;
		private System.Windows.Forms.RadioButton rdTaniSec;
		private System.Windows.Forms.RadioButton rdTaniMin;
		private System.Windows.Forms.Label lbTime;
		private System.Windows.Forms.Button buCancel;
		private System.Windows.Forms.CheckBox chkTemplate;
		private System.Windows.Forms.CheckBox chkRepeat;
		private System.Windows.Forms.Button buSound;
	}
}