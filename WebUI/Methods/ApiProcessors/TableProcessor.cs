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

        public TableProcessor(string url, string accessToken)
        {
            _url = url + "api/tables/";
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        public async Task<TablesStatusDTO> GetTableStatusAsync()
        {
            string currentUrl = _url + "getstatus";
            return await ApiMethod.GetApiResponse<TablesStatusDTO>(ApiClient, currentUrl);
        }

        public async Task<List<Table>> GetTableFilterStatusAsync(bool status)
        {
            string currentUrl = _url + "gettablesfilterstatus";
            return await ApiMethod.GetApiResponse<List<Table>>(ApiClient, currentUrl);
        }

        public async Task<List<Table>> GetTables()
        {
            string currentUrl = _url + "gettables";
            return await ApiMethod.GetApiResponse<List<Table>>(ApiClient, currentUrl);
        }
    }
}
