using System;
namespace LockMonitorApplication
{
    interface ILockDataReader
    {
        void Connect(string fileName);
        string getData();
    }
}
