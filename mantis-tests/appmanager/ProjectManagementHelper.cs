using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            manager.Menu.OpenProjectMenu();
            CreateProjectByName(project);
        }

        private void CreateProjectByName(ProjectData project)
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[1]/form/button")).Click();
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.CssSelector("input.btn")).Click();
            
        }

        public List<ProjectData> GetProjectsList()
        {
            manager.Menu.OpenProjectMenu();
            IWebElement projectData = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody"));
            IList<IWebElement> list = projectData.FindElements(By.TagName("a"));
            List<ProjectData> result = new List<ProjectData>();
            for(int i =0; i < list.Count; ++i)
            {
                result.Add(new ProjectData(list[i].Text));
            }
            return result;
        }

        internal void RemoveProject(ProjectData project)
        {
            manager.Menu.OpenProjectMenu();
            driver.FindElement(By.LinkText(project.Name)).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }
    }
}
