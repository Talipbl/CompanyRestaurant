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

        public async Task<string> SetStatusAsync(Table table)
        {
            string currentUrl = _url + "setstatus";
            return await ApiMethod.PostApiResponse<string, Table>(ApiClient, currentUrl, table);
        }

        public async Task<Table> GetTableAsync(int tableId)
        {
            string currentUrl = _url + "gettable?tableId=" + tableId;
            return await ApiMethod.GetApiResponse<Table>(ApiClient, currentUrl);
        }

        public async Task<string> AddTableAsync(Table table)
        {
            string currentUrl = _url + "addtable";
            return await ApiMethod.PostApiResponse<string, Table>(ApiClient, currentUrl, table);
        }

    }
}
