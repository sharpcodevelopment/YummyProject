using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_context.Categories.ToList());
        }
        [HttpGet]
        [Route("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var value=_context.Categories.Find(id);
            return Ok(value);
        }

        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory( Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("silme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("güncelleme işlemi başarılı");
        }
        
    }
}
