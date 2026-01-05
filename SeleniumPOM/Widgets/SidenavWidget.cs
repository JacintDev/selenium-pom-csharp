using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Widgets
{
    public class SidenavWidget : BaseWidget
    {
        
        public SidenavWidget(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private readonly By MenuButton = By.Id("react-burger-menu-btn");
        private readonly By InventoryLocator = By.Id("inventory_sidebar_link");
        private readonly By LogoutLocator = By.Id("logout_sidebar_link");


        public void OpenMenu()
        {
            WaitAndFindClickable(MenuButton).Click();
        }


        public LoginPage OpenLogout()
        {
            OpenMenu();
            WaitAndFindClickable(LogoutLocator).Click();
            return new LoginPage(Driver);
        }

        public ProductsPage OpenInventory()
        {
            OpenMenu();
            WaitAndFindClickable(InventoryLocator).Click();
            return new ProductsPage(Driver);
        }





    }
}
