using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        public string baseUrl { get; private set; }

        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager) 
        {
            this.baseUrl = baseUrl;
        }

       /* public List<AccountData> GetAllAccounts()
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table tr"));
            


        }
        //public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input.[value='Удалить учетную запись']")).Click();
            driver.FindElement(By.CssSelector("input.[value='Удалить учетную запись']")).Click();
        }/

        public IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input.submit")).Click();
            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.CssSelector("input.submit")).Click();
            return driver;
        }*/
    }
}
