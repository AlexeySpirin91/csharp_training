using System;
using NUnit.Framework;
using static LinqToDB.Sql;

namespace mantis_tests.tests
{
    [TestFixture]
    public class ProjectRemoveTests:TestBase
	{
		public ProjectRemoveTests()
		{
		}
		[Test]
		public void ProjectRemoveTest()
		{
            AccountData account = new AccountData()
            {
                Login = "administrator",
                Password = "root"
            };
            int index = 0;
            List<ProjectData> oldProjects = ProjectData.GetProjects();
            int count = oldProjects.Count();

            app.Login.LoginUser(account.Login, account.Password);
            app.Menu.GoToManagement();
            app.Menu.GoToProjectManagement();
            app.Project.DeleteProject(index,count);

            List<ProjectData> newProjects = ProjectData.GetProjects();

            if(count != 0)
            {
                oldProjects.RemoveAt(index);
            }
            

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}

