using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void OpenProjectMenu()
        {
            driver.FindElement(By.LinkText("Управление")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/ul/li[3]/a")).Click();
        }
    }
}
