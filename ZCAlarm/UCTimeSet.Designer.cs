namespace ZCAlarm
{
	partial class UCTimeSet
	{
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.rdInRemain = new System.Windows.Forms.RadioButton();
			this.rdInTime = new System.Windows.Forms.RadioButton();
			this.txCounter = new ZCAlarm.TCountEditor(this.components);
			this.lbRemain = new System.Windows.Forms.Label();
			this.pnlOptTani = new System.Windows.Forms.Panel();
			this.rdTaniSec = new System.Windows.Forms.RadioButton();
			this.rdTaniMin = new System.Windows.Forms.RadioButton();
			this.rdTaniHour = new System.Windows.Forms.RadioButton();
			this.pnlCount = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlTime = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.lbTime = new System.Windows.Forms.Label();
			this.txTargetTime = new ZCAlarm.ZCTextEditor(this.components);
			this.pnlOptTani.SuspendLayout();
			this.pnlCount.SuspendLayout();
			this.pnlTime.SuspendLayout();
			this.SuspendLayout();
			// 
			// rdInRemain
			// 
			this.rdInRemain.Appearance = System.Windows.Forms.Appearance.Button;
			this.rdInRemain.Location = new System.Drawing.Point(0, 0);
			this.rdInRemain.Name = "rdInRemain";
			this.rdInRemain.Size = new System.Drawing.Size(22, 24);
			this.rdInRemain.TabIndex = 0;
			this.rdInRemain.Text = "C";
			this.rdInRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rdInRemain.UseVisualStyleBackColor = true;
			this.rdInRemain.CheckedChanged += new System.EventHandler(this.rdInRemain_CheckedChanged);
			// 
			// rdInTime
			// 
			this.rdInTime.Appearance = System.Windows.Forms.Appearance.Button;
			this.rdInTime.Location = new System.Drawing.Point(22, 0);
			this.rdInTime.Name = "rdInTime";
			this.rdInTime.Size = new System.Drawing.Size(22, 24);
			this.rdInTime.TabIndex = 1;
			this.rdInTime.Text = "T";
			this.rdInTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rdInTime.UseVisualStyleBackColor = true;
			this.rdInTime.CheckedChanged += new System.EventHandler(this.rdInTime_CheckedChanged);
			// 
			// txCounter
			// 
			this.txCounter.CountTani = 0;
			this.txCounter.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txCounter.Location = new System.Drawing.Point(2, 2);
			this.txCounter.MaxLength = 5;
			this.txCounter.Name = "txCounter";
			this.txCounter.Size = new System.Drawing.Size(55, 19);
			this.txCounter.TabIndex = 0;
			// 
			// lbRemain
			// 
			this.lbRemain.Location = new System.Drawing.Point(308, 5);
			this.lbRemain.Name = "lbRemain";
			this.lbRemain.Size = new System.Drawing.Size(52, 16);
			this.lbRemain.TabIndex = 14;
			this.lbRemain.Text = "00:00:00";
			// 
			// pnlOptTani
			// 
			this.pnlOptTani.Controls.Add(this.rdTaniSec);
			this.pnlOptTani.Controls.Add(this.rdTaniMin);
			this.pnlOptTani.Controls.Add(this.rdTaniHour);
			this.pnlOptTani.Location = new System.Drawing.Point(61, 0);
			this.pnlOptTani.Name = "pnlOptTani";
			this.pnlOptTani.Size = new System.Drawing.Size(126, 23);
			this.pnlOptTani.TabIndex = 13;
			this.pnlOptTani.TabStop = true;
			// 
			// rdTaniSec
			// 
			this.rdTaniSec.AutoSize = true;
			this.rdTaniSec.Checked = true;
			this.rdTaniSec.Location = new System.Drawing.Point(83, 3);
			this.rdTaniSec.Name = "rdTaniSec";
			this.rdTaniSec.Size = new System.Drawing.Size(30, 16);
			this.rdTaniSec.TabIndex = 2;
			this.rdTaniSec.TabStop = true;
			this.rdTaniSec.Text = "S";
			this.rdTaniSec.UseVisualStyleBackColor = true;
			// 
			// rdTaniMin
			// 
			this.rdTaniMin.AutoSize = true;
			this.rdTaniMin.Location = new System.Drawing.Point(43, 3);
			this.rdTaniMin.Name = "rdTaniMin";
			this.rdTaniMin.Size = new System.Drawing.Size(32, 16);
			this.rdTaniMin.TabIndex = 1;
			this.rdTaniMin.Text = "M";
			this.rdTaniMin.UseVisualStyleBackColor = true;
			// 
			// rdTaniHour
			// 
			this.rdTaniHour.AutoSize = true;
			this.rdTaniHour.Location = new System.Drawing.Point(3, 3);
			this.rdTaniHour.Name = "rdTaniHour";
			this.rdTaniHour.Size = new System.Drawing.Size(31, 16);
			this.rdTaniHour.TabIndex = 0;
			this.rdTaniHour.Text = "H";
			this.rdTaniHour.UseVisualStyleBackColor = true;
			// 
			// pnlCount
			// 
			this.pnlCount.Controls.Add(this.label2);
			this.pnlCount.Controls.Add(this.lbRemain);
			this.pnlCount.Controls.Add(this.txCounter);
			this.pnlCount.Controls.Add(this.pnlOptTani);
			this.pnlCount.Location = new System.Drawing.Point(50, 0);
			this.pnlCount.Name = "pnlCount";
			this.pnlCount.Size = new System.Drawing.Size(363, 24);
			this.pnlCount.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(227, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 16);
			this.label2.TabIndex = 15;
			this.label2.Text = "ｶｳﾝﾄﾀﾞｳﾝ：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// pnlTime
			// 
			this.pnlTime.Controls.Add(this.label1);
			this.pnlTime.Controls.Add(this.lbTime);
			this.pnlTime.Controls.Add(this.txTargetTime);
			this.pnlTime.Location = new System.Drawing.Point(50, 0);
			this.pnlTime.Name = "pnlTime";
			this.pnlTime.Size = new System.Drawing.Size(363, 24);
			this.pnlTime.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(223, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 16);
			this.label1.TabIndex = 15;
			this.label1.Text = "ｱﾗｰﾑ時刻：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbTime
			// 
			this.lbTime.Location = new System.Drawing.Point(308, 5);
			this.lbTime.Name = "lbTime";
			this.lbTime.Size = new System.Drawing.Size(43, 16);
			this.lbTime.TabIndex = 14;
			this.lbTime.Text = "00:00";
			// 
			// txTargetTime
			// 
			this.txTargetTime.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txTargetTime.Location = new System.Drawing.Point(2, 2);
			this.txTargetTime.MaxLength = 5;
			this.txTargetTime.Name = "txTargetTime";
			this.txTargetTime.Size = new System.Drawing.Size(55, 19);
			this.txTargetTime.TabIndex = 0;
			// 
			// UCTimeSet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlTime);
			this.Controls.Add(this.pnlCount);
			this.Controls.Add(this.rdInTime);
			this.Controls.Add(this.rdInRemain);
			this.Name = "UCTimeSet";
			this.Size = new System.Drawing.Size(416, 26);
			this.pnlOptTani.ResumeLayout(false);
			this.pnlOptTani.PerformLayout();
			this.pnlCount.ResumeLayout(false);
			this.pnlCount.PerformLayout();
			this.pnlTime.ResumeLayout(false);
			this.pnlTime.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton rdInRemain;
		private System.Windows.Forms.RadioButton rdInTime;
		private TCountEditor txCounter;
		private System.Windows.Forms.Label lbRemain;
		private System.Windows.Forms.Panel pnlOptTani;
		private System.Windows.Forms.RadioButton rdTaniSec;
		private System.Windows.Forms.RadioButton rdTaniMin;
		private System.Windows.Forms.RadioButton rdTaniHour;
		private System.Windows.Forms.Panel pnlCount;
		private System.Windows.Forms.Panel pnlTime;
		private System.Windows.Forms.Label lbTime;
		private ZCTextEditor txTargetTime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
