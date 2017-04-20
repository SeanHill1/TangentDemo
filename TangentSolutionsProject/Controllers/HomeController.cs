using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TangentSolutionsProject.Clients;
using TangentSolutionsProject.Models;

namespace TangentSolutionsProject.Controllers
{
    public class HomeController : Controller
    {
        Client client = new Client();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            

            if (Session["token"] == null)
                return RedirectToAction("Login", "Login");

            
            
            string token = (string)Session["token"];

            var projects = await client.getProjects(token);
            ViewBag.index = projects.ElementAt(0).pk;
            return View(projects);
        }

        [HttpPost]
        public async Task<Boolean> Edit(ProjectModel data)
        {
            Console.WriteLine(data);
            try { 
            return await client.updateProject((string)Session["token"], data);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}