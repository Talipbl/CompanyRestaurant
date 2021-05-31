using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebUI.Methods.ApiProcessors
{
    public class TableProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public TableProcessor(string url)
        {
            _url = url + "api/tables/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TablesStatusDTO> GetTableStatusAsync()
        {
            string currentUrl = _url + "getstatus";
            return await ApiMethods.GetApiResponse<TablesStatusDTO>(ApiClient, currentUrl);
        }
    }
}
