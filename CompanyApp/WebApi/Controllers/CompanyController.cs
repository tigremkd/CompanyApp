using Domain.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CompanyWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CompanyDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var companies = _companyService.GetCompanies();
            return Ok(companies);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CompanyDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CompanyDto companyDto)
        {
            _companyService.CreateCompany(companyDto);
            return Ok("Created");
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CompanyDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] CompanyDto companyDto)
        {
            _companyService.UpdateCompany(companyDto);
            return Ok("Edited");
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _companyService.DeleteCompany(id);
            return Ok("Deleted");
        }

    }
}
