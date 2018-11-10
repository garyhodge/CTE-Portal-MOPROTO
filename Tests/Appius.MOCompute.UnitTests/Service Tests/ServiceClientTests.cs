using System;
using System.Text;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;

using Tools = Appius.Core.Testing;
using ServiceWorkers = Appius.MOCompute.Services.Client.Workers;

namespace Appius.MOCompute.UnitTests.Service_Tests
{
    /// <summary>
    /// Summary description for APITests
    /// </summary>
    [TestFixture]
    public class ServiceClientTests
    {
        private TestContext _TestContext;
        private ServiceWorkers.Compute _Compute;
        private ServiceWorkers.Location _Location;

        public TestContext TestContext
        {
            get
            {
                return _TestContext;
            }
            set
            {
                _TestContext = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// servie tests constructor and config
        /// </summary>
        public ServiceClientTests()
        {
            _Compute = new ServiceWorkers.Compute();
            _Location = new ServiceWorkers.Location();
        }

        /// <summary>
        /// Tests heartbeat of all services
        /// </summary>
        [Test, Tools.TestName("Test name")]
        public void ServiceClientStatus()
        {
            var expectedOK = "200 OK";

            var response = _Compute.Noop();
            Assert.AreEqual(response, expectedOK);

            response = _Location.Noop();
            Assert.AreEqual(response, expectedOK);
        }
    }
}
