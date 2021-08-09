using Business.Abstract;
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
    public class TablesController : ControllerBase
    {
        ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("getstatus")]
        public IActionResult GetTableStatus()
        {
            var result = _tableService.GetTableCapacity();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("gettablesfilterstatus")]
        public IActionResult GetTablesFilterStatus(bool statu)
        {
            var result = _tableService.GetTableFilterStatus(statu);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("gettables")]
        public IActionResult GetTables()
        {
            var result = _tableService.GetTables();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("setstatus")]
        public IActionResult SetStatus(Table table)
        {
            var result = _tableService.Update(table);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("gettable")]
        public IActionResult GetTable(int tableId)
        {
            var result = _tableService.GetTable(tableId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPost("addtable")]
        public IActionResult AddTable(Table table)
        {
            var result = _tableService.Add(table);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        
    }
}
