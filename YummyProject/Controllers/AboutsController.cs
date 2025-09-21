using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.AboutDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AboutsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAbouts()
        {
            var value = _context.Abouts.ToList();
            return Ok(_mapper.Map<ResultAboutDto>(value));
        }

        [HttpGet]
        [Route("GetAboutById")]
        public IActionResult GetAboutById(int id)
        {
            var value = _context.Abouts.Find(id);
            return Ok(_mapper.Map<GetByIdAboutDto>(value));
        }

        [HttpPost]
        [Route("AddAbout")]
        public IActionResult AddAbout(CreateAboutDto about)
        {
            var value = _mapper.Map<About>(about);
            _context.Abouts.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("silme işlemi başarılı");
        }
    }
}
