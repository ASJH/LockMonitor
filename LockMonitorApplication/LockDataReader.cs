using System;
using System.IO;

namespace LockMonitorApplication
{
	public class LockDataReader : LockMonitorApplication.ILockDataReader
	{
		StreamReader dataFile;
        
        /// <summary>
        /// Initializes a new unconnected instance.
        /// </summary>
        public LockDataReader()
        {
        }

		public LockDataReader (string fileName)
		{
			// Open the file
			dataFile = new StreamReader (fileName);
			// Ignore the headings
			dataFile.ReadLine ();
		}

        public void Connect(string fileName)
        {
            // Open the file
            dataFile = new StreamReader(fileName);
            // Discard the headings
            dataFile.ReadLine();
        }

		public string getData ()
		{
			return dataFile.ReadLine ();
		}
	}
}

