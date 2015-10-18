using Microsoft.VisualStudio.TestTools.UnitTesting;
using LockMonitorApplication;

namespace LockMonitorTest
{
	[TestClass]
	public class TestLockDataReader
	{
        const string dataLine1 = "3.2,1.4,1.5";
        const string dataLine2 = "3.1,1.5,1.4";
		
		[TestMethod]
		public void GoodCreation ()
		{
			var pdr = new LockDataReader (@"..\..\..\TestData.csv");
			Assert.AreEqual (dataLine1, pdr.getData ());
			Assert.AreEqual (dataLine2, pdr.getData ());
		}

		[TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
		public void BadFileName ()
		{
            new LockDataReader(@"..\..\..\NonExistant.csv");
		}

        /// <summary>
        /// Test unconnected creation then connecting
        /// </summary>
        [TestMethod]
        public void GoodUnconnectedCreation()
        {
            var pdr = new LockDataReader();
            pdr.Connect(@"..\..\..\TestData.csv");
            Assert.AreEqual(dataLine1, pdr.getData());
            Assert.AreEqual(dataLine2, pdr.getData());
        }

        /// <summary>
        /// Test unconnected creation then connecting to nonexistant file
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void BadUnconnectedFileName()
        {
            var pdr = new LockDataReader();
            pdr.Connect(@"..\..\..\NonExistant.csv");
        }
	}
}