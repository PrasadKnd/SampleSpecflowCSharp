using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SampleSpecflowProject.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SampleSpecflowProject.Drivers
{
    public class InitWebDrivers
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static IWebDriver _driver;
        public static IWebDriver WebDriver(string testName, string timeStamp)
        {
            string browser = ConfigData.Browser;
            string device = ConfigData.Device;
            switch (browser.ToUpper() + device.ToUpper())
            {
                case "CHROMEDESKTOP":
                    _driver = ChromeDriver();
                    break;
                
                default:
                    log.Error("Configuration for " + device + " device or " + browser + " browser is not prepared");
                    break;
            }
            return _driver;
        }
        private static IWebDriver ChromeDriver()
        {
            var options = new ChromeOptions();
            string packagePath = null;
            var refPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string finalRef = Path.Combine(refPath, "References");
            if (Directory.Exists(finalRef))
            {
                packagePath = finalRef;
            }
            else
            {
                var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
                log.Info("current directory" + directory);
                packagePath = Path.Combine(directory.FullName);
                string currentDir_location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            string path = packagePath;
            options.AddArguments(
                 //"--disable-extensions",
                 "--disable-features",
                 "--disable-popup-blocking",
                 "--disable-settings-window",
                 "--disable-impl-side-painting",
                 "--enable-javascript",
                 "--start-maximized",
                 "--no-sandbox",
                 //"--headless",
                 "--disable-gpu",
                 "--dump-dom",
                 "test-type=browser",
                 "disable-infobars",
                  "test-type",
                 "--enable-automation",
                 "--disable-dev-shm-usage"
                 //"--incognito"
                 );//Tetsing Purpose
                   //options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                   //options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddUserProfilePreference("download.default_directory", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"));
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AcceptInsecureCertificates = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            _driver = new ChromeDriver(path, options, TimeSpan.FromMinutes(2));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();
            return _driver;
        }
    }
}
