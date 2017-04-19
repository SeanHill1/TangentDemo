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


           var projects = client.getProjects();
            Task.WaitAll(projects);

            Assert.IsNotNull(projects.Result);
            Assert.IsTrue(true);
        }
    }
}
