using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace HudlTestProject
{
    [Binding]
    public class Hooks : Steps
    {

        public IWebDriver _driver;
        public readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void InitializeAsync()
        {
            _driver = GetDriver();
            _container.RegisterInstanceAs(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Dispose();
            try
            {
                KillProcess("chromedriver.exe");
            }
            catch
            {
                KillProcess("chromedriver.exe");
            }
        }

        public IWebDriver GetDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddArgument("-no-sandbox");
            chromeOptions.AddArgument("--disable-extensions");
            var driverService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            ChromeDriver driver = new ChromeDriver(driverService, chromeOptions);  
            return driver;
        }

        public void KillProcess(string processName)
        {
            // Kill off the Chrome Web Driver which keeps hanging around
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }
    }
}