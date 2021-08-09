using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.ApiControllers.ApiProcessors;
using Microsoft.AspNetCore.Authorization;
using WebUI.ApiControllers;

namespace WebUI.Controllers
{
    [Authorize]
    public class OrderDetailController : Controller
    {
        string _url = ApiClientHelper.ApiConnectUrl;
        OrderDetailProcessor _orderDetailProcessor;

        public OrderDetailController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = TokenHelper.GetToken(contextAccessor);
            _orderDetailProcessor = new OrderDetailProcessor(_url,accessToken);

        }

        [HttpPost]
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailProcessor.AddOrderDetailAsync(orderDetail);
        }
    }
}
