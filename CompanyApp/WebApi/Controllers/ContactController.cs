using Domain.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CompanyWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContactDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetContacts();
            return Ok(contacts);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContactDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] ContactDto contactDto)
        {
            _contactService.CreateContact(contactDto);
            return Ok("Created");
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContactDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ContactDto contactDto)
        {
            _contactService.UpdateContact(contactDto);
            return Ok("Edited");
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return Ok("Deleted");
        }

        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFilteredContacts([FromQuery] int countryId, [FromQuery] int companyId)
        {
            if (countryId <= 0 || companyId <= 0)
            {
                return BadRequest("Invalid countryId or companyId"); // 400 Bad Request
            }

            var contacts = _contactService.FilterContacts(countryId, companyId);
            return Ok(contacts); // 200 OK
        }

        [HttpGet("full-contacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetContactsWithCompanyAndCountry()
        {
            var contacts = _contactService.GetContactsWithCompanyAndCountry();
            return Ok(contacts);
        }
    }
}
