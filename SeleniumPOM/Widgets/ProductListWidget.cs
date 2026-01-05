using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Widgets
{
    public class ProductListWidget :BaseWidget
    {

        public ProductListWidget(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IReadOnlyCollection<IWebElement> Products => 
            WaitAndFindAll(By.ClassName("inventory_item_name"));


        public bool AreProductsDisplayed()
        {
            return Products.Any();
        }

        public bool IsProductDisplayed(string productName)
        {
            return Products.Any(x=>x.Text == productName);
        }

        public int ProductsCount()
        {
            return Products.Count();
        }

        public void AddToCart(string productName)
        {
            var productElement= Products.First(x=> x.Text == productName);

            var productCard = productElement
                .FindElement(By.XPath("./ancestor::div[@class='inventory_item_description']"));

            var addButton = productCard.FindElement(By.TagName("button"));

            addButton.Click();

        }
    }
}
