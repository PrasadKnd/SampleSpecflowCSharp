using OpenQA.Selenium;
using SampleSpecflowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleSpecflowProject.Pages
{
    public class CartPage: CommonPage
    {
        public CartPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext)
        {

        }
        #region Locators
        private IList<IWebElement> LstItemsInCart => _driver.FindElements(By.XPath("//tr[contains(@class,'cart-item')]/td[@class='product-price']"));
        private IList<IWebElement> LstBtnRemoveItem => _driver.FindElements(By.XPath("//tr[contains(@class,'cart-item')]/td[@class='product-remove']/a"));
       
         #endregion

        #region Methods

        public bool VerifyItemsInCart(int items)
        {
            Random random = new Random();
            //Added refesh function as observed that sometime items are showing less
            _driver.Navigate().Refresh();
            if (LstItemsInCart.Count == items)
                return true;
            else
            {
                log.Info($"Total items in cart are : {LstItemsInCart.Count} and expected was {items}");
                return false;
            }
        }

        public void SearchForLowestPrice()
        {
            List<double> itemPrices = new List<double>();
            foreach (var item in LstItemsInCart)
            {
                log.Info($"Items price in cart are : {item.Text}");
                itemPrices.Add(Convert.ToDouble(item.Text.Replace("$", "")));
            }
            LstBtnRemoveItem[itemPrices.IndexOf(itemPrices.Min())].Click();
        }

        #endregion
    }
}
