using System;

namespace LockMonitorApplication
{
    public class LockData : ILockData
    {
        float upperLevel;
        float lowerLevel;
        float flowRate;

        public float UpperLevel { get { return upperLevel; } }
        public float LowerLevel { get { return lowerLevel; } }
        public float FlowRate { get { return flowRate; } }

        /// <summary>
        /// Initializes a new blank instance of the <see cref="LockData"/> class.
        /// </summary>
        public LockData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockData"/> class.
        /// </summary>
        /// <param name="LockData">Lock data.</param>
        public LockData(string LockData)
        {
            SetLockData(LockData);
        }

        public void SetLockData(string lockData)
        {
            string[] dataItems = lockData.Split(',');
            upperLevel = float.Parse(dataItems[0]);
            lowerLevel = float.Parse(dataItems[1]);
            flowRate = float.Parse(dataItems[2]);
        }
    }
}

