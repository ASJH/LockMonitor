using System;
using System.Timers;

namespace LockMonitorApplication
{
	public class Runner
	{
		readonly Timer readTimer;
		readonly LockDataReader levelReader;

		const string DATA_FILE = "lockData.csv";
		LockData lockData;

		void updateUI (object source, ElapsedEventArgs e)
		{
			lockData = new LockData (levelReader.getData ());
			Console.Clear();
			Console.WriteLine("Upper level {0}\nLower Level {1}\nFlow Rate {2}", lockData.UpperLevel,lockData.LowerLevel,lockData.FlowRate);
		}

		public Runner ()
		{
			levelReader = new LockDataReader (DATA_FILE);
			readTimer = new Timer ();
			readTimer.Interval = 2000;
			readTimer.Elapsed += updateUI;
		}

		public void run(){
			readTimer.Start ();
			// Wait for a user to press enter
			Console.ReadLine ();
		}
	}
}

