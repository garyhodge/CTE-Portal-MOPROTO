using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

using Tools = Appius.Core.Testing;
using TestServices = Appius.MOCompute.Services.Services;

namespace Appius.MOCompute.UnitTests.UITests
{
    /// <summary>
    /// Summary description for WebStatusTests
    /// </summary>
    [TestFixture]
    public class PagerLoadAndRenderTests
    {
        private TestContext _TestContext;
        private IWebDriver _WebDriver;
        private double _Timeout;

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
        /// Status tests constructor and config
        /// </summary>
        public PagerLoadAndRenderTests()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Init()
        {
            _WebDriver = new ChromeDriver();
            _Timeout = 5;
        }

        /// <summary>
        /// Tests the loading of the test status page
        /// </summary>
        [Test, Tools.TestName("MO Compute Loads In A Timely Fashion")]
        public void MOComputeLoadsInATimelyFashion()
        {
            try
            {
                _WebDriver.Navigate().GoToUrl("http://proto.ctemo.appius.co.uk");

                IWait<IWebDriver> wait = new WebDriverWait(_WebDriver, TimeSpan.FromSeconds(_Timeout));
                var element = wait.Until(ExpectedConditions.TitleContains("CTE MO - Prototype"));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("The start page did not load after " + _Timeout + " seconds");
            }
        }

        /// <summary>
        /// Tests the loading of the loation webservices
        /// </summary>
        [Test, Tools.TestName("Location Service Loads In A Timely Fashion")]
        public void LocationServiceLoadsInATimelyFashion()
        {
            try
            {
                _WebDriver.Navigate().GoToUrl("http://proto.ctemo.appius.co.uk/Services/locationservice.svc");

                IWait<IWebDriver> wait = new WebDriverWait(_WebDriver, TimeSpan.FromSeconds(_Timeout));
                var element = wait.Until(ExpectedConditions.TitleContains("LocationService"));

                Assert.Pass("Location Service Successully Loaded");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("The loaction services did not load after " + _Timeout + " seconds");
            }
        }

        /// <summary>
        /// Tests the loading of the compute webservices page
        /// </summary>
        [Test, Tools.TestName("Compute Service Loads In A Timely Fashion")]
        public void ComputeServiceLoadsInATimelyFashion()
        {
            try
            {
                _WebDriver.Navigate().GoToUrl("http://proto.ctemo.appius.co.uk/Services/computeservice.svc");


                IWait<IWebDriver> wait = new WebDriverWait(_WebDriver, TimeSpan.FromSeconds(_Timeout));
                var element = wait.Until(ExpectedConditions.TitleContains("ComputeService"));

                Assert.Pass("Compute Service Successully Loaded");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("The compute services did not load after " + _Timeout + " seconds");
            }
        }

        /// <summary>
        /// Clean up and realease the browser
        /// </summary>
        [TearDown]
        public void EndTest()
        {
            _WebDriver.Close();
            _WebDriver.Quit();
        }
    }
}
