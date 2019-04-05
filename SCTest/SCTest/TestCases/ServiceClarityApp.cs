using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Net;
using System.IO;
using System.Reflection;
using SCTest;
using OpenQA.Selenium.Edge;

namespace SCTest.TestCases
{
    
    [Parallelizable]
    class ServiceClarityApp : TestBase
    {
       
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void ReportPageTests(String browsername)
        {
            Setup(browsername);
            #region Login Form
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Enter username and password
            IWebElement username = driver.FindElement(By.Id("userfield"));
            username.SendKeys("test@anaeko.com");

            IWebElement password = driver.FindElement(By.Id("passfield"));
            password.SendKeys("anaeko");
            // waits until fields have input

            // submit the login button
            driver.FindElement(By.Id("submitBtn")).Click();

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("sc_complete")));

            bool MenuExist = driver.FindElement(By.Id("menu")).Displayed;
            Assert.AreEqual(true, MenuExist);
            #endregion
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            driver.FindElement(By.XPath("//*[@id='titleSection']/section[2]/div/a[1]")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("intercom-container")));
            bool IntercomShow = driver.FindElement(By.Id("intercom-container")).Displayed;
            Assert.AreEqual(true, IntercomShow);

            // clicks on report logo
            IWebElement ReportLogo = driver.FindElement(By.XPath("//*[@id='menu']/a[2]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReportLogo));
            ReportLogo.Click();

            // clicks on AWS Cost Report
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            IWebElement ReportItem = driver.FindElement(By.LinkText("AWS Cost Report"));
            ReportItem.Click();

            // clicks on a "total database cost"
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Total Database Costs")));
            IWebElement TotalDataBaseCostButton = driver.FindElement(By.LinkText("Total Database Costs"));
            TotalDataBaseCostButton.Click();

         
            ////Assert.AreNotEqual("666", purpleNumber.Text);

            // going back to the previous page
            driver.Navigate().Back();

            // checks if metrics appear. 

            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));

            driver.FindElement(By.XPath("//*[@id='menu']/a[6]")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.ClassName("data")));
            bool metricsShows = driver.FindElement(By.ClassName("data")).Displayed;
            Assert.AreEqual(true, metricsShows);
        }
    
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void CheckMetrics(String browsername)
        {
            Setup(browsername);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // Enter username and password
            IWebElement username = driver.FindElement(By.Id("userfield"));
            username.SendKeys("test@anaeko.com");

            IWebElement password = driver.FindElement(By.Id("passfield"));
            password.SendKeys("anaeko");
            // waits until fields have input

            // submit the login button
            driver.FindElement(By.Id("submitBtn")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));

            bool MenuExist = driver.FindElement(By.Id("menu")).Displayed;
            Assert.AreEqual(true, MenuExist);

            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            driver.FindElement(By.XPath("//*[@id='menu']/a[6]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            bool metricsShows = driver.FindElement(By.ClassName("data")).Displayed;
            Assert.AreEqual(true, metricsShows);


            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            bool IntercomShow = driver.FindElement(By.Id("intercom-container")).Displayed;
            Assert.AreEqual(true, IntercomShow);
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void CheckIfCommentWindowAppear(String browsername)
        {
            Setup(browsername);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Enter username and password
            IWebElement username = driver.FindElement(By.Id("userfield"));
            username.SendKeys("test@anaeko.com");

            IWebElement password = driver.FindElement(By.Id("passfield"));
            password.SendKeys("anaeko");
            // waits until fields have input

            // submit the login button
            driver.FindElement(By.Id("submitBtn")).Click();

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("menu")));

            bool MenuExist = driver.FindElement(By.Id("menu")).Displayed;
            Assert.AreEqual(true, MenuExist);

            IWebElement ReportLogo = driver.FindElement(By.XPath("//*[@id='menu']/a[3]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReportLogo));
            ReportLogo.Click();
            //clicks on AWS Report Cost
            wait.Until(ExpectedConditions.ElementExists(By.Id("listSections")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("AWS Cost Report")));
            IWebElement ReportItem = driver.FindElement(By.LinkText("AWS Cost Report"));
            ReportItem.Click();

            // clicks on make comment button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("show-comments")));
            driver.FindElement(By.Id("show-comments")).Click();

            //waits for comment window to show and checks if it's appearing
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("comments-window")));
            bool commentWindowAppear = driver.FindElement(By.Id("comments-window")).Displayed;
            Assert.AreEqual(true, commentWindowAppear);


        }
       
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void DashboardTests(String browsername)
        {
            Setup(browsername);
            #region Login form
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // Enter username and password
            IWebElement username = driver.FindElement(By.Id("userfield"));
            username.SendKeys("test@anaeko.com");

            IWebElement password = driver.FindElement(By.Id("passfield"));
            password.SendKeys("anaeko");
            // waits until fields have input

            // submit the login button
            driver.FindElement(By.Id("submitBtn")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));

            bool MenuExist = driver.FindElement(By.Id("menu")).Displayed;
            Assert.AreEqual(true, MenuExist);

            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            #endregion
            // go to dashboard site
            driver.FindElementByXPath("//*[@id='menu']/a[2]").Click();
            // selects make a new dashboard
            driver.FindElement(By.XPath("//*[@id='titleSection']/section[3]/section[2]/button")).Click();

            // waits for the dashboard to appear before typing title. 
            // timespan sets a deadline for 2 sec to show for the element. 

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-container")));

            //enter a title
            driver.FindElement(By.ClassName("error")).SendKeys("Just a test");
            // clicks save
            driver.FindElement(By.XPath("//*[@id='save']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='menu']/a[1]")));

            // clicks on Dashboard logo
            IWebElement DashboardLogo = driver.FindElement(By.XPath("//*[@id='menu']/a[1]"));
            //wait.Until(ExpectedConditions.ElementToBeClickable(DashboardLogo));
            DashboardLogo.Click();

            // clicks on the newly made dashboard

            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Just a test")));
            IWebElement justATest = driver.FindElement(By.LinkText("Just a test"));
            justATest.Click();

            // clicks delete
            driver.FindElement(By.XPath("//*[@id='titleSection']/section[3]/section[2]/div/a[2]")).Click();


            // clicks on confirm button 
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[4]/div/div[3]/button[2]")));
            IWebElement confirmButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/button[2]"));
            confirmButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav")));

            // clicks on Dashboard logo

            driver.FindElement(By.XPath("//*[@id='menu']/a[1]")).Click();

            // checks if intercom appears. 
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='titleSection']/section[2]/div/a[1]")));
            driver.FindElement(By.XPath("//*[@id='titleSection']/section[2]/div/a[1]")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("intercom-container")));
            bool IntercomShow = driver.FindElement(By.Id("intercom-container")).Displayed;
            Assert.AreEqual(true, IntercomShow);
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void CreateANewReport(String browsername)
        {
            Setup(browsername);
            #region login form
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // Enter username and password
            IWebElement username = driver.FindElement(By.Id("userfield"));
            username.SendKeys("test@anaeko.com");

            IWebElement password = driver.FindElement(By.Id("passfield"));
            password.SendKeys("anaeko");
            // waits until fields have input

            // submit the login button
            driver.FindElement(By.Id("submitBtn")).Click();
            

            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));

            #endregion

            // Select create new Report
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            driver.FindElement(By.XPath("//*[@id='titleSection']/section[3]/section[2]/a[5]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            //types title
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("error")));
            driver.FindElement(By.ClassName("error")).SendKeys("TestReport");
            

            // picks Anaeko Test
            driver.FindElement(By.Name("audience")).SendKeys(Keys.Down);
            

            // Enter save button
            driver.FindElement(By.Id("save")).Click();

            // deletes the report
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            driver.FindElement(By.XPath("//*[@id='titleEdit']/div/a[1]")).Click();


            // popup shows?
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
         
            

            // confirms delete
            driver.FindElement(By.XPath("/html/body/div[6]/div/div[3]/button[2]")).Click() ;
            

            // checks if still exist by searching
            driver.FindElement(By.Id("search_input")).SendKeys("TestReport");

            // checks if intercom shows to finish the test. 
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            bool IntercomShow = driver.FindElement(By.Id("intercom-container")).Displayed;
            Assert.AreEqual(true, IntercomShow);

        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void CheckSignUp(String browsername)
        {
            Setup(browsername);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //navigate to signup page
            driver.FindElement(By.XPath("/html/body/header/div/a[1]")).Click();
            // Inserts Bob Rickets as name
            wait.Until(ExpectedConditions.ElementExists(By.Id("contact_name")));
            IWebElement name = driver.FindElementById("contact_name");
            name.SendKeys("Bob rickets");

            //Inserts random Email 
            wait.Until(ExpectedConditions.ElementExists(By.Id("email")));
            // insert a new value every time this test has been run otherwise it would try to register with an already existing email
            driver.FindElementById("email").SendKeys("bobrickets@vf.com");

            // checks the policy box
            driver.FindElementByName("policy").Click();
            driver.FindElementById("submitBtn").Click();

            // enters an valid URL 
            wait.Until(ExpectedConditions.ElementExists(By.Id("jira")));
            driver.FindElementById("jira").SendKeys("issues.jboss.org");

            
            driver.FindElementById("submitBtn").Click();
            driver.FindElementById("submitBtn").Click();
            // enter submit button 
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='submitBtn']")));
            driver.FindElementByName("Submit").Click();
            // logs out from the application to check if login page appear
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Logout")));
            driver.FindElement(By.LinkText("Logout")).Click();

            // looks after if password input field appears on the login page
            IWebElement loginpassword = driver.FindElementByName("login.user.password");
            bool IsLoginDisplayed =  loginpassword.Displayed;
            Assert.AreEqual(true, IsLoginDisplayed);
            
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void ReportURLIsShareable(String browsername)
        {
            Setup(browsername);
            if (browsername.Equals("Firefox"))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Enter username and password
            IWebElement username = driver.FindElement(By.Id("userfield"));
            username.SendKeys("test@anaeko.com");

            IWebElement password = driver.FindElement(By.Id("passfield"));
            password.SendKeys("anaeko");
            // waits until fields have input

            // submit the login button
            driver.FindElement(By.Id("submitBtn")).Click();

            //waits for quick acces menu page has loaded 
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));

            // picks out AWS Cost Report
            driver.FindElementByLinkText("AWS Cost Report").Click();

            // waits for report page has loaded
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));

            // clicks on icon to copy URL
            driver.FindElementByClassName("copyUrl").Click();

            // waits for alert logo is visible 
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ui-pnotify-icon")));

            // open new tab and paste copied 
            if(browsername.Equals("IE"))
            {
                driver.FindElementByCssSelector("body").SendKeys(Keys.Command + "t");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Navigate().GoToUrl("https://beta.serviceclarity.com/customer/share.html?r=944yapVyK9OFaWPZy3XpmxbCI1nuJwHZdpq6zGxAs8");
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("submitBtn")));
                driver.FindElementById("password").SendKeys("anaeko");
                driver.FindElement(By.Id("submitBtn")).Click();
                
            }
            else
            {

                driver.ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Navigate().GoToUrl("https://beta.serviceclarity.com/customer/share.html?r=944yapVyK9OFaWPZy3XpmxbCI1nuJwHZdpq6zGxAs8");

            }

            // is  AWS Cost Report text present? 
            wait.Until(ExpectedConditions.ElementExists(By.Id("pageSubName")));
            IWebElement title = driver.FindElement(By.Id("pageSubName"));
            bool PageSubNameTrue = title.Displayed;
            Assert.AreEqual(true, PageSubNameTrue);
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void PublishReport(String browsername)
        {
            
            Setup(browsername);
            if (browsername.Equals("Firefox"))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            #region login
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Enter username and password
            IWebElement username = driver.FindElement(By.Id("userfield"));
            username.SendKeys("test@anaeko.com");

            IWebElement password = driver.FindElement(By.Id("passfield"));
            password.SendKeys("anaeko");
            // waits until fields have input

            // submit the login button
            driver.FindElement(By.Id("submitBtn")).Click();

            //waits for quick acces menu page has loaded 
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));
            #endregion
            // selects Runscope JIRA report
            driver.FindElementByLinkText("Runscope JIRA Report").Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("sc_complete")));

            // clicks on publish button
            driver.FindElementByXPath("//*[@id='titleEdit']/div/a[4]").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("save")));

            // clicks on publish report button
            driver.FindElementById("save").Click();

            // waits for the dialog box present an confirmation with it has been published
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ui-pnotify-icon")));
            IWebElement Dialogbox = driver.FindElement(By.ClassName("ui-pnotify-icon"));
            bool IsPresent = Dialogbox.Displayed;

            Assert.AreEqual(true, IsPresent);
        }
   
    }
}

