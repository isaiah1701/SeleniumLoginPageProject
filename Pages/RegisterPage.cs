using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V131.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;




namespace BookStoreProject.Pages
{
  
    
     

namespace SeleniumLoginPageProject.Pages
    {
        public class RegisterPage
        {
            private IWebDriver driver;
            private By firstNameField = By.Id("firstname");
            private By lastNameField = By.Id("lastName");
            private By usernameField = By.Id("userName");
            private By passwordField = By.Id("Password");
            private By captchaCheckbox = By.Id("recaptcha-anchor");

            public RegisterPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public void EnterFirstName(string firstName)
            {
                driver.FindElement(By.Id("firstname")).SendKeys(firstName);
            }

            public void EnterLastName(string lastName)
            {
                driver.FindElement(By.Id("lastname")).SendKeys(lastName);
            }

            public void EnterUsername(string username)
            {
                driver.FindElement(By.Id("userName")).SendKeys(username);
            }

           
            public void EnterPassword(string password)
            {
                driver.FindElement(By.Id("password")).SendKeys(password);
            }



           

            public void Scroll(int x, int y)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript($"window.scrollBy({x},{y})");
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



            public void clickAlert()
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }


            public void Register(string firstName, string lastName, string username, string password)
            {

                NavigateToRegisterPage();
                EnterFirstName(firstName);
                EnterLastName(lastName);
                EnterUsername(username);
                EnterPassword(password);
                Scroll(0, 300);
               
                ClickRegister();
                GoToLogin();    
            }
        }
    }





}

