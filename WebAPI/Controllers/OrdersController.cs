using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        private IActionResult BaseProcess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getordersamount")]
        public IActionResult GetTotalOrderAmount()
        {
            var result = _orderService.GetTotalOrderAmountByDateTime(DateTime.Now.Day);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlastorders")]
        public IActionResult GetLastOrders(int takeValue = 10)
        {
            var result = _orderService.GetLastOrders(takeValue);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddOrder(Order order)
        {
            return BaseProcess(_orderService.Add(order));
        }
        [HttpPost("update")]
        public IActionResult Update(Order order)
        {
            return BaseProcess(_orderService.Update(order));
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            return BaseProcess(_orderService.Delete(id));
        }
        [HttpGet("getorderbytime")]
        public IActionResult GetOrderByDateTime(DateTimeDTO dateTime)
        {
            var result = _orderService.GetOrderByDateTime(dateTime.DateTime);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlastorder")]
        public IActionResult GetLastOrder()
        {
            var result = _orderService.GetLastOrder();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
