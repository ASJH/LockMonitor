using Microsoft.VisualStudio.TestTools.UnitTesting;
using LockMonitorApplication;

namespace LockMonitorTest
{
	[TestClass]
	public class TestLockData
	{
        const string dataLine1 = "3.2,1.4,1.5";
        const string dataLine2 = "3.4,1.5,1.7";

		[TestMethod]
		public void LockDataCreatedCorrectly()
		{
			var pd = new LockData (dataLine1);
            LockDataTestOK1(pd);
			var pd2 = new LockData (dataLine2);
            LockDataTestOK2(pd2);
		}

        [TestMethod]
        public void LockDataSetCorrectly()
        {
            var pd = new LockData();
            pd.SetLockData(dataLine1);
            LockDataTestOK1(pd);

            var pd2 = new LockData();
            pd2.SetLockData(dataLine2);
            LockDataTestOK2(pd2);
        }

        void LockDataTestOK1(LockData pd)
        {
            Assert.AreEqual(3.2f, pd.UpperLevel);
            Assert.AreEqual(1.4f, pd.LowerLevel);
            Assert.AreEqual(1.5f, pd.FlowRate);
        }

        void LockDataTestOK2(LockData pd)
        {
            Assert.AreEqual(3.4f, pd.UpperLevel);
            Assert.AreEqual(1.5f, pd.LowerLevel);
            Assert.AreEqual(1.7f, pd.FlowRate);
        }
	}
}

