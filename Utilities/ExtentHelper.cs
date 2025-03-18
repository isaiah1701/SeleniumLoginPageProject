using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;   
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace BookStoreProject.Utilities
{
    public class ExtentHelper
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        private readonly IWebDriver _driver;

        public ExtentHelper(IWebDriver driver)
        {
            _driver = driver;
             
        }

        public  void InitializeReport()
        {
            ExtentSparkReporter htmlReporter = new ExtentSparkReporter("C:\\Users\\2391446\\C#Training\\BookStoreProject\\Reports\\extent.html");
            htmlReporter.Config.DocumentTitle = "Automation Report";
            htmlReporter.Config.ReportName = "Selenium C# test results";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        public  void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        public  void LogInfo(string message)
        {
            test.Log(Status.Info, message);
        }

        public  void LogPass(string message)
        {
            test.Log(Status.Pass, message);
        }

        public  void LogFail(string message, IWebDriver driver)
        {
            test.Log(Status.Fail, message);
           
       
        }

        public  void LogWarning(string message)
        {
            test.Log(Status.Warning, message);
        }

        public  void FlushReport()
        {
            extent.Flush();
        }

        
    }
}
