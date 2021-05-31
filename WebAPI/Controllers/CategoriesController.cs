using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //--------------------------------------------------------------------------

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
        public IActionResult Get(int categoryId)
        {
            var result = _categoryService.GetCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetCategories();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            return BaseProcess(_categoryService.Add(category));
        }
        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            return BaseProcess(_categoryService.Update(category));
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            return BaseProcess(_categoryService.Delete(id));
        }
    }


    //----------------------------------------------------------------

}
