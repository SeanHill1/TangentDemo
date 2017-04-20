using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TangentSolutionsProject.Models;
using TangentSolutionsProject.Clients;

namespace TangentSolutionsProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel user)
        {
            ////Set up the data for the HttpClient to POST
            //var uri = new Uri("http://userservice.staging.tangentmicroservices.com:80/api-token-auth/");

            
            Client client = new Client();
          
            try
            {
                if (Session["token"] == null)
                {
                    string token = await client.getToken(user);
                    Session["token"] = token;
                }
                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }


}