using System;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LockMonitorApplication;

namespace TestMethodPMS
{
	[TestClass]
    public class TestLockAlarmer
	{
		LockAlarmer pa;

		[TestInitialize]
		public void setup ()
		{
			pa = new LockAlarmer ();
		}

		[TestMethod]
		public void NoEventsCalled ()
		{
			var LockData = new Mock<ILockData> ();
			LockData.Setup (a => a.UpperLevel).Returns (3.4f);
			LockData.Setup (b => b.LowerLevel).Returns (1.5f);
			LockData.Setup (c => c.FlowRate).Returns (1.7f);
			
			var upperLevelAlarmWasCalled = false;
			var lowerLevelAlarmWasCalled = false;
			var flowRateAlarmWasCalled = false;

            pa.UpperLevelAlarm += (sender, e) => upperLevelAlarmWasCalled = true;
            pa.LowerLevelAlarm += (sender, e) => lowerLevelAlarmWasCalled = true;
            pa.FlowRateAlarm += (sender, e) => flowRateAlarmWasCalled = true;
			pa.ReadingsTest (LockData.Object);
            Assert.IsFalse(upperLevelAlarmWasCalled);
            Assert.IsFalse(lowerLevelAlarmWasCalled);
            Assert.IsFalse(flowRateAlarmWasCalled);
		}
	}
}

