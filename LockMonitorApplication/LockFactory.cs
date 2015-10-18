using System;

namespace LockMonitorApplication
{
	class LockFactory : ILockFactory
	{
		public Object CreateandReturnObj(LockClassesEnumeration objectToGet)
		{
			object createdObject = null;
			switch (objectToGet)
			{
			case LockClassesEnumeration.LockAlarmer:
				LockAlarmer alarmer = new LockAlarmer();
				createdObject = alarmer;
				break;
			case LockClassesEnumeration.LockDataReader:
				LockDataReader dataReader = new LockDataReader();
				createdObject = dataReader;
				break;
			case LockClassesEnumeration.LockData:
				LockData lockData = new LockData();
				createdObject = lockData;
				break;
			default:
				throw new ArgumentException("Invalid parameter passed");
			}
			return createdObject;
		}
	}
}