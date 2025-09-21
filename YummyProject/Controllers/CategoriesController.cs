using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.CategoryDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var value = _context.Categories.ToList();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(value));
        }
        [HttpGet]
        [Route("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var value=_context.Categories.Find(id);
            return Ok(_mapper.Map<GetByIdCategoryDto>(value));
        }

        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory( CreateCategoryDto category)
        {
            var value=_mapper.Map<Category>(category);
            _context.Categories.Add(value);
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
        public IActionResult UpdateCategory(UpdateCategoryDto category)
        {

            var value=_mapper.Map<Category>(category);
            _context.Categories.Update(value);
            _context.SaveChanges();
            return Ok("güncelleme işlemi başarılı");
        }
        
    }
}
