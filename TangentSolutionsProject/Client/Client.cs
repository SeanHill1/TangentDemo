﻿using System;
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
        
        public async Task<bool> getToken(LoginModel user)
        {
            
            if (this.token != null)
            {
                return true;
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
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Token "+this.token);
                    return true;
                }
                else throw new Exception("No response");

            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public async Task<List<ProjectModel>> getProjects(string token = null)
        {


           
            Uri uri = new Uri("http://projectservice.staging.tangentmicroservices.com:80/api/v1/projects/");
            try
            {
               
                var httpContent = new StringContent("", Encoding.UTF8, "application/json");

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
    }
}
    
