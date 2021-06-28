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
    public class ProductProcessor
    {
        string _url;
        public static HttpClient ApiClient { get; private set; }

        public ProductProcessor(string url, string accessToken)
        {
            _url = url + "api/products/";
            ApiClient = ApiClientHelper.CreateApiClientWithBearerHeader(ApiClient, accessToken);
        }

        public async Task<ResponseDTO<List<ProductsDTO>>> GetProductsAsync()
        {
            string currentUrl = _url + "getall";
            return await ApiHelper.GetApiResponse<List<ProductsDTO>>(ApiClient, currentUrl);
        }

        public async Task<ResponseDTO<Product>> GetProductAsync(int productId)
        {
            string currentUrl = _url + "get/productId?productId=" + productId;
            return await ApiHelper.GetApiResponse<Product>(ApiClient, currentUrl);
        }
        public async Task<ResponseDTO<string>> AddProductAsync(Product product)
        {
            string currentUrl = _url + "add";
            return await ApiHelper.PostApiResponse<string, Product>(ApiClient, currentUrl, product);
        }
    }
}
