using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumLoginPageProject.Utilities
{
    public class WebDriverManager
    {
       private stattic IWebDriver Driver;
       

            public static IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                Driver = new ChromeDriver();
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return Driver;
        }



        public static void  QuitDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}