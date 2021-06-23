using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.ApiControllers.ApiProcessors;

namespace WebUI.Controllers
{
    public class OrderDetailController : Controller
    {
        string _url = "https://localhost:44396/";
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
