using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailsController : Controller
    {
        IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        private IActionResult BaseProcess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddOrderDetails(OrderDetail orderDetail)
        {
            return BaseProcess(_orderDetailService.Add(orderDetail));
        }

        [HttpGet("getdetails")]
        public IActionResult GetOrderDetails(int orderId)
        {
            var result = _orderDetailService.GetOrderDetailWithJoins(orderId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
    }
}
