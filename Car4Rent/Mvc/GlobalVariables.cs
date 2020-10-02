using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
namespace Mvc
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:50953/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
           /* WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/octet-stream"));*/

        }
    }
}