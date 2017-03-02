using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCAlarm
{
	/// <summary>
	/// タイマー定義情報
	/// </summary>
	public class TimerDef
	{
		#region 定数
		public const int cTypeTimer = Constants.TimerType.Timer;			// カウントダウンタイマ型
		public const int cTypeAlarm = Constants.TimerType.Alarm;			// アラーム時刻型

		#endregion

		#region 属性
		/// <summary>
		/// タイマー名称
		/// </summary>
		private string name = "";

		/// <summary>
		/// メモ
		/// </summary>
		private string memo = "";

		/// <summary>
		/// タイマータイプ
		/// </summary>
		private int type = cTypeTimer;

		/// <summary>
		/// タイマー設定カウント
		/// </summary>
		private int setCount;

		/// <summary>
		/// 自動起動
		/// </summary>
		private bool autoStart;

		/// <summary>
		/// アラーム音ファイルパス
		/// </summary>
		private string soundfile;

		#endregion

		#region プロパティー
		/// <summary>
		/// タイマータイプ
		/// </summary>
		public int Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		/// <summary>
		/// タイマー名称
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		/// <summary>
		/// メモ
		/// </summary>
		public string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		/// <summary>
		/// タイマー設定カウント
		/// </summary>
		public int SetCount
		{
			get { return this.setCount; }
			set { this.setCount = value; }
		}

		/// <summary>
		/// 起動時自動起動
		/// </summary>
		public bool AutoStart
		{
			get { return this.autoStart; }
			set { this.autoStart = value; }
		}

		/// <summary>
		/// アラーム音ファイルパス
		/// </summary>
		public string Soundfile
		{
			get { return this.soundfile; }
			set { this.soundfile = value; }
		}

		#endregion

	}
}
