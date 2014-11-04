using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecurityGuard.Data.IntegrationTest
{
    [TestClass]
    public class ConfigRepositoryTest
    {
        private string _connectionString = "Server=localhost:27017;Database=MongoIdentity"; 
        private bool _runTest = false;

        [TestInitialize]
        public void TestInitialize()
        {
            if (!_runTest)
            {
                Assert.Inconclusive("Integration test.  Omitting.");
            }
        }



        [TestCategory("Integration"), TestMethod]
        public void GetAll_GetHashCode_ReturnsXXXXXX()
        {
            var repo = new ConfigRepostiory(_connectionString);

            var readings = repo.GetHashCode();
            Assert.AreEqual("XXXXXXX", readings);

        }

    }
}
