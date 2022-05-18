using HudlTestProject.ObjectRepository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace HudlTestProject.Pages
{
    public class LoginPage : LoginOR
    {
        private readonly LoginOR _loginOR;
        private int TimeToWait = 10;
        public LoginPage(IWebDriver driver, LoginOR loginOR) : base(driver)
        {
            _loginOR = loginOR;
        }

        public void NavigateToAppURL(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
                Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);
                Console.WriteLine(" ::Navigate to " + url);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong " + url + " not loaded properly");
                Assert.Fail("Inner exception: {0}", e.StackTrace);
            }
        }

        public void LoginPageFieldsClickOn(string action)
        {
            try
            {
                switch (action.Trim().Replace(" ", ""))
                {
                    case "LoginButton":
                        WeClick(LoginButton);
                        break;
                    case "CoachText":
                        WeClick(CoachText);
                        break;
                    case "LogoutButton":
                        WeClick(LogoutButton);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong while clicking in webelement in login page " + action);
                Assert.Fail("Inner exception: {0}", e.StackTrace);
            }
        }

        public void ValidatetMsg(string expectedTitle, string index)
        {
            try
            {
                Thread.Sleep(2001);
                var msg = Driver.FindElement(By.XPath("(//*[contains(text(),\"" + expectedTitle + "\")])["+index+"]")).Displayed;
                Assert.IsTrue(msg, ":: This is not the expected Message");
                Console.WriteLine(":: the Message of the page is " + msg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message not displayed correctly " + expectedTitle);
                Assert.Fail("Inner exception: {0}", e.StackTrace);
            }
        }

        public void ValidatetMsgInHomePage(string expectedTitle, string index)
        {
            try
            {
                Thread.Sleep(2001);
                var msg = Driver.FindElement(By.XPath("(//*[contains(text(),'" + expectedTitle + "')])[" + index + "]")).Displayed;
                Assert.IsTrue(msg, ":: This is not the expected Message");
                Console.WriteLine(":: the Message of the page is " + msg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message not displayed correctly " + expectedTitle);
                Assert.Fail("Inner exception: {0}", e.StackTrace);
            }
        }

        public void LoginDetails(string username, string password)
        {
            try
            {
                WeSendKeys(UserNameField, username, true);
                WeSendKeys(PasswordField, password, true);
                WeClick(LogInButton);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Login Page for user " + username + "having problem");
                Assert.Fail("Inner exception: {0}", e.StackTrace);
            }
        }

        public void WeClick(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeToWait));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            wait.Until((driver) =>
            {
                try
                {
                    element.Click();
                    return true;
                }
                catch (ElementClickInterceptedException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WeSendKeys(IWebElement element, string text, bool clearFirst = false)
        {
            element.Click();
            if (clearFirst == true)
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Backspace);
            }
            element.SendKeys(text);
        }
    }
}
