using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableLayoutController : ControllerBase
    {
        ITableLayoutService _tableLayoutService;
        public TableLayoutController(ITableLayoutService tableLayoutService)
        {
            _tableLayoutService = tableLayoutService;
        }

        [HttpGet("getlayouts")]
        public IActionResult GetLayouts()
        {
            var result = _tableLayoutService.GetLayouts();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("upload")]
        public IActionResult UploadLayouts(IFormFile file, string directory = null)
        {
            var result = _tableLayoutService.Upload(file, directory);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("add")]
        public IActionResult AddLayouts(string directory = null)
        {
            var result = _tableLayoutService.Add(directory);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
