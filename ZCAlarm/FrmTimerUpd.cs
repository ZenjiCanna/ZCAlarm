using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cs = ZCAlarm.Constants;

namespace ZCAlarm
{
	public partial class FrmTimerUpd : Form
	{
		// --------------------------------------------------------------------
		#region プロパティ
		// --------------------------------------------------------------------
		/// <summary>
		/// タイマータイプ
		/// </summary>
		public int Type { get; set; }

		/// <summary>
		/// 設定カウント(タイマ型の時：タイマー秒数、アラーム型の時：0:00からの分数) 
		/// </summary>
		public int SetCount { get; set; }

		/// <summary>
		/// タイトル
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// メモ
		/// </summary>
		public string Memo { get; set; }

		/// <summary>
		/// アラーム音ファイルパス
		/// </summary>
		public string Soundfile { get; set; }


		#endregion

		// --------------------------------------------------------------------
		#region 初期処理
		// --------------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrmTimerUpd()
		{
			InitializeComponent();
		}

		/// <summary>
		/// OnLoad オーバーライド
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// 情報の初期表示設定
			if (this.SetCount < 0) {
				this.SetCount = 0;
			}
			this.ucTimeSet.SetCount(this.Type, this.SetCount);
			if (this.Title != null) {
				this.txTitle.Text = this.Title;
			}
			if (this.Memo != null) {
				this.txMemo.Text = this.Memo;
			}
			if (this.Soundfile != null) {
				this.txSoundPath.Text = this.Soundfile;
			}
		}
		#endregion

		// --------------------------------------------------------------------
		#region 終了処理
		// --------------------------------------------------------------------
		private void buOK_Click(object sender, EventArgs e)
		{
			TimerDef input;
			if (this.CheckInput(out input)) {
				this.Type = input.Type;
				this.SetCount = input.SetCount;
				this.Title = input.Name;
				this.Memo = input.Memo;
				this.Soundfile = input.Soundfile;
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		#endregion

		// --------------------------------------------------------------------
		#region 操作応答
		// --------------------------------------------------------------------
		/// <summary>
		/// サウンド参照釦
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buSound_Click(object sender, EventArgs e)
		{

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileName = this.txSoundPath.Text;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				this.txSoundPath.Text = dialog.FileName;
			}
		}

		/// <summary>
		/// ProcessCmdKey オーバーライド
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{

			if (keyData == Keys.Escape) {
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		/// <summary>
		/// Memoテキストエディタ Leaveイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txMemo_Leave(object sender, EventArgs e)
		{
			this.AcceptButton = this.buOK;
		}

		/// <summary>
		/// Memoテキストエディタ Enterイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txMemo_Enter(object sender, EventArgs e)
		{
			// Enter が改行になるように デフォルト釦を一時的になしにする
			this.AcceptButton = null;
		}

		/// <summary>
		/// メモ欄でのリンククリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txMemo_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			// クリックされたリンクを開く
			System.Diagnostics.Process.Start(e.LinkText);
		}
		#endregion


		// --------------------------------------------------------------------
		#region 補助処理
		// --------------------------------------------------------------------
		/// <summary>
		/// 入力をチェックする
		/// </summary>
		/// <returns>入力正常か</returns>
		private bool CheckInput(out TimerDef outDef)
		{
			outDef = null;

			TimerDef input = new TimerDef();
			input.Memo = this.txMemo.Text;
			input.Name = this.txTitle.Text;
			input.AutoStart = false;
			input.Type = this.ucTimeSet.TimeSetType;
			input.SetCount = this.ucTimeSet.InputValue;
			input.Soundfile = this.txSoundPath.Text;

			if (input.Type == Cs.TimerType.Timer) {
				if (input.SetCount < 1) {
					this.ucTimeSet.Focus();
					return false;
				}
			}

			outDef = input;
			return true;
		}
		#endregion
	}
}
