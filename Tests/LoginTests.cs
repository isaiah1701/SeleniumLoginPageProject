using NUnit.Framework;
using NLog;
using OpenQA.Selenium;
using SeleniumLoginPageProject.Pages;
using SeleniumLoginPageProject.Utilities;
using AventStack.ExtentReports;
using System;
using AventStack.ExtentReports.Reporter;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using BookStoreProject.Utilities;
using System.Diagnostics.Tracing;
using OpenQA.Selenium.Support.Events;
using BookStoreProject.Pages.SeleniumLoginPageProject.Pages;








namespace SeleniumLoginPageProject.Tests
{
    public class LoginTests
    {
        private IWebDriver driver;
        protected LoginPage loginPage;
        private HomePage homePage;
        private RegisterPage registerPage;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected static ExtentReports extent;
        protected  ExtentTest test;
        protected EventFiringWebDriver eventDriver; 
        private WebDriverListener listener;

        protected ScreenshotHelper screenshot;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("OneTimeSetUp");
            ExtentSparkReporter htmlReporter = new ExtentSparkReporter("C:\\Users\\2391446\\C#Training\\BookStoreProject\\Reports\\extent.html");
            htmlReporter.Config.DocumentTitle = "Automation Report";
            htmlReporter.Config.ReportName = "Selenium C# test results";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine($"{Directory.GetCurrentDirectory()}");
            LogManager.Setup().LoadConfigurationFromFile("C:\\Users\\2391446\\C#Training\\BookStoreProject\\Utilities\\nlog.config");
            if (LogManager.Configuration == null)
            {
                Console.WriteLine("LogManager.Configuration is null");
            }
            else
            {
                Console.WriteLine("LogManager.Configuration is not null");
            }
            driver = WebDriverManager.GetDriver();
            logger.Info("Browser launched");
            driver.Url = "https://demoqa.com/login";
            loginPage = new LoginPage(driver);
            registerPage = new RegisterPage(driver); 
            logger.Info("Navigated to login page");
            screenshot = new ScreenshotHelper(driver);
           listener = new WebDriverListener(extent);
            eventDriver = WebDriverListener.AttachListener(driver); // Changed type to EventFiringWebDriver
            

        }

        [Test]
        public void LoginPageLoadedTest()
        {
            


            test = extent.CreateTest("Login Page Loaded Test");
            listener.setTest(test);
            logger.Info("Starting logger test");
            Assert.That(loginPage.IsCurrentPage(), Is.True, "Login page did not load");
            test.Info("Checking if login page is loaded");

            test.Pass("Login page loaded successfully");

            screenshot.TakeScreenshot("LoginPageLoadedTest");

            eventDriver.FindElement(By.Id("userName-label")).Click(); // No change needed here
        }

        [Test]
        public void ValidLoginTest()
        {



            test = extent.CreateTest("Login Test");
            logger.Info("Starting logger test");

           

            loginPage.Login("ValidUser1", "Valid@123");
            test.Info("Logging in with valid credentials");
            test.Pass("Login successful");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
        }

        [TearDown]
        public void TearDown()
        {
            eventDriver.Quit();
            eventDriver.Dispose();
            driver.Quit();
            driver.Dispose();
            WebDriverManager.QuitDriver();
            logger.Info("Browser closed");
        }
    }
   
}