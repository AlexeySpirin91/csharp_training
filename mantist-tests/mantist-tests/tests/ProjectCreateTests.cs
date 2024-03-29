﻿using System;
using NUnit.Framework;
using static LinqToDB.Sql;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreateTests : TestBase
    {
        public ProjectCreateTests()
        {
        }
        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                projects.Add(new ProjectData(GenerateRandomString(50)));
            }
            return projects;
            ;
        }

        [Test, TestCaseSource("RandomProjectDataProvider")]
        public void ProjectCreateTest(ProjectData project)
        {
            AccountData account = new AccountData()
            {
                Login = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProjects = ProjectData.GetProjects();

            if (oldProjects.Contains(project))
            {
                throw new Exception("Такой проект уже существует");
            }

            app.Login.LoginUser(account.Login, account.Password);
            app.Menu.GoToManagement();
            app.Menu.GoToProjectManagement();
            app.Project.CreateNewProject(project.Name);
            List<ProjectData> newProjects = ProjectData.GetProjects();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}