using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //--------------------------------------------------------------------------

    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        private IActionResult BaseProcess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int employeeId)
        {
            var result = _employeeService.GetEmployee(employeeId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbypersonid")]
        public IActionResult GetByPersonId(int personId)
        {
            var result = _employeeService.GetEmployeeByPerson(personId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
