using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSpecflowProject.Utilities
{
    public static class Utility
    {

        public static void ScrollTopOfThePage(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,0);");
        }
    }
}
