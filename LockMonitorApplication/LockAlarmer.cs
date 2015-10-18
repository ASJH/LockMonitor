using System;

namespace LockMonitorApplication
{
	public class LockAlarmer : ILockAlarmer
	{
		public event EventHandler UpperLevelAlarm;
		public event EventHandler LowerLevelAlarm;
		public event EventHandler FlowRateAlarm;

		public AlarmTester UpperLevelTester = new AlarmTester ("Upper Level", DefaultSettings.LOW_UPPER_LEVEL, DefaultSettings.HIGH_UPPER_LEVEL);
        public AlarmTester LowerLevelTester = new AlarmTester("Lower Level", DefaultSettings.LOW_LOWER_LEVEL, DefaultSettings.HIGH_LOWER_LEVEL);
        public AlarmTester FlowRateTester = new AlarmTester("Flow Rate", DefaultSettings.LOW_FLOW_RATE, DefaultSettings.HIGH_FLOW_RATE);

		/// <summary>
		/// Readings test.
		/// </summary>
		/// <param name="readings">Readings.</param>
		public void ReadingsTest(ILockData readings){
			if (UpperLevelTester.ValueOutsideLimits (readings.UpperLevel)) {
				if (UpperLevelAlarm != null) UpperLevelAlarm (this, null);
			}
			if (LowerLevelTester.ValueOutsideLimits (readings.LowerLevel)) {
				if (LowerLevelAlarm != null) LowerLevelAlarm (this, null);
			}
			if (FlowRateTester.ValueOutsideLimits (readings.FlowRate)) {
				if (FlowRateAlarm != null) FlowRateAlarm (this, null);
			}
		}
	}
}

