namespace ZCAlarm
{
	partial class FrmTimerSet
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
			this.lstDefs = new System.Windows.Forms.ListView();
			this.TName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.StartMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lstMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miDelTemplate = new System.Windows.Forms.ToolStripMenuItem();
			this.miMoveTop = new System.Windows.Forms.ToolStripMenuItem();
			this.miMoveBottom = new System.Windows.Forms.ToolStripMenuItem();
			this.miAutoStart = new System.Windows.Forms.ToolStripMenuItem();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txTitle = new System.Windows.Forms.TextBox();
			this.buSound = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txMemo = new System.Windows.Forms.RichTextBox();
			this.buUpdTemplate = new System.Windows.Forms.Button();
			this.buOK = new System.Windows.Forms.Button();
			this.buAddTemplate = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.ucTimeSet = new ZCAlarm.UCTimeSet();
			this.txSoundPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buCancel = new System.Windows.Forms.Button();
			this.lstMenuStrip.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstDefs
			// 
			this.lstDefs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TName,
            this.StartMode});
			this.lstDefs.ContextMenuStrip = this.lstMenuStrip;
			this.lstDefs.HideSelection = false;
			this.lstDefs.Location = new System.Drawing.Point(9, 27);
			this.lstDefs.Name = "lstDefs";
			this.lstDefs.Size = new System.Drawing.Size(163, 306);
			this.lstDefs.TabIndex = 2;
			this.lstDefs.UseCompatibleStateImageBehavior = false;
			this.lstDefs.SelectedIndexChanged += new System.EventHandler(this.lstDefs_SelectedIndexChanged);
			// 
			// TName
			// 
			this.TName.Text = "名称";
			this.TName.Width = 120;
			// 
			// StartMode
			// 
			this.StartMode.Text = "起動";
			this.StartMode.Width = 38;
			// 
			// lstMenuStrip
			// 
			this.lstMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDelTemplate,
            this.miMoveTop,
            this.miMoveBottom,
            this.miAutoStart});
			this.lstMenuStrip.Name = "lstMenuStrip";
			this.lstMenuStrip.Size = new System.Drawing.Size(159, 92);
			this.lstMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.lstMenuStrip_ItemClicked);
			// 
			// miDelTemplate
			// 
			this.miDelTemplate.Name = "miDelTemplate";
			this.miDelTemplate.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.miDelTemplate.Size = new System.Drawing.Size(158, 22);
			this.miDelTemplate.Text = "削除";
			// 
			// miMoveTop
			// 
			this.miMoveTop.Name = "miMoveTop";
			this.miMoveTop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
			this.miMoveTop.Size = new System.Drawing.Size(158, 22);
			this.miMoveTop.Text = "最初へ";
			// 
			// miMoveBottom
			// 
			this.miMoveBottom.Name = "miMoveBottom";
			this.miMoveBottom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
			this.miMoveBottom.Size = new System.Drawing.Size(158, 22);
			this.miMoveBottom.Text = "最後へ";
			// 
			// miAutoStart
			// 
			this.miAutoStart.Name = "miAutoStart";
			this.miAutoStart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
			this.miAutoStart.Size = new System.Drawing.Size(158, 22);
			this.miAutoStart.Text = "自動起動";
			this.miAutoStart.Click += new System.EventHandler(this.miAutoStart_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 12);
			this.label3.TabIndex = 16;
			this.label3.Text = "ﾒﾓ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 15;
			this.label1.Text = "名称";
			// 
			// txTitle
			// 
			this.txTitle.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txTitle.Location = new System.Drawing.Point(51, 50);
			this.txTitle.MaxLength = 48;
			this.txTitle.Name = "txTitle";
			this.txTitle.Size = new System.Drawing.Size(374, 19);
			this.txTitle.TabIndex = 1;
			// 
			// buSound
			// 
			this.buSound.Location = new System.Drawing.Point(380, 226);
			this.buSound.Name = "buSound";
			this.buSound.Size = new System.Drawing.Size(45, 24);
			this.buSound.TabIndex = 4;
			this.buSound.Text = "参照...";
			this.buSound.UseVisualStyleBackColor = true;
			this.buSound.Click += new System.EventHandler(this.buSound_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txMemo);
			this.groupBox1.Controls.Add(this.buUpdTemplate);
			this.groupBox1.Controls.Add(this.buOK);
			this.groupBox1.Controls.Add(this.buAddTemplate);
			this.groupBox1.Controls.Add(this.buSound);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.ucTimeSet);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txSoundPath);
			this.groupBox1.Controls.Add(this.txTitle);
			this.groupBox1.Location = new System.Drawing.Point(181, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(435, 321);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ﾀｲﾏｰ情報";
			// 
			// txMemo
			// 
			this.txMemo.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txMemo.Location = new System.Drawing.Point(51, 75);
			this.txMemo.Name = "txMemo";
			this.txMemo.Size = new System.Drawing.Size(374, 145);
			this.txMemo.TabIndex = 2;
			this.txMemo.Text = "";
			this.txMemo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txMemo_LinkClicked);
			this.txMemo.Enter += new System.EventHandler(this.txMemo_Enter);
			this.txMemo.Leave += new System.EventHandler(this.txMemo_Leave);
			// 
			// buUpdTemplate
			// 
			this.buUpdTemplate.Location = new System.Drawing.Point(6, 260);
			this.buUpdTemplate.Name = "buUpdTemplate";
			this.buUpdTemplate.Size = new System.Drawing.Size(136, 24);
			this.buUpdTemplate.TabIndex = 5;
			this.buUpdTemplate.Text = "<< ﾃﾝﾌﾟﾚｰﾄ変更(&U)";
			this.buUpdTemplate.UseVisualStyleBackColor = true;
			this.buUpdTemplate.Click += new System.EventHandler(this.buUpdTemplate_Click);
			// 
			// buOK
			// 
			this.buOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buOK.Location = new System.Drawing.Point(148, 260);
			this.buOK.Name = "buOK";
			this.buOK.Size = new System.Drawing.Size(277, 54);
			this.buOK.TabIndex = 7;
			this.buOK.Text = "ﾀｲﾏｰ起動";
			this.buOK.UseVisualStyleBackColor = true;
			this.buOK.Click += new System.EventHandler(this.buOK_Click);
			// 
			// buAddTemplate
			// 
			this.buAddTemplate.Location = new System.Drawing.Point(6, 290);
			this.buAddTemplate.Name = "buAddTemplate";
			this.buAddTemplate.Size = new System.Drawing.Size(136, 24);
			this.buAddTemplate.TabIndex = 6;
			this.buAddTemplate.Text = "<< ﾃﾝﾌﾟﾚｰﾄ追加(&A)";
			this.buAddTemplate.UseVisualStyleBackColor = true;
			this.buAddTemplate.Click += new System.EventHandler(this.buAddTemplate_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 232);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 12);
			this.label4.TabIndex = 16;
			this.label4.Text = "ｻｳﾝﾄﾞ";
			// 
			// ucTimeSet
			// 
			this.ucTimeSet.Location = new System.Drawing.Point(9, 20);
			this.ucTimeSet.Name = "ucTimeSet";
			this.ucTimeSet.Size = new System.Drawing.Size(416, 26);
			this.ucTimeSet.TabIndex = 0;
			// 
			// txSoundPath
			// 
			this.txSoundPath.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.txSoundPath.Location = new System.Drawing.Point(51, 229);
			this.txSoundPath.MaxLength = 48;
			this.txSoundPath.Name = "txSoundPath";
			this.txSoundPath.Size = new System.Drawing.Size(323, 19);
			this.txSoundPath.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 12);
			this.label2.TabIndex = 15;
			this.label2.Text = "ﾃﾝﾌﾟﾚｰﾄ";
			// 
			// buCancel
			// 
			this.buCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buCancel.Location = new System.Drawing.Point(274, 339);
			this.buCancel.Name = "buCancel";
			this.buCancel.Size = new System.Drawing.Size(75, 24);
			this.buCancel.TabIndex = 1;
			this.buCancel.Text = "閉じる";
			this.buCancel.UseVisualStyleBackColor = true;
			// 
			// FrmTimerSet
			// 
			this.AcceptButton = this.buOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 365);
			this.ControlBox = false;
			this.Controls.Add(this.buCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lstDefs);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmTimerSet";
			this.Text = "ﾀｲﾏｰ設定";
			this.lstMenuStrip.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private UCTimeSet ucTimeSet;
		private System.Windows.Forms.ListView lstDefs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txTitle;
		private System.Windows.Forms.Button buSound;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buAddTemplate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buCancel;
		private System.Windows.Forms.Button buOK;
		private System.Windows.Forms.ColumnHeader TName;
		private System.Windows.Forms.Button buUpdTemplate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txSoundPath;
		private System.Windows.Forms.ContextMenuStrip lstMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem miDelTemplate;
		private System.Windows.Forms.ToolStripMenuItem miMoveTop;
		private System.Windows.Forms.ToolStripMenuItem miMoveBottom;
		private System.Windows.Forms.ColumnHeader StartMode;
		private System.Windows.Forms.ToolStripMenuItem miAutoStart;
		private System.Windows.Forms.RichTextBox txMemo;
	}
}