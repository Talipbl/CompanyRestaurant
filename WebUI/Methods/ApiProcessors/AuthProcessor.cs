using Core.Utilities.Results.Abstract;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.Methods.ApiProcessors
{
    public class AuthProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public AuthProcessor(string url)
        {
            _url = url + "api/auth/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<EmployeeLoginDTO> LoginAsync(EmployeeLoginDTO employeeLogin)
        {
            string currentUrl = _url + "login";
            return await ApiMethods.PostApiResponse<EmployeeLoginDTO>(ApiClient, currentUrl, employeeLogin);            
        }
    }
}
