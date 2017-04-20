using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TangentSolutionsProject.Clients;
using System.Threading.Tasks;

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

        [TestMethod]
        public void getProjectsData()
        {
            //Make sure the token is in memory
            var gotToken = client.getToken(
                    new TangentSolutionsProject.Models.LoginModel()
                    {
                        username = "jacob.zuma",
                        password = "tangent"
                    });
            Task.WaitAll(gotToken);


           var projects = client.getProjects(gotToken.Result);
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
    }
}
