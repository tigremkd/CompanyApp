using AutoMapper;
using Domain.DTOS;
using Domain.Models;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IContactRepository contactRepository, ICountryRepository countryRepository,ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _companyRepository= companyRepository;
            _countryRepository= countryRepository;
        }

        public ContactDto CreateContact(ContactDto contact)
        {
            try
            {
                var company = _companyRepository.Get(contact.CompanyId);
                var country = _countryRepository.Get(contact.CountryId);

                if(company is null || country is null)
                {
                    throw new Exception("Failed to create contact");
                }


                var newContact = new Contact
                {
                    ContactName = contact.ContactName,
                    CountryId = contact.CountryId,
                    CompanyId = contact.CompanyId,
                    Company = company,
                    Country = country
                };

                var createdContact = _contactRepository.Create(newContact);
                return _mapper.Map<ContactDto>(createdContact);
            }

            // Exception handling should be from most specific > global
            catch (Exception ex)
            {
                throw new Exception("Failed to create contact", ex);
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                var contact = _contactRepository.Get(id);

                if (contact is null)
                {
                    throw new Exception($"Contact with ID {id} not found");
                }

                _contactRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete contact", ex);
            }
        }

        public List<ContactDto> FilterContacts(int? countryId, int? companyId)
        {
            var contacts = _contactRepository.FilterContact(countryId, companyId);
            return _mapper.Map<List<ContactDto>>(contacts);
        }

        public List<ContactDto> GetContacts()
        {
            try
            {
                var contacts = _contactRepository.GetAll();
                return _mapper.Map<List<ContactDto>>(contacts);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get contacts", ex);
            }
        }

        public ContactDto GetContactsWithCompanyAndCountry()
        {
            try
            {
                var contact = _contactRepository.GetContactsWithCompanyAndCountry();
                return _mapper.Map<ContactDto>(contact);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get contact with company and ID", ex);
            }
        }

        public CompanyDto UpdateContact(ContactDto contact)
        {
            try
            {
                var model = _mapper.Map<Contact>(contact);

                var updatedCompany = _contactRepository.Update(model);
                return _mapper.Map<CompanyDto>(updatedCompany);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact", ex);
            }
        }
    }
}
