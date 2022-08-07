using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitUpdatePasswordForm();
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("realname")).SendKeys(account.Name);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);

        }

        private void SubmitPasswordForm()
        {
            IWebElement w = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[4]/div/div/div[1]/form/fieldset/input[2]"));
            w.Click();
        }
        private void SubmitUpdatePasswordForm()
        {
            IWebElement w = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[5]/div/div/div/div/form/fieldset/span/button/span"));
            w.Click();
        }
        private void OpenRegistrationForm()
        {
            IWebElement w = driver.FindElement(By.LinkText("Зарегистрировать новую учётную запись"));
            w.Click();
        }

        private void SubmitRegistration()
        {
            IWebElement w = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[4]/div/div/div[1]/form/fieldset/input[2]"));
            w.Click();
            //driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.4/login_page.php";
        }
    }
}
