using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V131.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Pages
{
  
    
     

namespace SeleniumLoginPageProject.Pages
    {
        public class RegisterPage
        {
            private IWebDriver driver;
            private By firstNameField = By.Id("firstName");
            private By lastNameField = By.Id("lastName");
            private By usernameField = By.Id("userName");
            private By passwordField = By.Id("password");
            private By captchaCheckbox = By.CssSelector("div.recaptcha-checkbox-border");

            public RegisterPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public void EnterFirstName(string firstName)
            {
                driver.FindElement(firstNameField).SendKeys(firstName);
            }

            public void EnterLastName(string lastName)
            {
                driver.FindElement(lastNameField).SendKeys(lastName);
            }

            public void EnterUsername(string username)
            {
                driver.FindElement(usernameField).SendKeys(username);
            }

            public void EnterPassword(string password)
            {
                driver.FindElement(passwordField).SendKeys(password);
            }

            public void ClickCaptcha()
            {
                var captchaElement = driver.FindElement(captchaCheckbox);
                if (captchaElement.Displayed)
                {
                    captchaElement.Click();
                }
            }


            public void NavigateToRegisterPage()
            {
                driver.Url = "https://demoqa.com/register";
            }   

            public void ClickRegister()
            {
                driver.FindElement(By.Id("register")).Click();
            }   



            public void GoToLogin()
            {

                driver.FindElement(By.Id("gotologin")).Click();
            
            
            }






            public void Register(string firstName, string lastName, string username, string password)
            {

                NavigateToRegisterPage();
                EnterFirstName(firstName);
                EnterLastName(lastName);
                EnterUsername(username);
                EnterPassword(password);
                ClickCaptcha();
                ClickRegister();
                GoToLogin();    
            }
        }
    }





}

