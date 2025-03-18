using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using AventStack.ExtentReports.Reporter;
using System;

namespace BookStoreProject.Utilities
{

   


public class WebDriverListener
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        

        public WebDriverListener(ExtentReports extent)
        {
            _extent = extent;
           
        }

        public void setTest(ExtentTest test)
        {
            _test = test;
        }

        public static EventFiringWebDriver AttachListener(IWebDriver driver)
        {
            EventFiringWebDriver eventDriver = new EventFiringWebDriver(driver);

            eventDriver.ElementClicking += (sender, e) =>
            {
                Console.WriteLine($"Element {e.Element} is being clicked");
                 _test = _extent.CreateTest("Click Event");
                    _test.Info($"Element {e.Element} is being clicked");

                
              



                    _test = _extent.CreateTest("Click Event");
                _test.Info($"Element {e.Element} is being clicked");
            };

            eventDriver.ElementClicked += (sender, e) =>
            {
                Console.WriteLine($"Element {e.Element} has been clicked");
                _test = _extent.CreateTest("Click Event");
                _test.Info($"Element {e.Element} has been clicked");
            };

            eventDriver.ExceptionThrown += (sender, e) =>
            {
                Console.WriteLine($"Exception {e.ThrownException} has been thrown");
                _test = _extent.CreateTest("Exception Event");
                _test.Info($"Exception {e.ThrownException} has been thrown");
            };

            return eventDriver;
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
