using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cs = ZCAlarm.Constants;

namespace ZCAlarm
{
	public partial class TCountEditor : ZCTextEditor
	{
		/// <summary>
		/// 単位指定があったよイベント
		/// </summary>
		public event EventHandler SpecifiedTani;

		/// <summary>
		/// 単位指定キーが押された際に最後の指定単位を保持する
		/// </summary>
		private int countTani;
		public int CountTani
		{
			get { return this.countTani; }
			set { this.countTani = value; }
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TCountEditor()
		{
			InitializeComponent();
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TCountEditor(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// ProcessCmdKey オーバーライド
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{

			while (keyData >= Keys.A && keyData <= Keys.Z) {
				// アルファベットは HMS だけ単位指定
				if (keyData == Keys.H) {
					this.countTani = Cs.CountTani.Hour;
				} else if (keyData == Keys.M) {
					this.countTani = Cs.CountTani.Min;
				} else if (keyData == Keys.S) {
					this.countTani = Cs.CountTani.Sec;
				} else {
					break;		// それ以外のアルファベットは基本クラスへ
				}

				// イベント通知
				this.OnSpecifiedTani(new EventArgs());
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		/// <summary>
		/// 単位指定あった際の処理
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnSpecifiedTani(EventArgs e)
		{
			if (this.SpecifiedTani != null) {
				this.SpecifiedTani(this, e);
			}
		}
	}
}
