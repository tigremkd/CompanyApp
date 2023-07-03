using Domain.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CompanyWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var companies = _countryService.GetCountries();
            return Ok(companies);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CountryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CountryDto countryDto)
        {
            _countryService.CreateCountry(countryDto);
            return Ok("Created");
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CountryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] CountryDto countryDto)
        {
            _countryService.UpdateCountry(countryDto);
            return Ok("Edited");
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _countryService.DeleteCountry(id);
            return Ok("Deleted");
        }

    }
}
