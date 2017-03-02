namespace ZCAlarm
{
	partial class FrmTimerUpd
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
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txSoundPath = new System.Windows.Forms.TextBox();
			this.txTitle = new System.Windows.Forms.TextBox();
			this.buCancel = new System.Windows.Forms.Button();
			this.buOK = new System.Windows.Forms.Button();
			this.txMemo = new System.Windows.Forms.RichTextBox();
			this.ucTimeSet = new ZCAlarm.UCTimeSet();
			this.SuspendLayout();
			// 
			// buSound
			// 
			this.buSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buSound.Location = new System.Drawing.Point(381, 216);
			this.buSound.Name = "buSound";
			this.buSound.Size = new System.Drawing.Size(45, 24);
			this.buSound.TabIndex = 4;
			this.buSound.Text = "参照...";
			this.buSound.UseVisualStyleBackColor = true;
			this.buSound.Click += new System.EventHandler(this.buSound_Click);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 222);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 12);
			this.label4.TabIndex = 24;
			this.label4.Text = "ｻｳﾝﾄﾞ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 12);
			this.label3.TabIndex = 23;
			this.label3.Text = "ﾒﾓ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 22;
			this.label1.Text = "名称";
			// 
			// txSoundPath
			// 
			this.txSoundPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txSoundPath.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.txSoundPath.Location = new System.Drawing.Point(52, 219);
			this.txSoundPath.MaxLength = 48;
			this.txSoundPath.Name = "txSoundPath";
			this.txSoundPath.Size = new System.Drawing.Size(323, 19);
			this.txSoundPath.TabIndex = 3;
			// 
			// txTitle
			// 
			this.txTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txTitle.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txTitle.Location = new System.Drawing.Point(52, 40);
			this.txTitle.MaxLength = 48;
			this.txTitle.Name = "txTitle";
			this.txTitle.Size = new System.Drawing.Size(374, 19);
			this.txTitle.TabIndex = 1;
			// 
			// buCancel
			// 
			this.buCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buCancel.Location = new System.Drawing.Point(221, 250);
			this.buCancel.Name = "buCancel";
			this.buCancel.Size = new System.Drawing.Size(75, 24);
			this.buCancel.TabIndex = 6;
			this.buCancel.Text = "ｷｬﾝｾﾙ";
			this.buCancel.UseVisualStyleBackColor = true;
			// 
			// buOK
			// 
			this.buOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buOK.Location = new System.Drawing.Point(140, 250);
			this.buOK.Name = "buOK";
			this.buOK.Size = new System.Drawing.Size(75, 24);
			this.buOK.TabIndex = 5;
			this.buOK.Text = "OK";
			this.buOK.UseVisualStyleBackColor = true;
			this.buOK.Click += new System.EventHandler(this.buOK_Click);
			// 
			// txMemo
			// 
			this.txMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txMemo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txMemo.Location = new System.Drawing.Point(52, 66);
			this.txMemo.Name = "txMemo";
			this.txMemo.Size = new System.Drawing.Size(373, 146);
			this.txMemo.TabIndex = 2;
			this.txMemo.Text = "";
			this.txMemo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txMemo_LinkClicked);
			this.txMemo.Enter += new System.EventHandler(this.txMemo_Enter);
			this.txMemo.Leave += new System.EventHandler(this.txMemo_Leave);
			// 
			// ucTimeSet
			// 
			this.ucTimeSet.Location = new System.Drawing.Point(10, 10);
			this.ucTimeSet.Name = "ucTimeSet";
			this.ucTimeSet.Size = new System.Drawing.Size(416, 26);
			this.ucTimeSet.TabIndex = 0;
			// 
			// FrmTimerUpd
			// 
			this.AcceptButton = this.buOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 276);
			this.ControlBox = false;
			this.Controls.Add(this.txMemo);
			this.Controls.Add(this.buOK);
			this.Controls.Add(this.buCancel);
			this.Controls.Add(this.buSound);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ucTimeSet);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txSoundPath);
			this.Controls.Add(this.txTitle);
			this.Name = "FrmTimerUpd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ﾀｲﾏｰ情報";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buSound;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private UCTimeSet ucTimeSet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txSoundPath;
		private System.Windows.Forms.TextBox txTitle;
		private System.Windows.Forms.Button buCancel;
		private System.Windows.Forms.Button buOK;
		private System.Windows.Forms.RichTextBox txMemo;
	}
}