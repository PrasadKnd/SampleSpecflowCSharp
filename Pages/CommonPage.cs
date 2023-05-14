using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleSpecflowProject.Pages
{
    public class CommonPage:BasePage
    {
        public CommonPage(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext)
        {

        }
        #region Locators
        private IWebElement SearchWrap => _driver.FindElement(By.CssSelector("div.mod-search-overlay"));
        private IWebElement TxtSearchField => _driver.FindElement(By.Id("gsa_search"));
        private IWebElement TxtSuggesterElement => _driver.FindElement(By.Id("suggesterElement"));
        private IWebElement BtnSearchBupaText => _driver.FindElement(By.XPath("//span[text()='Search Bupa']"));
        #endregion

        #region Methods

        public void GotoHomePage(string url)
        {
            
            _driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
            


            string pageURL = GetCurrentUrl();
            log.Info("Navigation was successfull at page : " + pageURL);

        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public void ClickOnSearchLoupeButton()
        {
            //LoupeButton.Click();
        }



        #endregion
    }
}
