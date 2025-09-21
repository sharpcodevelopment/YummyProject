using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.ChefDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ChefsController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetChefs()
        {
            var value = _context.Chefs.ToList();
            return Ok(_mapper.Map<List<ResultChefDto>>(value));
        }
        [HttpGet]
        [Route("GetChefById")]
        public IActionResult GetChefById(int id)
        {
            var value = _context.Chefs.Find(id);
            return Ok(_mapper.Map<GetByIdChefDto>(value));
        }

        [HttpPost("AddChef")]
        public IActionResult AddChef(CreateChefDto createChefDto)
        {
            var newChef = _mapper.Map<Chef>(createChefDto);
            _context.Chefs.Add(newChef);
            _context.SaveChanges();
            return Ok("new chef added");
        }
        [HttpPut("UpdateChef")]
        public IActionResult UpdateChef(UpdateChefDto chefs)
        {
            var chef = _mapper.Map<Chef>(chefs);
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Chef update success");
        }

        [HttpDelete("DeleteChef")]
        public IActionResult DeleteChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok("Chef Deleted");
        }

    }
}
