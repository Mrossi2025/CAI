using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Policy;
using Newtonsoft.Json;
using Persistencia.utils;


namespace Persistencia.utils
{
    public class WebHelper
    {
        static HttpClient httpClient = new HttpClient();
        static string rutaBase = "https://uba-cai.onrender.com/";

        public static HttpResponseMessage Get(string url)
        {
            var uri = rutaBase + url;

            HttpResponseMessage response = httpClient.GetAsync(uri).Result;

            return response;

        }
        
        public static HttpResponseMessage Post(string url, string jsonRequest)
        {
            var uri = rutaBase + url;
            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(uri, data).Result;
            return response;
        }

        public static HttpResponseMessage Put(string url, string jsonRequest)
        {
            var uri = rutaBase + url;
            var data = new StringContent(jsonRequest, encoding: Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(uri, data).Result;
            return response;


        }

        public static HttpResponseMessage Patch(string path, string jsonRequest)
        {
            var uri = rutaBase + path;

            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), uri)
            {
                Content = data
            };

            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }

        public static HttpResponseMessage Delete(string url)
        {
            var uri = rutaBase + url;
            HttpResponseMessage response = httpClient.DeleteAsync(uri).Result;
            return response;


        }


    }
}
