using Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyDto> GetCompanies();
        CompanyDto CreateCompany(CompanyDto company);
        CompanyDto UpdateCompany(CompanyDto company);
        void DeleteCompany(int id);



    }
}
