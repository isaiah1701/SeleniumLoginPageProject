using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookStoreProject.Utilities
{
    public class ScreenshotHelper
    {
        private readonly IWebDriver _driver;

        public ScreenshotHelper(IWebDriver driver)
        {
            _driver = driver;
        }



        public void TakeScreenshot(string filename)
        {
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            string screenshotDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }

            string filePath = Path.Combine(screenshotDirectory, $"{filename}.png");
            screenshot.SaveAsFile(filePath);
        }
    }
}
