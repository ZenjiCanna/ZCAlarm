namespace ZCAlarm
{
	partial class FrmDefineAlarm
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
			this.buSound = new System.Windows.Forms.Button();
			this.buCancel = new System.Windows.Forms.Button();
			this.buOK = new System.Windows.Forms.Button();
			this.chkTemplate = new System.Windows.Forms.CheckBox();
			this.txTitle = new System.Windows.Forms.TextBox();
			this.pnlOptTani = new System.Windows.Forms.Panel();
			this.rdTaniSec = new System.Windows.Forms.RadioButton();
			this.rdTaniMin = new System.Windows.Forms.RadioButton();
			this.rdTaniHour = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txMemo = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.pnlOptTani.SuspendLayout();
			this.SuspendLayout();
			// 
			// buSound
			// 
			this.buSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buSound.Location = new System.Drawing.Point(529, 247);
			this.buSound.Name = "buSound";
			this.buSound.Size = new System.Drawing.Size(62, 24);
			this.buSound.TabIndex = 9;
			this.buSound.Text = "サウンド...";
			this.buSound.UseVisualStyleBackColor = true;
			// 
			// buCancel
			// 
			this.buCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buCancel.Location = new System.Drawing.Point(319, 247);
			this.buCancel.Name = "buCancel";
			this.buCancel.Size = new System.Drawing.Size(75, 24);
			this.buCancel.TabIndex = 10;
			this.buCancel.Text = "ｷｬﾝｾﾙ";
			this.buCancel.UseVisualStyleBackColor = true;
			// 
			// buOK
			// 
			this.buOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buOK.Location = new System.Drawing.Point(238, 247);
			this.buOK.Name = "buOK";
			this.buOK.Size = new System.Drawing.Size(75, 24);
			this.buOK.TabIndex = 8;
			this.buOK.Text = "OK";
			this.buOK.UseVisualStyleBackColor = true;
			// 
			// chkTemplate
			// 
			this.chkTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkTemplate.AutoSize = true;
			this.chkTemplate.Location = new System.Drawing.Point(129, 315);
			this.chkTemplate.Name = "chkTemplate";
			this.chkTemplate.Size = new System.Drawing.Size(102, 16);
			this.chkTemplate.TabIndex = 12;
			this.chkTemplate.Text = "テンプレート登録";
			this.chkTemplate.UseVisualStyleBackColor = true;
			// 
			// txTitle
			// 
			this.txTitle.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txTitle.Location = new System.Drawing.Point(129, 76);
			this.txTitle.MaxLength = 48;
			this.txTitle.Name = "txTitle";
			this.txTitle.Size = new System.Drawing.Size(374, 19);
			this.txTitle.TabIndex = 11;
			// 
			// pnlOptTani
			// 
			this.pnlOptTani.Controls.Add(this.rdTaniSec);
			this.pnlOptTani.Controls.Add(this.rdTaniMin);
			this.pnlOptTani.Controls.Add(this.rdTaniHour);
			this.pnlOptTani.Location = new System.Drawing.Point(169, 360);
			this.pnlOptTani.Name = "pnlOptTani";
			this.pnlOptTani.Size = new System.Drawing.Size(126, 23);
			this.pnlOptTani.TabIndex = 13;
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
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(57, 111);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 12);
			this.label3.TabIndex = 16;
			this.label3.Text = "メモ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(57, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 12);
			this.label1.TabIndex = 15;
			this.label1.Text = "タイトル";
			// 
			// txMemo
			// 
			this.txMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txMemo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txMemo.Location = new System.Drawing.Point(129, 105);
			this.txMemo.Multiline = true;
			this.txMemo.Name = "txMemo";
			this.txMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txMemo.Size = new System.Drawing.Size(381, 132);
			this.txMemo.TabIndex = 14;
			// 
			// textBox1
			// 
			this.textBox1.ImeMode = System.Windows.Forms.ImeMode.On;
			this.textBox1.Location = new System.Drawing.Point(149, 26);
			this.textBox1.MaxLength = 48;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(21, 19);
			this.textBox1.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(130, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 12);
			this.label2.TabIndex = 16;
			this.label2.Text = "20";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(172, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(11, 12);
			this.label4.TabIndex = 15;
			this.label4.Text = "/";
			// 
			// textBox2
			// 
			this.textBox2.ImeMode = System.Windows.Forms.ImeMode.On;
			this.textBox2.Location = new System.Drawing.Point(187, 27);
			this.textBox2.MaxLength = 48;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(21, 19);
			this.textBox2.TabIndex = 11;
			// 
			// textBox3
			// 
			this.textBox3.ImeMode = System.Windows.Forms.ImeMode.On;
			this.textBox3.Location = new System.Drawing.Point(226, 27);
			this.textBox3.MaxLength = 48;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(21, 19);
			this.textBox3.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(211, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(11, 12);
			this.label5.TabIndex = 15;
			this.label5.Text = "/";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(252, 27);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(22, 20);
			this.button1.TabIndex = 9;
			this.button1.Text = "▼";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(280, 27);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(37, 20);
			this.button2.TabIndex = 9;
			this.button2.Text = "今日";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(33, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 12);
			this.label6.TabIndex = 15;
			this.label6.Text = "アラーム日時";
			// 
			// FrmDefineAlarm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 459);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txMemo);
			this.Controls.Add(this.pnlOptTani);
			this.Controls.Add(this.chkTemplate);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.txTitle);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buSound);
			this.Controls.Add(this.buCancel);
			this.Controls.Add(this.buOK);
			this.Name = "FrmDefineAlarm";
			this.Text = "FrmDefineAlarm";
			this.pnlOptTani.ResumeLayout(false);
			this.pnlOptTani.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buSound;
		private System.Windows.Forms.Button buCancel;
		private System.Windows.Forms.Button buOK;
		private System.Windows.Forms.CheckBox chkTemplate;
		private System.Windows.Forms.TextBox txTitle;
		private System.Windows.Forms.Panel pnlOptTani;
		private System.Windows.Forms.RadioButton rdTaniSec;
		private System.Windows.Forms.RadioButton rdTaniMin;
		private System.Windows.Forms.RadioButton rdTaniHour;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txMemo;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
	}
}