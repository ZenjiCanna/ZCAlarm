using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCAlarm
{
	public class SavedDefs
	{
		private List<TimerDef> defs;

		public List<TimerDef> Defs
		{
			get { return this.defs; }
			set { this.defs = value; }
		}

		public SavedDefs()
		{
			this.defs = new List<TimerDef>();
		}
	}
}
