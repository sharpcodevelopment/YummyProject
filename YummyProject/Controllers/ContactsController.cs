
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyProject.API.Context;
using YummyProject.API.Dtos.ContactDtos;
using YummyProject.API.Entities.Models;

namespace YummyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ContactsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var value = _context.Contacts.ToList();
            return Ok(_mapper.Map<List<ResultContactDto>>(value));
        }
        [HttpGet]
        [Route("GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(_mapper.Map<GetByIdContactDto>(value));
        }
        [HttpPost]
        [Route("AddContact")]
        public IActionResult AddContact(CreateContactDto contact)
        {
            var value = _mapper.Map<Contact>(contact);
            _context.Contacts.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpPut]
        [Route("UpdateContact")]
        public IActionResult UpdateContact(UpdateContactDto contact)
        {
            var value = _mapper.Map<Contact>(contact);
            _context.Contacts.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("silme işlemi başarılı");
        }
    }
}
