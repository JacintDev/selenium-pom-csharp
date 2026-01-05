using OpenQA.Selenium;
using SeleniumPOM.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Pages
{
    public class ProductsPage : BasePage
    {
        public ProductListWidget Products { get; }
        public SidenavWidget Sidenav { get; }

        public ProductsPage(IWebDriver driver) : base(driver)
        {
            
            Products = new ProductListWidget(driver, Wait);
            Sidenav=new SidenavWidget(driver, Wait);
        }

        private IWebElement WelcomeText => WaitAndFind(By.CssSelector("span[class='title']"));
        private IWebElement CartIcon => WaitAndFind(By.ClassName("shopping_cart_link"));
        public LoginPage OpenLogout() => Sidenav.OpenLogout();
        public ProductsPage OpenInventory() => Sidenav.OpenInventory();


        public override bool IsLoaded()
        {
            return WelcomeText.Displayed;
        }

        public string GetWelcomeMessage()
        {
            return WelcomeText.Text;
        }
        public CartPage OpenCart()
        {
            CartIcon.Click();
            return new CartPage(Driver);
        }


    }
}
