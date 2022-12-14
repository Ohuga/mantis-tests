using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {

        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient((Binding)(new BasicHttpBinding()), new EndpointAddress("http://localhost/mantisbt-2.25.4/api/soap/mantisconnect.php"));
           Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient((Binding)(new BasicHttpBinding()), new EndpointAddress("http://localhost/mantisbt-2.25.4/api/soap/mantisconnect.php"));
            Mantis.ProjectData[] list = client.mc_projects_get_user_accessible(account.Name, account.Password);

            List<ProjectData> plist = new List<ProjectData>();
            foreach (Mantis.ProjectData p in list)
            {
                plist.Add(new ProjectData(p.name) { Id = p.id });
            }

            return plist;
        }
        public void CreateProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient((Binding)(new BasicHttpBinding()), new EndpointAddress("http://localhost/mantisbt-2.25.4/api/soap/mantisconnect.php"));
            Mantis.ProjectData p = new Mantis.ProjectData
            {
                name = project.Name
            };
            project.Id = client.mc_project_add(account.Name, account.Password, p);
        }
    }
}
