using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumLoginPageProject.Utilities
{
    public class WebDriverManager
    {
       private static IWebDriver driver;
       

            public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return driver;
        }



        public static void  QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}