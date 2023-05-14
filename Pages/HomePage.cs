using OpenQA.Selenium;
using SampleSpecflowProject.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleSpecflowProject.Pages
{
    public class HomePage: CommonPage
    {
        public HomePage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext)
        {
            
    }
        #region Locators
        private IList<IWebElement> LstAddToCart => _driver.FindElements(By.XPath("//a[contains(@href,'add')]"));
        private IWebElement BtnCart => _driver.FindElement(By.XPath("//li/a[contains(@href,'cart')]"));
        private IWebElement TxtSuggesterElement => _driver.FindElement(By.Id("suggesterElement"));
        private IWebElement BtnSearchBupaText => _driver.FindElement(By.XPath("//span[text()='Search Bupa']"));
        #endregion

        #region Methods

        public void AddRandomItems(int items)
        {
            Random random = new Random();
            var totalItems = LstAddToCart.Count;
            List<int> selectedNumber = new List<int>();
            log.Info(" ");

            while (selectedNumber.Count < items)
            {
                int number = random.Next(totalItems);
                if (!selectedNumber.Contains(number))
                    selectedNumber.Add(number);
            }

            foreach (var ele in selectedNumber)
            {
                Utility.ScrollTopOfThePage(_driver);
                LstAddToCart[ele].Click();
            }
        }

        public void ClickOnCartButton()
        {
            BtnCart.Click();
        }



        #endregion
    }
}
