using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Newtonsoft.Json;
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
    public class TableProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public TableProcessor(string url, string accessToken)
        {
            _url = url + "tables/";
            ApiClient = ApiClientHelper.CreateApiClientWithBearerHeader(ApiClient, accessToken);
        }

        public async Task<ResponseDTO<TablesStatusDTO>> GetTableStatusAsync()
        {
            string currentUrl = _url + "getstatus";
            return await ApiHelper.GetApiResponse<TablesStatusDTO>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<List<Table>>> GetTableFilterStatusAsync(bool status)
        {
            string currentUrl = _url + "gettablesfilterstatus";
            return await ApiHelper.GetApiResponse<List<Table>>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<List<Table>>> GetTables()
        {
            string currentUrl = _url + "gettables";
            return await ApiHelper.GetApiResponse<List<Table>>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<string>> SetStatusAsync(Table table)
        {
            string currentUrl = _url + "setstatus";
            return await ApiHelper.PostApiResponse<string, Table>(ApiClient, currentUrl, table);
        }

        public async Task<ResponseDTO<Table>> GetTableAsync(int tableId)
        {
            string currentUrl = _url + "gettable?tableId=" + tableId;
            return await ApiHelper.GetApiResponse<Table>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<string>> AddTableAsync(Table table)
        {
            string currentUrl = _url + "addtable";
            return await ApiHelper.PostApiResponse<string, Table>(ApiClient, currentUrl, table);
        }

    }
}
