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
        public async Task<ResponseDTO<string>> UploadLayoutAsync(IFormFile file, string directory = null)
        {
            string serverUrl = directory;
            byte[] fileByte;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileByte = ms.ToArray();
            }
            var apiResult = await ApiHelper.PostMultipartFormApiResponse(ApiClient, serverUrl, fileByte, file.FileName);
            string currentUrl = _url + "add?directory=" + apiResult.Entity;
            if (apiResult.ResponseMessage.IsSuccessStatusCode)
            {
                var localResult = await ApiHelper.GetApiResponse<string>(ApiClient, currentUrl);
                return localResult;
            }
            return apiResult;
        }
    }
}
