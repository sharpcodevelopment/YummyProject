using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.ServiceDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ServicesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            var value = _context.Services.ToList();
            return Ok(_mapper.Map<List<ResultServiceDto>>(value));
        }

        [HttpGet]
        [Route("GetServiceById")]
        public IActionResult GetServiceById(int id)
        {
            var value = _context.Services.Find(id);
            return Ok(_mapper.Map<GetByIdServiceDto>(value));
        }

        [HttpPost]
        [Route("AddService")]
        public IActionResult AddService(CreateServiceDto service)
        {
            var value = _mapper.Map<Service>(service);
            _context.Services.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        [Route("UpdateService")]
        public IActionResult UpdateService(UpdateServiceDto service)
        {
            var value = _mapper.Map<Service>(service);
            _context.Services.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}
