using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SCTest
{
    public class TestBase
    {
       public RemoteWebDriver driver;
       

        
        public virtual void Setup(String browsername)
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            if (browsername.Equals("Chrome"))
            {
                capability.SetCapability("os", "Windows");
                capability.SetCapability("os_version", "10");
                capability.SetCapability("browser", "Chrome");
                capability.SetCapability("browser_version", "62.0");
                capability.SetCapability("browserstack.local", "false");
                capability.SetCapability("resolution", "1024x768");
                capability.SetCapability("build", "version1");
                capability.SetCapability("project", "ServiceClarityApp");
                capability.SetCapability("browserstack.user", "emmafoster6");
                capability.SetCapability("browserstack.key", "QD3qS4ERAauxJHf1DPqb");
                capability.SetCapability("browserstack.networkLogs", "true");
                capability.SetCapability("browserstack.debug", "true");
            }
            else if (browsername.Equals("IE"))
            {
                capability.SetCapability("os", "Windows");
                capability.SetCapability("os_version", "10");
                capability.SetCapability("browser", "IE");
                capability.SetCapability("browser_version", "11.0");
                capability.SetCapability("browserstack.local", "false");
                capability.SetCapability("resolution", "1024x768");
                capability.SetCapability("build", "version1");
                capability.SetCapability("project", "ServiceClarityApp");
                capability.SetCapability("browserstack.user", "emmafoster6");
                capability.SetCapability("browserstack.key", "QD3qS4ERAauxJHf1DPqb");
                capability.SetCapability("browserstack.networkLogs", "true");
                capability.SetCapability("browserstack.debug", "true");
            }
            //else if (browsername.Equals("Edge"))
            //{
            //    capability.SetCapability("os", "Windows");
            //    capability.SetCapability("os_version", "10");
            //    capability.SetCapability("browser", "Edge");
            //    capability.SetCapability("browser_version", "18.0");
            //    capability.SetCapability("browserstack.local", "false");
            //    capability.SetCapability("browserstack.selenium_version", "3.10.0");
            //    capability.SetCapability("build", "version1");
            //    capability.SetCapability("project", "ServiceClarityApp");
            //    capability.SetCapability("browserstack.user", "emmafoster6");
            //    capability.SetCapability("browserstack.key", "QD3qS4ERAauxJHf1DPqb");
            //    capability.SetCapability("browserstack.networkLogs", "true");
            //    capability.SetCapability("browserstack.debug", "true");
            //}
            else if(browsername.Equals("Firefox"))
            {
                capability.SetCapability("os", "Windows");
                capability.SetCapability("os_version", "10");
                capability.SetCapability("browser", "Firefox");
                capability.SetCapability("browser_version", "65.0");
                capability.SetCapability("browserstack.local", "false");
                capability.SetCapability("browserstack.selenium_version", "3.10.0");
                capability.SetCapability("build", "version1");
                capability.SetCapability("project", "ServiceClarityApp");
                capability.SetCapability("browserstack.user", "emmafoster6");
                capability.SetCapability("browserstack.key", "QD3qS4ERAauxJHf1DPqb");
                capability.SetCapability("browserstack.networkLogs", "true");
                capability.SetCapability("browserstack.debug", "true");
            }

            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            driver.Url = "https://beta.serviceclarity.com/";
        }

        [TearDown]
        public void Close()
        {
            string sessionid = driver.SessionId.ToString();
            string reasonError = "Could not locate element";
            string reasonPass = "Succes";

            if(TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                string reqString = "{\"status\":\"error\", \"reason\":\"" + reasonError + "\"}";
                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                var url = string.Format("https://www.browserstack.com/automate/sessions/" + sessionid + ".json");
                Uri myUri = new Uri(url);

                WebRequest myWebRequest = HttpWebRequest.Create(myUri);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
                myWebRequest.ContentType = "application/json";
                myWebRequest.Method = "PUT";
                myWebRequest.ContentLength = requestData.Length;
                using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);


                NetworkCredential myNetworkCredential = new NetworkCredential("emmafoster6", "QD3qS4ERAauxJHf1DPqb");
                CredentialCache myCredentialCache = new CredentialCache();

                myCredentialCache.Add(myUri, "Basic", myNetworkCredential);
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Credentials = myCredentialCache;

                WebResponse myWebResponse = myWebRequest.GetResponse();
                Stream responseStream = myWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

                string pageContent = myStreamReader.ReadToEnd();
                Console.Write(pageContent);
                responseStream.Close();

                myWebResponse.Close();
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Passed))
            {
                string reqString = "{\"status\":\"passed\", \"reason\":\"" + reasonPass + "\"}";
                //string reqString = "{\"status\":\"error\", \"reason\":\"full of errors\"}";
                byte[] requestData = Encoding.UTF8.GetBytes(reqString);
                var url = string.Format("https://www.browserstack.com/automate/sessions/" + sessionid + ".json");
                Uri myUri = new Uri(url);

                WebRequest myWebRequest = HttpWebRequest.Create(myUri);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
                myWebRequest.ContentType = "application/json";
                myWebRequest.Method = "PUT";
                myWebRequest.ContentLength = requestData.Length;
                using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);


                NetworkCredential myNetworkCredential = new NetworkCredential("emmafoster6", "QD3qS4ERAauxJHf1DPqb");
                CredentialCache myCredentialCache = new CredentialCache();

                myCredentialCache.Add(myUri, "Basic", myNetworkCredential);
                myHttpWebRequest.PreAuthenticate = true;
                myHttpWebRequest.Credentials = myCredentialCache;

                WebResponse myWebResponse = myWebRequest.GetResponse();
                Stream responseStream = myWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

                string pageContent = myStreamReader.ReadToEnd();
                Console.Write(pageContent);
                responseStream.Close();

                myWebResponse.Close();
            }
           

            driver.Quit();
        }
        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = { "Chrome", "IE", "Firefox" };
            foreach (var b in browsers)
            {
                yield return b;
            }
        }
    }
}
