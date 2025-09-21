using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.TestimonialDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TestimonialsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTestimonials()
        {
            var value = _context.Testimonials.ToList();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(value));
        }

        [HttpGet]
        [Route("GetTestimonialById")]
        public IActionResult GetTestimonialById(int id)
        {
            var value = _context.Testimonials.Find(id);
            return Ok(_mapper.Map<GetByIdTestimonialDto>(value));
        }

        [HttpPost]
        [Route("AddTestimonial")]
        public IActionResult AddTestimonial(CreateTestimonialDto testimonial)
        {
            var value = _mapper.Map<Testimonial>(testimonial);
            _context.Testimonials.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        [Route("UpdateTestimonial")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto testimonial)
        {
            var value = _mapper.Map<Testimonial>(testimonial);
            _context.Testimonials.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}
