using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCAlarm
{
	/// <summary>
	/// タイマー状態定数
	/// </summary>
	internal class TimerState
	{
		public const int Ready = 1;				// 起動前(未使用)
		public const int Run = 2;				// 動作中
		public const int Pause = 3;				// 一次停止中
		public const int Timeup = 4;			// カウントアップ
	}

	/// <summary>
	/// タイマーインスタンス
	/// </summary>
	public class TimerInstance
	{

		/// <summary>
		/// タイマータイプ
		/// </summary>
		public int Type { get; set; }

		/// <summary>
		/// タイマー状態
		/// </summary>
		public int State { get; set; }

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

		/// <summary>
		/// 設定カウント(タイマ型の時：タイマー秒数、アラーム型の時：0:00からの分数) 
		/// </summary>
		public int SetCount { get; set; }

		/// <summary>
		/// カウントアップ日時(起動後有効)
		/// </summary>
		private DateTime upTime;

		/// <summary>
		/// カウントアップ日時
		/// </summary>
		public DateTime UpTime
		{
			get
			{
				if (this.State == TimerState.Ready || this.State == TimerState.Pause) {
					return this.CalUpTime();
				} else {
					return this.upTime;
				}
			}
			set
			{
				this.upTime = value;
			}
		}

		/// <summary>
		/// タイムアップ時刻を求める
		/// </summary>
		/// <returns></returns>
		private DateTime CalUpTime()
		{
			if (this.Type == TimerDef.cTypeTimer) {
				// カウンター型の時は今に設定秒数を加算した時刻
				return DateTime.Now.AddSeconds(this.SetCount);				
			} else {
				// アラーム型の時は一旦今日の設定時刻にする
				DateTime settime = DateTime.Now.Date.AddMinutes(this.SetCount);
				if (settime < DateTime.Now) {
					return settime.AddDays(1);		// すでに過ぎていたら明日の時刻
				} else {
					return settime;					// まだその時刻が来ていなかったら本日の時刻
				}
			}
		}

		/// <summary>
		/// カウントアップまでの残り時間(秒)
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public int ToSeconds
		{
			get
			{
				int resultSec = 0;
				if (this.State == TimerState.Ready || this.State == TimerState.Pause) {
					if (this.Type == TimerDef.cTypeTimer) {
						resultSec = this.SetCount;
					} else {
						TimeSpan ts = this.CalUpTime() - DateTime.Now;
						resultSec = (int)ts.TotalSeconds;
					}
				} else {
					TimeSpan ts = this.upTime - DateTime.Now;
					resultSec = (int)ts.TotalSeconds;
				}
				if (resultSec < 0) {
					resultSec = 0;
				}
				return resultSec;
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="def">定義</param>
		public TimerInstance(TimerDef def)
		{
			this.Type = def.Type;
			this.SetCount = def.SetCount;
			this.Title = def.Name;
			this.Memo = def.Memo;
			this.Soundfile = def.Soundfile;
			this.State = TimerState.Ready;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TimerInstance()
		{
			this.Type = TimerDef.cTypeTimer;
			this.SetCount = 1;
			this.Title = "Name";
			this.Memo = "";
			this.Soundfile = "";
			this.State = TimerState.Ready;
		}

		/// <summary>
		/// タイマ起動
		/// </summary>
		public void Start()
		{
			this.upTime = this.CalUpTime();
			this.State = TimerState.Run;
		}

		/// <summary>
		/// タイマー一時停止
		/// </summary>
		public void Pause()
		{
			if (this.Type == TimerDef.cTypeTimer) {
				if (this.State == TimerState.Run) {
					this.SetCount = this.ToSeconds;
					this.State = TimerState.Pause;
				}
			}
		}
	}
}
