namespace ZCAlarm
{
	partial class FrmEditSettings
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
			this.txtSoundPath = new System.Windows.Forms.TextBox();
			this.buCancel = new System.Windows.Forms.Button();
			this.buOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.buRef = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtSoundPath
			// 
			this.txtSoundPath.Location = new System.Drawing.Point(95, 29);
			this.txtSoundPath.Name = "txtSoundPath";
			this.txtSoundPath.Size = new System.Drawing.Size(354, 19);
			this.txtSoundPath.TabIndex = 0;
			// 
			// buCancel
			// 
			this.buCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buCancel.Location = new System.Drawing.Point(278, 84);
			this.buCancel.Name = "buCancel";
			this.buCancel.Size = new System.Drawing.Size(66, 23);
			this.buCancel.TabIndex = 3;
			this.buCancel.Text = "ｷｬﾝｾﾙ";
			this.buCancel.UseVisualStyleBackColor = true;
			// 
			// buOk
			// 
			this.buOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buOk.Location = new System.Drawing.Point(206, 84);
			this.buOk.Name = "buOk";
			this.buOk.Size = new System.Drawing.Size(66, 23);
			this.buOk.TabIndex = 2;
			this.buOk.Text = "OK";
			this.buOk.UseVisualStyleBackColor = true;
			this.buOk.Click += new System.EventHandler(this.buOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "ﾃﾞﾌｫﾙﾄｻｳﾝﾄﾞ";
			// 
			// buRef
			// 
			this.buRef.Location = new System.Drawing.Point(466, 25);
			this.buRef.Name = "buRef";
			this.buRef.Size = new System.Drawing.Size(45, 23);
			this.buRef.TabIndex = 1;
			this.buRef.Text = "参照...";
			this.buRef.UseVisualStyleBackColor = true;
			this.buRef.Click += new System.EventHandler(this.buRef_Click);
			// 
			// FrmEditSettings
			// 
			this.AcceptButton = this.buOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buCancel;
			this.ClientSize = new System.Drawing.Size(543, 116);
			this.ControlBox = false;
			this.Controls.Add(this.buRef);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSoundPath);
			this.Controls.Add(this.buCancel);
			this.Controls.Add(this.buOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmEditSettings";
			this.Text = "設定";
			this.Load += new System.EventHandler(this.FrmEditSettings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSoundPath;
		private System.Windows.Forms.Button buCancel;
		private System.Windows.Forms.Button buOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buRef;
	}
}