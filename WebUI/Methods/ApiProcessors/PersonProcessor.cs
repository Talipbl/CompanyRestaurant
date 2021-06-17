using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.Methods.ApiProcessors
{
    public class PersonProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public PersonProcessor(string url, string accessToken)
        {
            _url = url + "api/persons/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        public async Task<Person> GetPerson(int personId)
        {
            string currentUrl = _url + "getperson";
            return await ApiMethod.GetApiResponse<Person>(ApiClient, currentUrl);
        }

    }
}
