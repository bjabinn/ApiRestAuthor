using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace AplicacionConsola
{
    class ServiceClientAuthors
    {
        static HttpClient client = new HttpClient();

        public List<Author> GetAuthors()
        {
            var authors = new List<Author>();
            HttpResponseMessage response = client.GetAsync("http://localhost:21496/api/authors").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                // by calling .Result you are synchronously reading the result
                string responseString = responseContent.ReadAsStringAsync().Result;
                authors = JsonConvert.DeserializeObject<List<Author>>(responseString);
            }
            return authors;
        }
    }
}
