using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Tests
{
    public class Tests : TestBase
    {
        [Category("Login")]
        [Test]
        public void Login_ShouldWork_WithValidCredentials()
        {
            var loginPage = new LoginPage(Driver);

            loginPage.Open();
            var page = loginPage.Login("standard_user", "secret_sauce");

            Assert.That(page.GetWelcomeMessage(), Is.EqualTo("Products"));
        }
        [Category("Login")]
        [Test]
        public void Login_WithoutUsername_ShouldErrorDisplayed()
        {
            var loginPage=new LoginPage(Driver);
            loginPage.Open();
            loginPage.Login("", "");

            Assert.That(loginPage.IsErrorMessageDisplayed(), Is.True);
        }
        [Category("Login")]
        [Test]
        public void Login_AfterLogin_WithValid()
        {
            var loginPage= new LoginPage(Driver);
            loginPage.Open();
            var dashboard = loginPage.Login("standard_user", "secret_sauce");

            Assert.That(dashboard.IsLoaded(), Is.True);
        }


        [Category("Cart")]
        [Test]
        public void Cart_ProductAdded_ProductIsDisplayedInCart()
        {
            var products = new LoginPage(Driver).Open().Login("standard_user", "secret_sauce");

            products.Products.AddToCart("Sauce Labs Backpack");

            var cart = products.OpenCart();

            Assert.That(cart.IsProductInCart("Sauce Labs Backpack"), Is.True);
        }
        [Category("Cart")]
        [Test]
        public void Cart_ProductAdded_AtLeastProductDisplayed()
        {
            var products = new LoginPage(Driver).Open().Login("standard_user", "secret_sauce");

            products.Products.AddToCart("Sauce Labs Backpack");

            var cart = products.OpenCart();

            Assert.That(cart.GetItemCount(), Is.GreaterThan(0));
        }


        [Category("Cart")]
        [TestCase("Cart")]
        [TestCase("Logout")]
        [TestCase("Inventory")]
        public void Products_SideBarNavigation_PageIsLoaded(string target)
        {
            var productsPage = new LoginPage(Driver)
                .Open()
                .Login("standard_user", "secret_sauce");

            BasePage resultPage = target switch
            {
                "Cart" => productsPage.OpenCart(),
                "Logout" => productsPage.OpenLogout(),
                "Inventory" => productsPage.OpenInventory(),
                _ => throw new ArgumentOutOfRangeException()
            };

            Assert.That(resultPage.IsLoaded(), Is.True);
        }

        [Category("Product")]
        [Test]
        public void Products_DataLoaded_ShouldBeDisplayed()
        {
            var productsPage = new LoginPage(Driver).Open().Login("standard_user", "secret_sauce");

            Assert.That(productsPage.Products.AreProductsDisplayed(), Is.True);


        }

        [Category("Product")]
        [Test]
        public void Products_DataLoaded_AtLeastOneProductionIsDisplayed()
        {
            var productsPage = new LoginPage(Driver).Open().Login("standard_user", "secret_sauce");

            Assert.That(productsPage.Products.ProductsCount(), Is.GreaterThan(0));


        }
        [Category("Product")]
        [Test]
        public void Products_DataLoaded_SpecificProductIsDisplayed()
        {
            var productsPage = new LoginPage(Driver).Open().Login("standard_user", "secret_sauce");

            Assert.That(productsPage.Products.IsProductDisplayed("Sauce Labs Bike Light"), Is.True);

        }

        //Screenshot
        [Category("Login")]
        [Test]
        public void Login_BadUsername_ShouldFail()
        {
            var loginPage = new LoginPage(Driver).Open();

            Assert.That(loginPage.IsAcceptedUsername("standard_userQQ"), Is.True);
        }

    }
}
