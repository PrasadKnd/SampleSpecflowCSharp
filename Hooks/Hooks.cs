using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SampleSpecflowProject.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace SampleSpecflowProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {


        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IObjectContainer objectContainer;
        private IWebDriver _driver;
        private static ScenarioContext _scenarioContext;
        private readonly TestContext _testContext;
        private static FeatureContext _featureContext;
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext, TestContext testContext, FeatureContext featureContext)
        {
            this.objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _featureContext = featureContext;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            string testRunDir = _testContext.TestRunDirectory;
            string timeStamp = testRunDir.Substring(testRunDir.Length - 19);
            try
            {
                string testcaseName = _scenarioContext.ScenarioInfo.Title;
                _driver = InitWebDrivers.WebDriver(testcaseName,timeStamp);
                objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            }
            catch (Exception ex)
            {
                log.Error("Unable to initiate web driver instance due to " + ex.Message);
            }
        }
        [AfterScenario]
        public void CloseBrowser()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
