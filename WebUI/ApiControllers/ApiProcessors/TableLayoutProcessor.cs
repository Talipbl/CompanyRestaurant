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
        public async Task<ResponseDTO<string>> AddLayoutAsync(IFormFile file, string directory = null)
        {
            string currentUrl = _url + "add?directory=" + directory;
            byte[] fileByte;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileByte = ms.ToArray();
            }

            return await ApiHelper.PostMultipartFormApiResponse<string>(ApiClient, currentUrl, fileByte, file.FileName);
        }
    }
}
