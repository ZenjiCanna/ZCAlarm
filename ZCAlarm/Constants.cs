using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCAlarm
{
	/// <summary>
	/// 定数定義クラス
	/// </summary>
	internal class Constants
	{

		/// <summary>
		/// カウント値の単位定数
		/// </summary>
		public static class CountTani
		{
			public const int Sec = 1;
			public const int Min = 2;
			public const int Hour = 3;
		}

		/// <summary>
		/// タイマータイプ
		/// </summary>
		public static class TimerType
		{
			public const int Timer = 1;					// カウントダウンタイマ型
			public const int Alarm = 2;					// アラーム時刻型
		}
	}
}
