using OpenQA.Selenium;
using SampleSpecflowProject.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleSpecflowProject.Steps
{
    [Binding]
    public class CommonSteps : CommonPage
    {
        public CommonSteps(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, scenarioContext)
        {
        }

        [Given(@"I navigate to '(.*)' page")]
        
        public void GivenINavigateToPage(string url)
        {
            GotoHomePage(url);
        }


    }
}
