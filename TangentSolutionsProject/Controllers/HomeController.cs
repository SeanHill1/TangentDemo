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
       
        // GET: Home
        public async Task<ActionResult> Index()
        {
            

            if (Session["token"] == null)
                return RedirectToAction("Login", "Login");

            Client client = new Client();
            
            string token = (string)Session["token"];

            var projects = await client.getProjects(token);
            ViewBag.index = projects.ElementAt(0).pk;
            return View(projects);
        }

        public ActionResult ViewTasks()
        {
            if (Session["token"] == null)
                return RedirectToAction("Login", "Login");

            //Client client = new Client();

            //string token = (string)Session["token"];

            //var projects = await client.getProjects(token);

            return View();
        }

        public void setIndex(int pk)
        {
            ViewBag.index = pk;
        }
    }
}