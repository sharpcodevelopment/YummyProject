using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.ReservationDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            var value = _context.Reservations.ToList();
            return Ok(_mapper.Map<List<ResultReservationDto>>(value));
        }

        [HttpGet]
        [Route("GetReservationById")]
        public IActionResult GetReservationById(int id)
        {
            var value = _context.Reservations.Find(id);
            return Ok(_mapper.Map<GetByIdReservationDto>(value));
        }

        [HttpPost]
        [Route("AddReservation")]
        public IActionResult AddReservation(CreateReservationDto reservation)
        {
            var value = _mapper.Map<Reservation>(reservation);
            _context.Reservations.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        [Route("UpdateReservation")]
        public IActionResult UpdateReservation(UpdateReservationDto reservation)
        {
            var value = _mapper.Map<Reservation>(reservation);
            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}
