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
	/// <summary>
	/// カウントダウンタイマー新規作成入力フォーム
	/// </summary>
	public partial class FrmDefineKTimer : Form
	{

		// --------------------------------------------------------------------
		#region プロパティ
		// --------------------------------------------------------------------
		/// <summary>
		/// 設定時間（秒）
		/// </summary>
		public int InputTimeSec;

		/// <summary>
		/// カウントダウン時間設定用単位
		/// </summary>
		public int Tani;

		/// <summary>
		/// タイマータイトル入力テキスト
		/// </summary>
		public string InputTitle;

		/// <summary>
		/// メモ入力テキスト
		/// </summary>
		public string InputMemo;

		/// <summary>
		/// 繰り返し
		/// </summary>
		public bool AutoRepeat;

		/// <summary>
		/// テンプレート登録
		/// </summary>
		public bool AddTemplate;

		/// <summary>
		/// アラーム音ファイルパス
		/// </summary>
		public string Soundfile;

		#endregion

		// --------------------------------------------------------------------
		#region 初期処理
		// --------------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrmDefineKTimer()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Load イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmDefineKTimer_Load(object sender, EventArgs e)
		{

			// 初期値設定
			if (this.InputTimeSec < 0) {
				this.InputTimeSec = 0;
			}

			int count = 0;
			if (this.InputTimeSec > 0) {
				int hour = this.InputTimeSec / 3600;
				int minute = this.InputTimeSec / 60;
				if (this.Tani == Cs.CountTani.Hour) {
					if (hour == 0) {
						this.Tani = Cs.CountTani.Min;
					} else {
						count = hour;
					}
				}
				if (this.Tani == Cs.CountTani.Min) {
					if (minute == 0) {
						this.Tani =Cs.CountTani.Sec;
					} else {
						count = minute;
					}
				}
				if (count == 0) {
					this.Tani = Cs.CountTani.Sec;
					count = this.InputTimeSec;
				}
				this.txTime.Text = count.ToString();
			}

			this.SetTaniCheck();

			if (this.InputTitle != null) {
				this.txTitle.Text = this.InputTitle;
			}
			if (this.InputMemo != null) {
				this.txMemo.Text = this.InputMemo;
			}

			this.txTime.SpecifiedTani += new EventHandler(txTime_SpecifiedTani);
			this.txTime.TextChanged +=new EventHandler(txTime_TextChanged);
			this.txTime.ZCCmdKeyEvent += new ZCCmdKeyEventHandler(txTime_ZCCmdKeyEvent);
		}

		#endregion

		// --------------------------------------------------------------------
		#region 終了処理
		// --------------------------------------------------------------------
		private void buOK_Click(object sender, EventArgs e)
		{
			if (this.CheckInput()) {
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		#endregion

		// --------------------------------------------------------------------
		#region 操作応答
		// --------------------------------------------------------------------
		/// <summary>
		/// 単位ラジオ釦（時）チェック状態変化イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdTaniHour_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdTaniHour.Checked) {
				this.Tani = Cs.CountTani.Hour;
				this.UpdateDspTimeLabel();
			}
		}

		/// <summary>
		/// 単位ラジオ釦（分）チェック状態変化イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdTaniMin_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdTaniMin.Checked) {
				this.Tani = Cs.CountTani.Min;
				this.UpdateDspTimeLabel();
			}
		}

		/// <summary>
		/// 単位ラジオ釦（秒）チェック状態変化イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdTaniSec_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdTaniSec.Checked) {
				this.Tani = Cs.CountTani.Sec;
				this.UpdateDspTimeLabel();
			}

		}

		/// <summary>
		/// カウント値入力テキストエディタ Changeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txTime_TextChanged(object sender, EventArgs e)
		{
			this.UpdateDspTimeLabel();
		}

		/// <summary>
		/// カウント値入力テキストエディタにて単位指定があった時のイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txTime_SpecifiedTani(object sender, EventArgs e)
		{
			this.SetTaniCheck(this.txTime.CountTani);
		}

		/// <summary>
		/// サウンドボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buSound_Click(object sender, EventArgs e)
		{
			FrmSelectSound dialog = new FrmSelectSound();
			dialog.Filepath = this.Soundfile;
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				this.Soundfile = dialog.Filepath;
			}
		}

		/// <summary>
		/// 設定時間欄 ZCCmdKeyEvent キー入力フック
		/// </summary>
		/// <param name="o"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool txTime_ZCCmdKeyEvent(object o, ZCCmdKeyEventArgs e)
		{
			if (e.KeyData == Keys.Tab) {
				// TAB をオプションボタンではなく、タイトルテキストBOXへ飛ばす
				this.txTitle.Focus();
				return true;
			}
			return false;
		}

		#endregion

		// --------------------------------------------------------------------
		#region 補助メソッド
		// --------------------------------------------------------------------
		/// <summary>
		/// 入力をチェックする
		/// </summary>
		/// <returns>入力正常か</returns>
		private bool CheckInput()
		{
			if (this.InputTimeSec <= 0) {
				this.txTime.Focus();
				return false;
			}

			this.InputTitle = this.txTitle.Text;
			this.InputMemo = this.txMemo.Text;
			this.AutoRepeat = this.chkRepeat.Checked;
			this.AddTemplate = this.chkTemplate.Checked;

			return true;
		}

		/// <summary>
		/// カウント値位指定ボタンのチェックを設定する
		/// </summary>
		/// <param name="tani">設定する単位、0を指定すると現在の指定保存値に従ってチェックを付ける</param>
		private void SetTaniCheck(int tani = 0)
		{
			if (tani != 0) {
				this.Tani = tani;
			}

			switch (this.Tani) {
				case Cs.CountTani.Hour:
					this.rdTaniHour.Checked = true;
					break;
				case Cs.CountTani.Min:
					this.rdTaniMin.Checked = true;
					break;
				case Cs.CountTani.Sec:
					this.rdTaniSec.Checked = true;
					break;
				default:
					this.Tani = Cs.CountTani.Min;
					this.rdTaniMin.Checked = true;
					break;
			}
		}

		/// <summary>
		/// 入力されているカウント値を解釈する
		/// 正当な入力でない場合は、内部の秒数は０になる
		/// </summary>
		private void ParseInputCount()
		{
			double insec = 0.0;
			if (double.TryParse(this.txTime.Text, out insec)) {
				if (this.Tani == Cs.CountTani.Hour) {
					insec *= 3600.0;
				} else if (this.Tani == Cs.CountTani.Min) {
					insec *= 60.0;
				}
			}

			if (insec < 0.0) {
				insec = 0.0;
			}

			this.InputTimeSec = (int)insec;
		}

		/// <summary>
		/// 現在入力されているカウント値をラベル時分秒表示に反映する
		/// </summary>
		private void UpdateDspTimeLabel()
		{
			// 入力を秒数として読み取る
			this.ParseInputCount();
			int sec = this.InputTimeSec;
			int hour = sec / 3600;
			sec %= 3600;
			int min = sec / 60;
			sec %= 60;

			// ラベル表示更新
			this.lbTime.Text = string.Format("{0, 4}:{1:D2}:{2:D2}", hour, min, sec);
		}

		#endregion

	}
}
