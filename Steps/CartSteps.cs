using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SampleSpecflowProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleSpecflowProject.Steps
{
    [Binding]
    public sealed class CartSteps:CommonPage
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private CartPage _cartPage;
        public CartSteps(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _cartPage = new CartPage(_driver, _scenarioContext);
        }

        [Then(@"I find total '(.*)' item listed in my cart")]
        [Then(@"I am able to verify '(.*)' items in my cart")]
        public void ThenIFindTotalItemListedInMyCart(int items)
        {
            Assert.IsTrue(_cartPage.VerifyItemsInCart(items));
        }


        [When(@"I search for lowest price item and remove from my cart")]
        public void WhenISearchForLowestPriceItemAndRemoveFromMyCart()
        {
            _cartPage.SearchForLowestPrice();
        }


    }
}
