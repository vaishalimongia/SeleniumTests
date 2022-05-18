using HurdleTestProject.Drivers;
using OpenQA.Selenium;

namespace HudlTestProject.ObjectRepository
{
    public class LoginOR : DriverInstance
    {
        public LoginOR(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement LoginButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[contains(@data-qa-id,'login')]"));
            }
        }

        public IWebElement UserNameField
        {
            get
            {
                return Driver.FindElement(By.Id("email"));
            }
        }

        public IWebElement PasswordField
        {
            get
            {
                return Driver.FindElement(By.Id("password"));
            }
        }

        public IWebElement LogInButton
        {
            get
            {
                return Driver.FindElement(By.Id("logIn"));
            }
        }

        public IWebElement CoachText
        {
            get
            {
                return Driver.FindElement(By.XPath("(//*[contains(text(),'Coach')])[3]"));
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return Driver.FindElement(By.XPath("(//*[contains(text(),'Log Out')])[2]"));
            }
        }
    }
}
