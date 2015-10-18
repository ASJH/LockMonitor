using System;
namespace LockMonitorApplication
{
    interface IAlarmTester
    {
        string AlarmName { get; }
        float LowerLimit { get; set; }
        float UpperLimit { get; set; }
        bool ValueOutsideLimits(float value);
    }
}
