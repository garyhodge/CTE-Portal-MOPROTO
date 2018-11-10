using System;
using System.Text;
using System.Collections.Generic;

using NUnit;
using NUnit.Framework;

using Tools = Appius.Core.Testing;
using TestServices = Appius.MOCompute.Services.Services;

namespace Appius.MOCompute.UnitTests.Service_Tests
{
    /// <summary>
    /// Summary description for APITests
    /// </summary>
    [TestFixture]
    public class APITests
    {
        private TestContext _TestContext;

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

        /// <summary>
        /// servie tests constructor and config
        /// </summary>
        public APITests()
        {
        }

        /// <summary>
        /// Tests heartbeat of all services
        /// </summary>
        [Test, Tools.TestName("Test name")]
        public void ServiceStatus()
        {
            var expectedOK = "200 OK";

            var locationService = new TestServices.LocationService();
            var response = locationService.Noop();
            Assert.AreEqual(response, expectedOK, "Location Service Status is " + response);

            var computeService = new TestServices.ComputeService();
            response = computeService.Noop();
            Assert.AreEqual(response, expectedOK, "Compute Service Status is " + response);
        }
    }
}
