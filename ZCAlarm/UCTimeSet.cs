using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cs = ZCAlarm.Constants;

namespace ZCAlarm
{
	public partial class UCTimeSet : UserControl
	{
		// ------------------------------------------------------------------------------------------------------------
		#region プロパティーなど
		// ------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// コマンドキー入力イベントハンドラ
		/// </summary>
		[Description("Control の ProcessCmdKey フォームなどで処理する為のフック")]
		public event ZCCmdKeyEventHandler ZCCmdKeyEvent = null;

		/// <summary>
		/// タイマー設定タイプ
		/// </summary>
		public int TimeSetType = Cs.TimerType.Timer;

		/// <summary>
		/// アラーム時刻で設定時の[0:00からの 分]
		/// </summary>
		public int InputTimeMin = 0;

		/// <summary>
		/// タイマー設定時の設定秒数
		/// </summary>
		public int InputCountSec = 0;

		/// <summary>
		/// タイマー時間設定用単位
		/// </summary>
		public int Tani = Cs.CountTani.Sec;

		/// <summary>
		/// 入力値を返す
		/// </summary>
		public int InputValue
		{
			get
			{
				return this.TimeSetType == Cs.TimerType.Timer ? this.InputCountSec : this.InputTimeMin;
			}
		}
		#endregion

		// ------------------------------------------------------------------------------------------------------------
		#region 上位IF
		// ------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// タイマー値設定
		/// </summary>
		/// <param name="p_type"></param>
		/// <param name="p_count"></param>
		public void SetCount(int p_type, int p_count)
		{
			this.TimeSetType = p_type;

			if (p_type == Cs.TimerType.Timer) {
				this.InputCountSec = p_count;
				this.InputTimeMin = 0;
			} else {
				this.InputCountSec = 0;
				this.InputTimeMin = p_count;
			}

			// タイマー
			this.Tani = Cs.CountTani.Min;
			if (this.InputCountSec < 0) {
				this.InputCountSec = 0;
			}
			int count = 0;
			if (this.InputCountSec > 0) {
				if ((this.InputCountSec % 3600) == 0) {
					this.Tani = Cs.CountTani.Hour;
					count = this.InputCountSec / 3600;
				} else if ((this.InputCountSec % 60) == 0) {
					this.Tani = Cs.CountTani.Min;
					count = this.InputCountSec / 60;
				} else {
					this.Tani = Cs.CountTani.Sec;
					count = this.InputCountSec;
				}
			}
			this.txCounter.Text = count.ToString();
			this.SetTaniCheck();


			// アラーム
			int hh = this.InputTimeMin / 60;
			int mm = this.InputTimeMin % 60;
			this.txTargetTime.Text = string.Format("{0, 2}:{1:D2}", hh, mm);

			// トグル釦設定
			this.ToggleChange();

		}

		/// <summary>
		/// カウンター入力コントロールにフォーカスを設定し全選択状態にする
		/// </summary>
		public void SetFocusCounter()
		{
			if (this.TimeSetType == Cs.TimerType.Alarm) {
				this.txTargetTime.Focus();
				this.txTargetTime.SelectAll();
			} else {
				this.txCounter.Focus();
				this.txCounter.SelectAll();
			}
		}

		#endregion

		// ------------------------------------------------------------------------------------------------------------
		#region 初期処理
		// ------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public UCTimeSet()
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

			// 選択されている入力方法に対応するラジオ釦をチェックする
			this.ToggleChange();
			this.rdTaniSec.TabStop = false;

			// イベントハンドラ
			this.txCounter.SpecifiedTani += new EventHandler(txCounter_SpecifiedTani);
			this.txCounter.TextChanged += new EventHandler(txCounter_TextChanged);
			this.txCounter.ZCCmdKeyEvent += new ZCCmdKeyEventHandler(txCounter_ZCCmdKeyEvent);
			this.txTargetTime.TextChanged += new EventHandler(txTargetTime_TextChanged);
			this.txTargetTime.ZCCmdKeyEvent += new ZCCmdKeyEventHandler(txTargetTime_ZCCmdKeyEvent);

			this.rdTaniHour.CheckedChanged += new EventHandler(rdTaniHour_CheckedChanged);
			this.rdTaniMin.CheckedChanged += new EventHandler(rdTaniMin_CheckedChanged);
			this.rdTaniSec.CheckedChanged += new EventHandler(rdTaniSec_CheckedChanged);
		}
		#endregion

