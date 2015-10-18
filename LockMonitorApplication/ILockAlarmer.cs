using System;
namespace LockMonitorApplication
{
    interface ILockAlarmer
    {
        event EventHandler FlowRateAlarm;
        event EventHandler LowerLevelAlarm;
        void ReadingsTest(ILockData readings);
        event EventHandler UpperLevelAlarm;
    }
}
