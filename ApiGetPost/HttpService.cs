using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


{
    public class HttpService<Entity>
    {
        private const string APIURLNAME = "ApiUrl";
        private const string APIKEYNAME = "ApiKey";
        static string url = string.Empty;
        static HttpClient client = new HttpClient();
        private static IConfiguration _configuration;

        static void LoadUrlKey()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
            //string apikey = _configuration.GetValue<string>(APIKEYNAME);
            url = _configuration.GetValue<string>(APIURLNAME);

            //Burada apikeyin üst üste eklenmemesi için iki yöntemden birini kullanmalısınız.

            #region 1.yöntem
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add(APIKEYNAME, apikey);
            #endregion

            #region 2.yöntem
            //if (!client.DefaultRequestHeaders.Contains(APIKEYNAME))
            //{
            //    client.DefaultRequestHeaders.Add(APIKEYNAME, apikey);
            //} 
            #endregion
        }

        public static async Task<string> Get(string method)// Get isteği
        {
            LoadUrlKey();
            string serviceUrl = $"{url}{method}";
            using (var r = await client.GetAsync(new Uri(serviceUrl)))
                return await r.Content.ReadAsStringAsync();
        }

        public static async Task<string> Post(string method, Entity entity)
        {
            LoadUrlKey();
            string serviceUrl = $"{url}{method}";
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");//göndereceğimiz nesneyi json formatına çeviriyoruz
            using(HttpResponseMessage responseMessage=await client.PostAsync(serviceUrl, httpContent))
            {
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
