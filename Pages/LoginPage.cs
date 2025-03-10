using openQA.Selenium;

namespace SeleniumLoginPageProject.Pages
{
    public class LoginPage
    {
       private IWebDriver driver;
        private By usernameField = By.Id("username");
        private By passwordField = By.Id("password");
        private By loginButton = By.CssSelector("button[type='submit']");




        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsername(string username)
        {
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }

        public HomePage Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
            return new HomePage(driver);
        }




    }
}