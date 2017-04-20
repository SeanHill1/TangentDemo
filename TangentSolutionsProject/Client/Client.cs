using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using TangentSolutionsProject.Models;
namespace TangentSolutionsProject.Clients
{
    public class Client
    {
        protected HttpClient client { get; private set; } = new HttpClient();
        private String token = null;
        public Client()
        {

        }
        
        public async Task<string> getToken(LoginModel user)
        {
            
            if (this.token != null)
            {
                return this.token;
            }
            Uri uri = new Uri("http://userservice.staging.tangentmicroservices.com:80/api-token-auth/");
            try
            {
                var jsonUser = new JavaScriptSerializer().Serialize(user);
                var httpContent = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync(uri, httpContent);

                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var response = new JavaScriptSerializer().Deserialize<TokenModel>(responseContent);
                    this.token = response.token;
                    return this.token;
                }
                else throw new Exception("No response");

            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public async Task<List<ProjectModel>> getProjects(string token)
        {


           
            Uri uri = new Uri("http://projectservice.staging.tangentmicroservices.com:80/api/v1/projects/");
            try
            {
               
                var httpContent = new StringContent("", Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Token " + token);
                var httpResponse = await client.GetAsync(uri);
                
                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var response = new JavaScriptSerializer().Deserialize<List<ProjectModel>>(responseContent);
                    

                    return response;
                }
                else throw new Exception("No response");

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    

    public async Task<bool> updateProject(string token, ProjectModel proj)
    {


        try
        {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Token " + token);
                var httpContent = new StringContent(new JavaScriptSerializer().Serialize(proj), Encoding.UTF8, "application/json");
                var httpResponse = await client.PutAsync("http://projectservice.staging.tangentmicroservices.com:80/api/v1/projects/" + proj.pk + "/", httpContent);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else throw new Exception("Update Failed");

        }
        catch (Exception e)
        {
            throw e;
        }

    }

        public async Task<bool> deleteProject(string token, int pk)
        {


            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Token " + token);
                var httpResponse = await client.DeleteAsync("http://projectservice.staging.tangentmicroservices.com:80/api/v1/projects/" + pk + "/");

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else throw new Exception("Delete Failed");

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
    
