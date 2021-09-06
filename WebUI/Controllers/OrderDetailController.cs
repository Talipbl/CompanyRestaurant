using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.ApiControllers;
using WebUI.ApiControllers.ApiProcessors;
using WebUI.Methods;
using WebUI.Models.ViewModels;

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
        [HttpGet]
        public async Task<ActionResult> ListOrderDetails(int orderId)
        {
            var result = await _orderDetailProcessor.GetOrderDetailsAsync(orderId);
            if (result.ResponseMessage.IsSuccessStatusCode)
            {
                OrderDetailsViewModel model = new OrderDetailsViewModel
                {
                    OrderDetails = result.Entity
                };
                return View(model);
            }
            ModelState.AddModelError("", result.ResponseMessage.ReasonPhrase);
            return RedirectToAction("ListOrders", "Order");
        }
    }
}
