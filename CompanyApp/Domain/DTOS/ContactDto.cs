using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }

        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
