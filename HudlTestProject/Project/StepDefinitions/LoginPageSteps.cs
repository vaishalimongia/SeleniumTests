using TechTalk.SpecFlow;
using HudlTestProject.Pages;
using NUnit.Framework;

namespace HudlTestProject.StepDefinitions
{
    [Binding]
    public class LoginPageSteps
    {
        private readonly LoginPage _loginPage;

        public LoginPageSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [StepDefinition(@"I navigate to Hudl app page")]
        public void GivenINavigateToUiAppPage()
        {
            _loginPage.NavigateToAppURL(TestContext.Parameters.Get("URL"));
        }

        [StepDefinition(@"I click on ""(.*)""")]
        public void ThenIClickOn(string action)
        {
            _loginPage.LoginPageFieldsClickOn(action);
        }

        [StepDefinition(@"I see a page with message ""(.*)"" and index in ""(.*)""")]
        public void ThenISeeAPageWithMsg(string msg, string index)
        {
            _loginPage.ValidatetMsg(msg, index);
        }

        [StepDefinition(@"I enter invalid Email, Password and click Submit button")]
        public void WhenIEnterEmailAndPasswordAndClickSubmitButton()
        {
            _loginPage.LoginDetails(TestContext.Parameters.Get("UserName"), TestContext.Parameters.Get("Password"));
        }

        [StepDefinition(@"I enter valid Email, Password and click Submit button")]
        public void WhenIEnterValidEmailAndPasswordAndClickSubmitButton()
        {
            _loginPage.LoginDetails(TestContext.Parameters.Get("ValidUserName"), TestContext.Parameters.Get("ValidPassword"));
        }

        [StepDefinition(@"I see a ""(.*)"" menu and index in ""(.*)""")]
        public void ThenISeeAHomePageWithMsg(string menu, string index)
        {
            _loginPage.ValidatetMsgInHomePage(menu, index);
        }
    }
}
