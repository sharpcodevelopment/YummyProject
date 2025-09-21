using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.FeatureDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeatures()
        {
            var value = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(value));
        }

        [HttpGet]
        [Route("GetFeatureById")]
        public IActionResult GetFeatureById(int id)
        {
            var value = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }

        [HttpPost]
        [Route("AddFeature")]
        public IActionResult AddFeature(CreateFeatureDto feature)
        {
            var value = _mapper.Map<Feature>(feature);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        [Route("UpdateFeature")]
        public IActionResult UpdateFeature(UpdateFeatureDto feature)
        {
            var value = _mapper.Map<Feature>(feature);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("silme işlemi başarılı");
        }
    }
}
