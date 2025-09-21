using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.ImageDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetImages()
        {
            var value = _context.Images.ToList();
            return Ok(_mapper.Map<List<ResultImageDto>>(value));
        }

        [HttpGet]
        [Route("GetImageById")]
        public IActionResult GetImageById(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(_mapper.Map<GetByIdImageDto>(value));
        }

        [HttpPost]
        [Route("AddImage")]
        public IActionResult AddImage(CreateImageDto image)
        {
            var value = _mapper.Map<Image>(image);
            _context.Images.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        [Route("UpdateImage")]
        public IActionResult UpdateImage(UpdateImageDto image)
        {
            var value = _mapper.Map<Image>(image);
            _context.Images.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var value = _context.Images.Find(id);
            _context.Images.Remove(value);
            _context.SaveChanges();
            return Ok("silme işlemi başarılı");
        }



    }
}
