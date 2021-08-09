using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.Models.DataTransferObjects;

namespace WebUI.ApiControllers.ApiProcessors
{
    public class PersonProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public PersonProcessor(string url, string accessToken)
        {
            _url = url + "persons/";
            ApiClient = ApiClientHelper.CreateApiClientWithBearerHeader(ApiClient, accessToken);
        }

        public async Task<ResponseDTO<Person>> GetPerson(int personId)
        {
            string currentUrl = _url + "getperson";
            return await ApiHelper.GetApiResponse<Person>(ApiClient, currentUrl);
        }

    }
}
