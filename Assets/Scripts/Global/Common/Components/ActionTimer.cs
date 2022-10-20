using System;
using UnityEngine;

namespace RougeLike
{
	internal readonly struct ActionTimer
	{
		private readonly float r_timeToAction;
		private readonly Action r_action;

		public ActionTimer(Action action, float seconds = 1f)
		{
			r_timeToAction = Time.time + seconds;
			r_action = action;
		}

		public bool Check()
		{
			if(Time.time < r_timeToAction) return false;

			r_action?.Invoke();
			return true;
		}
	}
}