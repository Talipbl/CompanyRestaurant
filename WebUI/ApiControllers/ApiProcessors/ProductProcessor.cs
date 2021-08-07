using Core.Entities.DataTransferObject;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using FluentValidation.Results;
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
        public async Task<ResponseDTO<ValidationDataResult>> AddProductAsync(Product product)
        {
            string currentUrl = _url + "add";
            var result =  await ApiHelper.PostApiResponse<ValidationDataResult, Product>(ApiClient, currentUrl, product);
            return result;
        }
        public async Task<ResponseDTO<Result>> DeleteProductAsync(int id)
        {
            string currentUrl = $"{_url}delete?id={id}";
            var result = await ApiHelper.GetApiResponse<Result>(ApiClient, currentUrl);
            return result;
        }
        public async Task<ResponseDTO<Result>> UpdateProductAsync(Product product)
        {
            string currentUrl = $"{_url}update";
            var result = await ApiHelper.PostApiResponse<Result,Product>(ApiClient, currentUrl,product);
            return result;
        }
    }
}
