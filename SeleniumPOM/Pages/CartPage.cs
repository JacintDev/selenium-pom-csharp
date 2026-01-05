using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Pages
{
    public class CartPage : BasePage
    {

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        private IReadOnlyCollection<IWebElement> CartItems =>
            WaitAndFindAll(By.ClassName("cart_item"));

        public override bool IsLoaded()
        {
            return Driver.PageSource.Contains("Your Cart");
        }

        public int GetItemCount()
        {
            return CartItems.Count;
        }

        public bool IsProductInCart(string productName)
        {
            return CartItems.Any(x=> x.Text.Contains(productName));
        }

    }
}
