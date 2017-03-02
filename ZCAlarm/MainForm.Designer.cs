namespace ZCAlarm
{
	partial class MainForm
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

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timerList = new System.Windows.Forms.ListView();
			this.TName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miNewTimer = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditInstance = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.miStop = new System.Windows.Forms.ToolStripMenuItem();
			this.miStart = new System.Windows.Forms.ToolStripMenuItem();
			this.miDel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.miRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.listContext.SuspendLayout();
			this.SuspendLayout();
			// 
			// timerList
			// 
			this.timerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TName,
            this.Time,
            this.Memo});
			this.timerList.ContextMenuStrip = this.listContext;
			this.timerList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timerList.Location = new System.Drawing.Point(0, 0);
			this.timerList.Name = "timerList";
			this.timerList.Size = new System.Drawing.Size(437, 285);
			this.timerList.TabIndex = 0;
			this.timerList.UseCompatibleStateImageBehavior = false;
			this.timerList.SelectedIndexChanged += new System.EventHandler(this.timerList_SelectedIndexChanged);
			this.timerList.DoubleClick += new System.EventHandler(this.timerList_DoubleClick);
			// 
			// TName
			// 
			this.TName.Text = "名称";
			// 
			// Time
			// 
			this.Time.Text = "残時間";
			// 
			// Memo
			// 
			this.Memo.Text = "ﾒﾓ";
			// 
			// listContext
			// 
			this.listContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewTimer,
            this.miEditInstance,
            this.toolStripSeparator2,
            this.miStop,
            this.miStart,
            this.miDel,
            this.toolStripSeparator1,
            this.miRestore,
            this.toolStripSeparator3,
            this.miSettings,
            this.miAbout});
			this.listContext.Name = "listContext";
			this.listContext.Size = new System.Drawing.Size(174, 198);
			this.listContext.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.listContext_ItemClicked);
			// 
			// miNewTimer
			// 
			this.miNewTimer.Name = "miNewTimer";
			this.miNewTimer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
			this.miNewTimer.Size = new System.Drawing.Size(173, 22);
			this.miNewTimer.Text = "ﾀｲﾏｰ設定...";
			// 
			// miEditInstance
			// 
			this.miEditInstance.Name = "miEditInstance";
			this.miEditInstance.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
			this.miEditInstance.Size = new System.Drawing.Size(173, 22);
			this.miEditInstance.Text = "ﾌﾟﾛﾊﾟﾃｨｰ...";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
			// 
			// miStop
			// 
			this.miStop.Name = "miStop";
			this.miStop.ShortcutKeyDisplayString = "Esc";
			this.miStop.Size = new System.Drawing.Size(173, 22);
			this.miStop.Text = "停止";
			// 
			// miStart
			// 
			this.miStart.Name = "miStart";
			this.miStart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
			this.miStart.Size = new System.Drawing.Size(173, 22);
			this.miStart.Text = "再起動";
			// 
			// miDel
			// 
			this.miDel.Name = "miDel";
			this.miDel.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.miDel.Size = new System.Drawing.Size(173, 22);
			this.miDel.Text = "削除";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
			// 
			// miSettings
			// 
			this.miSettings.Name = "miSettings";
			this.miSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
			this.miSettings.Size = new System.Drawing.Size(173, 22);
			this.miSettings.Text = "設定...";
			// 
			// miAbout
			// 
			this.miAbout.Name = "miAbout";
			this.miAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
			this.miAbout.Size = new System.Drawing.Size(173, 22);
			this.miAbout.Text = "ﾊﾞｰｼﾞｮﾝ情報";
			// 
			// miRestore
			// 
			this.miRestore.Name = "miRestore";
			this.miRestore.Size = new System.Drawing.Size(173, 22);
			this.miRestore.Text = "前回終了時の状態に";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 285);
			this.Controls.Add(this.timerList);
			this.Name = "MainForm";
			this.Text = "ZCAlarm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.listContext.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView timerList;
		private System.Windows.Forms.ColumnHeader TName;
		private System.Windows.Forms.ColumnHeader Time;
		private System.Windows.Forms.ColumnHeader Memo;
		private System.Windows.Forms.ContextMenuStrip listContext;
		private System.Windows.Forms.ToolStripMenuItem miNewTimer;
		private System.Windows.Forms.ToolStripMenuItem miDel;
		private System.Windows.Forms.ToolStripMenuItem miEditInstance;
		private System.Windows.Forms.ToolStripMenuItem miStop;
		private System.Windows.Forms.ToolStripMenuItem miStart;
		private System.Windows.Forms.ToolStripMenuItem miSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem miAbout;
		private System.Windows.Forms.ToolStripMenuItem miRestore;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}

