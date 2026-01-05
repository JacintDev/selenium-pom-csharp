using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Pages
{
    public class LoginPage: BasePage
    {
        private const string URL = "https://www.saucedemo.com/";


        public LoginPage(IWebDriver driver) :base(driver)
        {
        }

        private IWebElement UsernameInput => WaitAndFind(By.Id("user-name"));
        private IWebElement PasswordInput => WaitAndFind(By.Id("password"));
        private IWebElement LoginButton => WaitAndFind(By.Id("login-button"));
        private IWebElement ErrorMessage => WaitAndFind(By.CssSelector("h3[data-test='error']"));
        private IWebElement WelcomeText => WaitAndFind(By.ClassName("login_logo"));

        private IWebElement LoginCredentials => WaitAndFind(By.Id("login_credentials"));

        public LoginPage Open()
        {
            Driver.Navigate().GoToUrl(URL);
            return this;
        }

        public void EnterUsername(string username)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public bool IsErrorMessageDisplayed()
        {
            return ErrorMessage.Displayed;
        }


        public ProductsPage Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();

            return new ProductsPage(Driver);
        }

        public override bool IsLoaded()
        {
            return WelcomeText.Displayed;
        }

        public bool IsAcceptedUsername(string username)
        {
           return LoginCredentials.Text.Contains(username);
        }
    }
}
