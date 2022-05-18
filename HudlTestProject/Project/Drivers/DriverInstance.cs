using OpenQA.Selenium;

namespace HurdleTestProject.Drivers
{
    public class DriverInstance
    {
        public IWebDriver Driver;
        public DriverInstance(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
