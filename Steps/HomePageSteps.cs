using OpenQA.Selenium;
using SampleSpecflowProject.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleSpecflowProject.Steps
{
    [Binding]
    public sealed class HomePageSteps:CommonPage
    {
        private readonly ScenarioContext _scenarioContext;
        private HomePage _homePage;
        public HomePageSteps(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(_driver,_scenarioContext);
        }


        [Given(@"I add '(.*)' random items to my cart")]
        public void GivenIAddRandomItemsToMyCart(int items)
        {
            _homePage.AddRandomItems(items);
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            _homePage.ClickOnCartButton();
        }

        
    }
}
