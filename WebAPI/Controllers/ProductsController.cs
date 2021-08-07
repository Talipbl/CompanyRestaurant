using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Concrete.Managers;
using Core.Entities.DataTransferObject;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductsController : Controller
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        private IActionResult BaseProcess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int productId)
        {
            var result = _productService.GetProduct(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetProducts();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            return BaseProcess(_productService.Add(product));
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            return BaseProcess(_productService.Update(product));
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            return BaseProcess(_productService.Delete(id));
        }
    }
}
