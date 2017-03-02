using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZCAlarm
{
	/// <summary>
	/// コマンドキー入力イベント
	/// </summary>
	/// <param name="o">呼び出し元</param>
	/// <param name="e">イベントパラメータ</param>
	/// <returns>入力に対する処理をここで終了としたい時trueを返す</returns>
	public delegate bool ZCCmdKeyEventHandler(object o, ZCCmdKeyEventArgs e);

	/// <summary>
	/// コマンドキー入力イベントパラメータ
	/// </summary>
	public class ZCCmdKeyEventArgs : EventArgs
	{
		/// <summary>
		/// キーデータ
		/// </summary>
		public Keys KeyData { get; set; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ZCCmdKeyEventArgs(Keys p_keyData)
		{
			this.KeyData = p_keyData;
		}
	}
	
	public partial class ZCTextEditor : System.Windows.Forms.TextBox
	{
		/// <summary>
		/// コマンドキー入力イベントハンドラ
		/// </summary>
		[Description("Control の ProcessCmdKey フォームなどで処理する為のフック")]
		public event ZCCmdKeyEventHandler ZCCmdKeyEvent;

		public ZCTextEditor()
		{
			InitializeComponent();
		}

		public ZCTextEditor(IContainer container)
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
			if (this.ZCCmdKeyEvent != null) {
				if (this.ZCCmdKeyEvent(this, new ZCCmdKeyEventArgs(keyData))) {
					return true;
				}
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
