using System;

namespace LockMonitorApplication
{		/*
		float UpperLevel{ get; }
		float LowerLevel{  get;  }
		float FLOW_RATE{ get; }
		*/
	public struct DefaultSettings
	{
		public const float HIGH_UPPER_LEVEL = 4.5f;
		public const float LOW_UPPER_LEVEL = -0.1f;
		public const float HIGH_LOWER_LEVEL = 2.5f;
		public const float LOW_LOWER_LEVEL = -0.1f;
		public const float HIGH_FLOW_RATE = 2f;
		public const float LOW_FLOW_RATE = -0.1f;
	}
}

