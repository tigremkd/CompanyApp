using AutoMapper;
using Domain.DTOS;
using Domain.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public CountryDto CreateCountry(CountryDto country)
        {
            try
            {
                // should add a method to check if the country with that name already exsists before creating a new one 

                var model = _mapper.Map<Country>(country);
                var createdCountry = _countryRepository.Create(model);
                return _mapper.Map<CountryDto>(createdCountry);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create country", ex);
            }
        }

        public void DeleteCountry(int id)
        {
            try
            {
                var country = _countryRepository.Get(id);

                if (country is null)
                {
                    throw new Exception($"Country with ID {id} not found");
                }

                _countryRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete country", ex);
            }
        }

        public List<CountryDto> GetCountries()
        {
            try
            {
                var countries = _countryRepository.GetAll();
                return _mapper.Map<List<CountryDto>>(countries);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get countries", ex);
            }
        }

        public CountryDto UpdateCountry(CountryDto country)
        {
            try
            {
                var model = _mapper.Map<Country>(country);

                var updatedCountry = _countryRepository.Update(model);
                return _mapper.Map<CountryDto>(updatedCountry);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update country", ex);
            }
        }
    }
}
