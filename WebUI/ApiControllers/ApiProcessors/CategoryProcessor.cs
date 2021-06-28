using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.Models.DataTransferObjects;

namespace WebUI.ApiControllers.ApiProcessors
{
    public class CategoryProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public CategoryProcessor(string url, string accessToken)
        {
            _url = url + "api/categories/";
            ApiClient = ApiClientHelper.CreateApiClientWithBearerHeader(ApiClient, accessToken);
        }

        public async Task<ResponseDTO<List<Category>>> GetCategoriesAsync()
        {
            string currentUrl = _url + "getall";
            return await ApiHelper.GetApiResponse<List<Category>>(ApiClient, currentUrl);
        }
    }
}