		// ------------------------------------------------------------------------------------------------------------
		#region 操作応答
		// ------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// 「残」釦チェックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdInRemain_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdInRemain.Checked) {
				this.ChangeTimeSetType(Cs.TimerType.Timer);
				if (this.rdInRemain.Focused) {
					this.SetFocusCounter();
				}
			}
			this.rdInRemain.TabStop = false;
		}

		/// <summary>
		/// 「時」釦チェックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdInTime_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdInTime.Checked) {
				this.ChangeTimeSetType(Cs.TimerType.Alarm);
				if (this.rdInTime.Focused) {
					this.SetFocusCounter();
				}
			}
			this.rdInTime.TabStop = false;
		}


		/// <summary>
		/// 単位ラジオ釦（時）チェック状態変化イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rdTaniHour_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rdTaniHour.Checked) {
				this.Tani = Cs.CountTani.Hour;
				this.UpdateDspCountLabel();
			}
			this.rdTaniHour.TabStop = false;
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
				this.UpdateDspCountLabel();
			}
			this.rdTaniMin.TabStop = false;
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
				this.UpdateDspCountLabel();
			}
			this.rdTaniSec.TabStop = false;
		}

		/// <summary>
		/// カウント値入力テキストエディタ Changeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txCounter_TextChanged(object sender, EventArgs e)
		{
			this.UpdateDspCountLabel();
		}

		/// <summary>
		/// カウント値入力テキストエディタにて単位指定があった時のイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txCounter_SpecifiedTani(object sender, EventArgs e)
		{
			this.SetTaniCheck(this.txCounter.CountTani);
		}

		/// <summary>
		/// 設定時間欄 ZCCmdKeyEvent キー入力フック
		/// </summary>
		/// <param name="o"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool txCounter_ZCCmdKeyEvent(object o, ZCCmdKeyEventArgs e)
		{
			if (this.ZCCmdKeyEvent != null) {
				return this.ZCCmdKeyEvent(this, e);
			}

			if (e.KeyData == Keys.C) {
				this.rdInRemain.Checked = true;
			} else if (e.KeyData == Keys.T) {
				this.rdInTime.Checked = true;
			} else {
				return false;
			}
			return true;
		}

		/// <summary>
		/// 設定時間欄 ZCCmdKeyEvent キー入力フック
		/// </summary>
		/// <param name="o"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool txTargetTime_ZCCmdKeyEvent(object o, ZCCmdKeyEventArgs e)
		{
			if (this.ZCCmdKeyEvent != null) {
				return this.ZCCmdKeyEvent(this, e);
			}

			if (e.KeyData == Keys.C) {
				this.rdInRemain.Checked = true;
			} else if (e.KeyData == Keys.T) {
				this.rdInTime.Checked = true;
			} else {
				return false;
			}
			return true;
		}

		
		/// <summary>
		/// 時刻値入力テキストエディタ Changeイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txTargetTime_TextChanged(object sender, EventArgs e)
		{
			this.UpdateDspTimeLabel();
		}
		#endregion


		// ------------------------------------------------------------------------------------------------------------
		#region 補助処理
		// ------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// タイマータイプトグルを内部値に合わせてチェック付ける
		/// </summary>
		private void ToggleChange()
		{
			// 選択されている入力方法に対応するラジオ釦をチェックする
			if (this.TimeSetType == Cs.TimerType.Timer) {
				this.rdInRemain.Checked = true;
			} else {
				this.rdInTime.Checked = true;
			}
		}

		/// <summary>
		/// カウント設定方法を変更する
		/// </summary>
		/// <param name="type">設定方法</param>
		private void ChangeTimeSetType(int type)
		{

			if (type == Cs.TimerType.Timer) {
				this.pnlCount.Visible = true;
				if (txTargetTime.Focused) {
					this.txCounter.Focus();
				}
				this.pnlTime.Visible = false;
			} else {
				this.pnlTime.Visible = true;
				if (this.txCounter.Focused || this.rdTaniHour.Focused || this.rdTaniMin.Focused || this.rdTaniSec.Focused) {
					this.txTargetTime.Focus();
				}
				this.pnlCount.Visible = false;
			}
			this.TimeSetType = type;
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
			if (double.TryParse(this.txCounter.Text, out insec)) {
				if (this.Tani == Cs.CountTani.Hour) {
					insec *= 3600.0;
				} else if (this.Tani == Cs.CountTani.Min) {
					insec *= 60.0;
				}
			}

			int insecInt = (int)insec;
			int maxCountSec = 24 * 3600 - 1;
			if (insecInt < 0) {
				insecInt = 0;
			} else if (insecInt > maxCountSec) {
				insecInt = maxCountSec;
			}
			this.InputCountSec = insecInt;
		}

		/// <summary>
		/// 現在入力されているカウント値をラベル時分秒表示に反映する
		/// </summary>
		private void UpdateDspCountLabel()
		{
			// 入力を秒数として読み取る
			this.ParseInputCount();
			int sec = this.InputCountSec;
			int hour = sec / 3600;
			sec %= 3600;
			int min = sec / 60;
			sec %= 60;

			// ラベル表示更新
			this.lbRemain.Text = string.Format("{0, 2}:{1:D2}:{2:D2}", hour, min, sec);
		}

		/// <summary>
		/// 入力されている時刻値を解釈する
		/// 正当な入力でない場合は、内部の時刻は0:00とかになる
		/// </summary>
		private void ParseInputTime()
		{
			bool noerror = true;
			int inmin = 0;
			int inhour = 0;


			string[] splitColon = this.txTargetTime.Text.Split(':');
			if (splitColon.Length > 1) {
				inhour = -1;
				if (!string.IsNullOrWhiteSpace(splitColon[0])) {
					inhour = 0;
					noerror = int.TryParse(splitColon[0], out inhour);
				}
				if (noerror) {
					if (!string.IsNullOrWhiteSpace(splitColon[1])) {
						noerror = int.TryParse(splitColon[1], out inmin);
					}
				}

			} else if (int.TryParse(this.txTargetTime.Text, out inmin)) {
				if (inmin < 0) {
					inmin = 0;
				}

				if (inmin < 100) {
					inhour = -1;
				} else {
					inhour = inmin / 100;
				}
				inmin = inmin % 100;

				if (inhour > 23) {
					inhour = 0;
				}
				if (inmin > 59) {
					inmin = 0;
				}
			}

			if (inhour < 0) {
				DateTime now = DateTime.Now;
				inhour = now.Hour;
				if (inmin <= now.Minute) {
					if (++inhour > 23) {
						inhour = 0;
					}
				}
			}

			this.InputTimeMin = inhour * 60 + inmin;
		}

		/// <summary>
		/// 現在入力されている時刻値をラベル時分表示に反映する
		/// </summary>
		private void UpdateDspTimeLabel()
		{
			this.ParseInputTime();

			int min = this.InputTimeMin;
			int hour = min / 60;
			min = min % 60;

			// ラベル表示更新
			this.lbTime.Text = string.Format("{0, 2}:{1:D2}", hour, min);
		}

		#endregion

	}
}
