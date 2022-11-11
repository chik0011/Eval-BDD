using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BDD.BaseClasses;
using BDD_MSTEST.ComponentHelper;
using OpenQA.Selenium;

namespace PayementBDD.StepDefinitions
{
    [Binding]
    public class GameStartSteps
    {
        [Given(@"user fills the three inputs")]
        public void UserFillsThreeInputs()
        {
            NavigationHelper.NavigateToHomePage();
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "1234567891011141");
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), "02/2022");
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "123");
        }

        [Given(@"user fills the three inputs with wrong credit card")]
        public void GivenCreditCardNumberIsSixteenError()
        {
            NavigationHelper.NavigateToHomePage();
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "123456789101");
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), "02/2022");
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "123");
        }

        [Given(@"user fills the three inputs with wrong expiration")]
        public void GivenCreditExpirationError()
        {
            NavigationHelper.NavigateToHomePage();
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "1234567891011141");
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), "02/02/2022");
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "123");
        }

        [Given(@"user fills the three inputs with wrong CVC")]
        public void GivenCreditCVCError()
        {
            NavigationHelper.NavigateToHomePage();
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), "1234567891011141");
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), "02/2022");
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), "12345");
        }

        [Given(@"credit card number is sixteen digits long")]
        public void GivenCreditCardNumberIsSixteen()
        {
            Assert.IsTrue(TextBoxHelper.ValueInTextBox(By.Id("creditCardNumber")).Length == 16);
        }

        [Given(@"credit card number is not sixteen digits long")]
        public void GivenCreditCardNumberIsNotSixteen()
        {
            Assert.IsTrue(TextBoxHelper.ValueInTextBox(By.Id("creditCardNumber")).Length != 16);
        }

        [Given(@"expiration date is at format MM/YYYY")]
        public void GivenExpirationDateIsGodFormat()
        {
            string pattern = @"^[0-9]{2}\/[0-9]{4}$";
            Regex rxg = new Regex(pattern);
            Assert.IsTrue(rxg.IsMatch(TextBoxHelper.ValueInTextBox(By.Id("expirationDate"))));
        }

        [Given(@"expiration date is not at format MM/YYYY")]
        public void GivenExpirationDateIsNotGodFormat()
        {
            string pattern = @"^[0-9]{2}\/[0-9]{4}$";
            Regex rxg = new Regex(pattern);
            Assert.IsFalse(rxg.IsMatch(TextBoxHelper.ValueInTextBox(By.Id("expirationDate"))));
        }

        [Given(@"cvc is three digits long")]
        public void GivenCVCNumberIsThreeLong()
        {
            Assert.IsTrue(TextBoxHelper.ValueInTextBox(By.Id("cvc")).Length == 3);
        }

        [Given(@"cvc is not three digits long")]
        public void GivenCVCNumberIsNotThreeLong()
        {
            Assert.IsTrue(TextBoxHelper.ValueInTextBox(By.Id("cvc")).Length != 3);
        }

        [When(@"submit button is pressed")]
        public void WhenSubmitButtonIsPressed()
        {
            LinkHelper.ClickLink(By.XPath("//*[@id=\"submitCard\"]"));
        }

        [Then(@"user is on page paymentConfirmed")]
        public void ThenUserIsOnPagePaymentConfirmed()
        {
            Assert.IsTrue(ObjectRepository.Driver.Url == "http://localhost/BDD/paymentConfirmed.html");
        }

        [Then(@"user is on homePage")]
        public void ThenUserIsOnHomePage()
        {
            Assert.IsTrue(ObjectRepository.Driver.Url == "http://localhost/BDD/Workshop.html");
        }
    }
}
