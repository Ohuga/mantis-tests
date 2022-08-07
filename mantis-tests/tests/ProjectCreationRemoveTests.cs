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
            AccountData account = new AccountData()
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
            
            List<ProjectData> projectsOld = app.Project.GetProjectsList();
            app.Project.CreateProject(project);
            List<ProjectData> projectsNew = app.Project.GetProjectsList();
            Assert.AreNotEqual(projectsOld, projectsNew);
            Assert.AreEqual((projectsOld.Count+1), projectsNew.Count);
            app.Project.RemoveProject(project);
        }

        [Test]
        public void TestRemoveProject()
        {

            ProjectData project = new ProjectData("project");

            List<ProjectData> projectsOld = app.Project.GetProjectsList();
            app.Project.CreateProject(project);
            List<ProjectData> projectsNew = app.Project.GetProjectsList();
            app.Project.RemoveProject(project);
            List<ProjectData> projectsRemove = app.Project.GetProjectsList();
            Assert.AreNotEqual(projectsRemove, projectsNew);
            Assert.AreEqual((projectsRemove.Count + 1), projectsNew.Count);
            Assert.AreNotEqual(projectsRemove, projectsOld);
        }
        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
        }

    }
}
