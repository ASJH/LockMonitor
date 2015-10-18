using System;
namespace LockMonitorApplication
{
    public interface ILockFactory
    {
        object CreateandReturnObj(LockClassesEnumeration objectToGet);
    }
}
