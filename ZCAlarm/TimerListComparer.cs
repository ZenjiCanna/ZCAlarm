using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ZCAlarm
{
	public class TimerListComparer : IComparer
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TimerListComparer()
		{
		}

		/// <summary>
		/// 比較
		/// </summary>
		/// <param name="x">アイテム１</param>
		/// <param name="y">アイテム２</param>
		/// <returns></returns>
		public int Compare(object x, object y)
		{
			ListViewItem itemX = (ListViewItem)x;
			ListViewItem itemY = (ListViewItem)y;
			TimerInstance instanceX = (TimerInstance)itemX.Tag;
			TimerInstance instanceY = (TimerInstance)itemY.Tag;


			if (instanceX.State != instanceY.State) {
				return instanceY.State - instanceX.State;
			}
			if (instanceX.State == TimerState.Ready) {
				return 0;
			}

			if (instanceX.UpTime < instanceY.UpTime) {
				return -1;
			} else if (instanceX.UpTime > instanceY.UpTime) {
				return 1;
			} else {
				return 0;
			}
		}
	}
}
