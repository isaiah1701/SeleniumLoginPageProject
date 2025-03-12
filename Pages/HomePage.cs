using OpenQA.Selenium;
namespace SeleniumLoginPageProject.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private By welcomeMessage = By.Id("welcome");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string GetWelcomeMessage()
        {
            return driver.FindElement(welcomeMessage).Text;
        }



    }
}