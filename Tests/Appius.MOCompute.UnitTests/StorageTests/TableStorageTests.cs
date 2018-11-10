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
    public class TableStorageTests
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
        public TableStorageTests()
        {
        }

        /// <summary>
        /// Tests connection of table store
        /// </summary>
        [Test, Tools.TestName("Test name")]
        public void TestConnection()
        {
        }

        /// <summary>
        /// Tests that we are able to write a table and then delete it
        /// </summary>
        [Test, Tools.TestName("Test name")]
        public void TestReadAndWrite()
        {
        }
    }
}
