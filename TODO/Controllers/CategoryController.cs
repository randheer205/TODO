using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.CategoryData;
using TODO.Models;

namespace TODO.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryInterface _categoryInterface;
        public CategoryController(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetCategory()
        {
            return Ok(_categoryInterface.GetCategories());
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddCategory(Category category)
        {
            _categoryInterface.AddCategory(category);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.Id, category);
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateCategory(int id,Category category)
        {
            var cat=_categoryInterface.GetOneCategory(id);
            if (cat!=null)
            {
                _categoryInterface.UpdateCategory(category);
                return Ok("Category Updated successfully");
            }
            else
            {
                return NotFound("No Category With that ID");
            }
            
        }
    }
}
