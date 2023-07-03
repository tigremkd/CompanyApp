using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Contact GetContactsWithCompanyAndCountry();
        List<Contact> FilterContact(int? countryId, int? companyId);
    }
}
