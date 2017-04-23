using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TangentSolutionsProject.Clients;
using System.Threading.Tasks;
using TangentSolutionsProject.Models;

namespace TangentSolutionsProjectTests
{
    /// <summary>
    /// Summary description for ProjectsTests
    /// </summary>
    [TestClass]
    public class ProjectsTests
    {
        Client client = new Client();
        public ProjectsTests()
        {
            
        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
            /// <summary>
            /// Helper method for tests
            /// </summary>
            /// <returns></returns>
        private string getToken()
        {
            var gotToken = client.getToken(
                    new TangentSolutionsProject.Models.LoginModel()
                    {
                        username = "jacob.zuma",
                        password = "tangent"
                    });
            Task.WaitAll(gotToken);
            return gotToken.Result;
        }

        /// <summary>
        /// Helper method for tests
        /// </summary>
        /// <returns></returns>
        private ProjectModel createTestData()
        {
            //Fake data
            ProjectCreateModel temp = new ProjectCreateModel()
            {
                title = "Create Test",
                description = "Testing create",
                is_active = true,
                is_billable = false,
                start_date = "2017-04-23",
                end_date = "2017-04-23"
            };

            var project = client.createProject(getToken(), temp);
            Task.WaitAll(project);
            return project.Result;
        }
        /// <summary>
        /// Helper method for tests
        /// </summary>
        /// <returns></returns>
        private bool deleteHelper(int pk)
        {
            

            var success = client.deleteProject(getToken(), pk);
            Task.WaitAll(success);
            return success.Result;
        }

        [TestMethod]
        public void getProjectsData()
        {

           var projects = client.getProjects(getToken());
            Task.WaitAll(projects);

            Assert.IsNotNull(projects.Result);
            Assert.IsNotNull(projects.Result[0].pk);
            Assert.IsNotNull(projects.Result[0].title);
            Assert.IsNotNull(projects.Result[0].is_active);
            Assert.IsNotNull(projects.Result[0].is_billable);
            Assert.IsNotNull(projects.Result[0].start_date);
            Assert.IsNotNull(projects.Result[0].end_date);
            Assert.IsNotNull(projects.Result[0].description);
            Assert.IsNotNull(projects.Result[0].task_set);
            Assert.IsNotNull(projects.Result[0].resource_set);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void createProject()
        {

            var project = createTestData();

            Assert.IsNotNull(project);
            Assert.IsNotNull(project.pk);
            Assert.IsNotNull(project.title);
            Assert.IsNotNull(project.is_active);
            Assert.IsNotNull(project.is_billable);
            Assert.IsNotNull(project.start_date);
            Assert.IsNotNull(project.end_date);
            Assert.IsNotNull(project.description);
            Assert.IsNotNull(project.task_set);
            Assert.IsNotNull(project.resource_set);
            Assert.IsTrue(true);
            //deleteHelper(project.pk);
        }

        [TestMethod]
        public void deleteProject()
        {
            
            var project = createTestData();
            Task.WaitAll(Task.Delay(5000));
            Assert.IsTrue(deleteHelper(project.pk));

        }
    }
}
