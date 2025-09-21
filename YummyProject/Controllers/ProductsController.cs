using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.ProductDtos;
using YummyProject.API.Entities.Models;
using YummyProject.API.ValidationRules;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Product> _validator;
       

        public ProductsController(ApiContext context, IMapper mapper, IValidator<Product> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var value = _context.Products.ToList();
            return Ok(_mapper.Map<List<ResultProductDto>>(value));
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(_mapper.Map<GetByIdProductDto>(value));
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(CreateProductDto product)
        {
            var value = _mapper.Map<Product>(product);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductDto product)
        {
            var value = _mapper.Map<Product>(product);
            _context.Products.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("silme işlemi başarılı");
        }
    }
}
