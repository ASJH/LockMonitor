using System;
namespace LockMonitorApplication
{
    public interface ILockData
    {
        float FlowRate { get; }
        float LowerLevel { get; }
        float UpperLevel { get; }
        void SetLockData(string lockData);
    }
}
