using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            OpenMainPage();
            FillLogin(account);
            SubmitPasswordForm();
            FillPassword(account);
            SubmitLoginPasswordForm();
        }

        private void FillPassword(AccountData account)
        {
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
        }
        
        private void FillLogin(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
        }
        private void SubmitLoginPasswordForm()
        {
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[4]/div/div/div[1]/form/fieldset/input[3]")).Click();
        }

        internal void Logout()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul/li[3]/a/span")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul/li[3]/ul/li[4]/a")).Click();
        }
    }
}
