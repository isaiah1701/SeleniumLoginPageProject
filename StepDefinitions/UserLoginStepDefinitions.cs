using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumLoginPageProject.Pages;
using SeleniumLoginPageProject.Utilities;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.Events;
using BookStoreProject.Utilities;
using OpenQA.Selenium.Support.UI;



namespace BookStoreProject.StepDefinitions
{
    [Binding]
    public class UserLoginStepDefinitions
    {
        private IWebDriver driver;
        protected LoginPage loginPage;
        protected ExtentHelper extentHelper;

        public UserLoginStepDefinitions()
        {
            driver = WebDriverManager.GetDriver();
            extentHelper = new ExtentHelper(driver);
            loginPage = new LoginPage(driver);
           
        }

        [BeforeScenario]
        public void Setup()
        {
            extentHelper.InitializeReport();
            extentHelper.CreateTest("User Login Test");

        }


        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {

            

            loginPage.NavigateToLoginPage();
            Console.WriteLine("User is on the login page");
            extentHelper.LogInfo("User is on the login page");
            
        }

        [When(@"they enter a valid username and password")]
        public void WhenTheyEnterAValidUsernameAndPassword()
        {
            loginPage.Login("ValidUser1", "Valid@123");
            Console.WriteLine("User enters valid username and password");
          extentHelper.LogInfo("User enters valid username and password");
        }

        [Then(@"they should be redirected to the dashboard")]
        public void ThenTheyShouldBeRedirectedToTheDashboard()
        {
            // Implement the logic to verify redirection to the dashboard
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool isDashboardPage = wait.Until(driver => driver.Url.Contains("/profile")); // Wait until the URL contains /profile
            if (!isDashboardPage)
            {
                throw new Exception("User is not redirected to the dashboard");
            }
            Console.WriteLine("User is redirected to the dashboard");
            extentHelper.LogPass("User is redirected to the dashboard");

            // Assert that the user is redirected to the dashboard
            Assert.Pass("User is successfully redirected to the dashboard");
        }
        [AfterScenario]
        public void TearDown()
        {
            extentHelper.FlushReport();
          driver.Quit();

        }
    }
}

