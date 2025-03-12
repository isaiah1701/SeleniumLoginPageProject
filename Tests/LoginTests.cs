using NUnit.Framework;
using NLog;
using OpenQA.Selenium;
using SeleniumLoginPageProject.Pages;
using SeleniumLoginPageProject.Utilities;






namespace SeleniumLoginPageProject.Tests
{
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
       



        


        [SetUp]
        public void Setup()
        {



          
           

            Console.WriteLine($"{Directory.GetCurrentDirectory()}");
            LogManager.Setup().LoadConfigurationFromFile("C:/Users/2391446/C#Training/SeleniumLoginPageProject/nlog.config");
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
            logger.Info("Navigated to login page");


        }

        [Test]
        public void ValidLoginTest()
            
        {
            logger.Info("Starting logger test");
            homePage = loginPage.Login("username", "password");
           
        }





        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
            WebDriverManager.QuitDriver();
            logger.Info("Browser closed");
        }


        
    }
}