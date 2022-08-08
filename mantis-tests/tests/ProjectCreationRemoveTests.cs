using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests 
{
    [TestFixture]
    public class ProjectCreationRemoveTests : TestBase
    {
        private AccountData account;
        [TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open)) //?????????/
            {
                app.Ftp.Upload("/config/config_inc.php", localFile);

            }
        }

        [SetUp]
        public void TestSetup()
        {
            account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
                Email = "admin@localhost.localdomain"
            };
            app.Login.Login(account);
        }

        [TearDown]
        public void DerivedTearDown()
        {
            app.Login.Logout();
        }

        [Test]
        public void TestCreateProject()
        {

            ProjectData project = new ProjectData("project");
            
            List<ProjectData> projectsOld = app.API.GetProjectsList(account);
            app.Project.CreateProject(project);
            List<ProjectData> projectsNew = app.API.GetProjectsList(account);
            Assert.AreNotEqual(projectsOld, projectsNew);
            Assert.AreEqual((projectsOld.Count+1), projectsNew.Count);
            app.Project.RemoveProject(project);
        }

        [Test]
        public void TestRemoveProject()
        {

            ProjectData project;

            List<ProjectData> projectsOld = app.API.GetProjectsList(account);
            if (projectsOld.Count == 0)
            {
                project = new ProjectData("project");
                app.API.CreateProject(account, project);
            }
            else
            {
                project = projectsOld[0];
            }

            List<ProjectData> projectsNew = app.API.GetProjectsList(account);
            app.Project.RemoveProject(project);
            List<ProjectData> projectsRemove = app.API.GetProjectsList(account);
            Assert.AreNotEqual(projectsRemove, projectsNew);
            Assert.AreEqual((projectsRemove.Count + 1), projectsNew.Count);
        }
        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
        }

    }
}
