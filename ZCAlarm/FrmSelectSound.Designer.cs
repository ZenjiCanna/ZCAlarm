namespace ZCAlarm
{
	partial class FrmSelectSound
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
			this.buRef = new System.Windows.Forms.Button();
			this.buPlay = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.buOk = new System.Windows.Forms.Button();
			this.buCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buRef
			// 
			this.buRef.Location = new System.Drawing.Point(383, 34);
			this.buRef.Name = "buRef";
			this.buRef.Size = new System.Drawing.Size(45, 23);
			this.buRef.TabIndex = 1;
			this.buRef.Text = "参照...";
			this.buRef.UseVisualStyleBackColor = true;
			this.buRef.Click += new System.EventHandler(this.buRef_Click);
			// 
			// buPlay
			// 
			this.buPlay.Location = new System.Drawing.Point(338, 61);
			this.buPlay.Name = "buPlay";
			this.buPlay.Size = new System.Drawing.Size(30, 20);
			this.buPlay.TabIndex = 2;
			this.buPlay.Text = ">>";
			this.buPlay.UseVisualStyleBackColor = true;
			this.buPlay.Click += new System.EventHandler(this.buPlay_Click);
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(31, 36);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(337, 19);
			this.txtPath.TabIndex = 0;
			// 
			// buOk
			// 
			this.buOk.Location = new System.Drawing.Point(167, 106);
			this.buOk.Name = "buOk";
			this.buOk.Size = new System.Drawing.Size(66, 23);
			this.buOk.TabIndex = 3;
			this.buOk.Text = "OK";
			this.buOk.UseVisualStyleBackColor = true;
			this.buOk.Click += new System.EventHandler(this.buOK_Click);
			// 
			// buCancel
			// 
			this.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buCancel.Location = new System.Drawing.Point(239, 106);
			this.buCancel.Name = "buCancel";
			this.buCancel.Size = new System.Drawing.Size(66, 23);
			this.buCancel.TabIndex = 4;
			this.buCancel.Text = "キャンセル";
			this.buCancel.UseVisualStyleBackColor = true;
			// 
			// FrmSelectSound
			// 
			this.AcceptButton = this.buOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buCancel;
			this.ClientSize = new System.Drawing.Size(468, 141);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.buPlay);
			this.Controls.Add(this.buCancel);
			this.Controls.Add(this.buOk);
			this.Controls.Add(this.buRef);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmSelectSound";
			this.Text = "サウンド選択";
			this.Load += new System.EventHandler(this.FrmSelectSound_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buRef;
		private System.Windows.Forms.Button buPlay;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button buOk;
		private System.Windows.Forms.Button buCancel;
	}
}