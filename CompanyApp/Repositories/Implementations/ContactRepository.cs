using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly ApplicationContext _context;
        public ContactRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public List<Contact> FilterContact(int? countryId, int? companyId)
        {
            var filteredContacts = _context.Contacts.AsQueryable();

            if (countryId.HasValue)
            {
                filteredContacts = filteredContacts.Where(c => c.Country.CountryId == countryId);
            }

            if (companyId.HasValue)
            {
                filteredContacts = filteredContacts.Where(c => c.Company.CompanyId == companyId);
            }

            return filteredContacts.ToList();
        }

        public Contact GetContactsWithCompanyAndCountry()
        {
            var contact = _context.Contacts
                           .Include(c => c.Company)
                           .Include(c => c.Country)
                           .FirstOrDefault();

            return contact;
        }

    }
}
