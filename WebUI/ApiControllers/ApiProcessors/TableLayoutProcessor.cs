using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.Models.DataTransferObjects;

namespace WebUI.ApiControllers.ApiProcessors
{
    public class TableLayoutProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }
        public TableLayoutProcessor(string url, string accessToken)
        {
            _url = url + "tablelayout/";
            ApiClient = ApiClientHelper.CreateApiClientWithBearerHeader(ApiClient, accessToken);
        }
        public async Task<ResponseDTO<List<TableLayout>>> GetLayoutsAsync()
        {
            string currentUrl = _url + "getlayouts";
            return await ApiHelper.GetApiResponse<List<TableLayout>>(ApiClient, currentUrl);
        }
        public async Task<ResponseDTO<string>> AddLayoutAsync(IFormFile file)
        {
            string currentUrl = _url + "add";
            string serializeFormat;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileByte = ms.ToArray();
                serializeFormat = Convert.ToBase64String(fileByte);
            }
            return await ApiHelper.PostApiResponse<string,string>(ApiClient, currentUrl, serializeFormat);
        }
    }
}
