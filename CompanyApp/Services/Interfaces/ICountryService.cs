using Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICountryService
    {
        List<CountryDto> GetCountries();
        CountryDto CreateCountry(CountryDto country);
        CountryDto UpdateCountry(CountryDto country);
        void DeleteCountry(int id);
    }
}
