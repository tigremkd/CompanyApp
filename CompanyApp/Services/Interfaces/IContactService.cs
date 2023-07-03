using Domain.DTOS;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IContactService
    {
        List<ContactDto> GetContacts();
        ContactDto CreateContact(ContactDto contact);
        CompanyDto UpdateContact(ContactDto contact);
        void DeleteContact(int id);
        ContactDto GetContactsWithCompanyAndCountry();
        List<ContactDto> FilterContacts(int countryId, int companyId);
    }
}
