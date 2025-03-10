using NUnit.Framework;
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
        [SetUp]
        public void Setup()
        {
            driver = WebDriverManager.GetDriver();
            driver.Url = "https://demoqa.com/login";
            loginPage = new LoginPage(driver);
        }
        [Test]
        public void ValidLoginTest()
        {
            homePage = loginPage.Login("Admin", "admin123");
            Assert.AreEqual("Welcome Admin", homePage.GetWelcomeMessage());
        }
        [TearDown]
        public void TearDown()
        {
            WebDriverManager.QuitDriver();
        }
    }
}