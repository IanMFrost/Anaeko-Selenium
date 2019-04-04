using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SCTest.TestCases
{
    class ServiceClarityWeb 
    {
        public RemoteWebDriver driver;
        [SetUp]
        public void Setup()
        {

            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("build", "version1");
            capability.SetCapability("project", "newintropage");
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("browser", "Chrome");
            capability.SetCapability("browser_version", "62.0");
            capability.SetCapability("resolution", "1024x768");
            capability.SetCapability("browserstack.user", "emmafoster6");
            capability.SetCapability("browserstack.key", "QD3qS4ERAauxJHf1DPqb");
            capability.SetCapability("browserstack.networkLogs", "true");
            capability.SetCapability("browserstack.debug", "true");


            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            driver.Url = "https://content.serviceclarity.com/blog";
        }

        [Test]
        public void CheckIfArticlesExist()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("post-listing")));
            bool articleList = driver.FindElement(By.ClassName("post-listing")).Displayed;
            Assert.AreEqual(true, articleList);
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }


    }
}
