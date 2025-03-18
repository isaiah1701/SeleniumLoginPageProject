using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumLoginPageProject.Utilities;


namespace SeleniumLoginPageProject.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private By usernameField = By.Id("userName");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsCurrentPage()
        {
            return driver.Url.Contains("demoqa.com/login");
        }


        public void EnterUsername(string username)
        {
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLoginButton()//test page has loaded
        {
            driver.FindElement(loginButton).Click();
        }


        public void clickNewUser()
        {
            driver.FindElement(By.Id("newUser")).Click();
        }


        public void NavigateToLoginPage()
        {
            driver.Url = "https://demoqa.com/login";
        }   


        public void Login(string username, string password)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,300)");
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
           
             
        }
    }
}