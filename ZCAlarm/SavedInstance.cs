using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZCAlarm
{
	public class SavedInstance
	{

		private List<TimerInstance> instances;

		public List<TimerInstance> Instances
		{
			get { return this.instances; }
			set { this.instances = value; }
		}

		public SavedInstance()
		{
			this.instances = new List<TimerInstance>();
		}



	}
}
