using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SampleSpecflowProject.Pages
{
    public abstract class BasePage
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected IWebDriver _driver;
        protected ScenarioContext _scenarioContext;
        protected WebDriverWait _wait;
        protected int _timeout = 120;

        protected BasePage(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout));
        }

    }
}
