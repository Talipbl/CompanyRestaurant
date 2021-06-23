using Core.Utilities.Results.Abstract;
using Entities.Concrete.DataTransferObject;
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
    public class AuthProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public AuthProcessor(string url)
        {
            _url = url + "api/auth/";
            ApiClient = ApiClientHelper.CreateApiClient(ApiClient);
        }

        public async Task<ResponseDTO<EmployeeSessionDTO>> LoginAsync(EmployeeLoginDTO employeeLogin)
        {
            string currentUrl = _url + "login";
            return await ApiHelper.PostApiResponse<EmployeeSessionDTO,EmployeeLoginDTO>(ApiClient, currentUrl, employeeLogin);
        }
    }
}
