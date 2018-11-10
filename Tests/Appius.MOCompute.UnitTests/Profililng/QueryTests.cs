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
    /// Summary description for query type tests
    /// </summary>
    [TestFixture]
    public class QueryTests
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
        public QueryTests()
        {
        }

        /// <summary>
        ///
        /// </summary>
        [Test, Tools.TestName("Location Query Executes In A Timely Fashion")]
        public void LocationQueryExecutesInATimelyFashion()
        {
        }

        /// <summary>
        ///
        /// </summary>
        [Test, Tools.TestName("Given A Known Example The Compute Returns The Correct Results")]
        public void GivenAKnownExampleTheComputeReturnsTheCorrectResults()
        {
        }
    }
}
