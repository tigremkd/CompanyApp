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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public CompanyDto CreateCompany(CompanyDto company)
        {
            try
            {
                var model = _companyRepository.Create(_mapper.Map<Company>(company));
                return _mapper.Map<CompanyDto>(model);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create company", ex);
            }
        }

        public void DeleteCompany(int id)
        {
            try
            {
                var company = _companyRepository.Get(id);

                if (company is null)
                {
                    throw new Exception($"Company with ID {id} not found");
                }

                _companyRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete company", ex);
            }
        }

        public List<CompanyDto> GetCompanies()
        {
            try
            {
                var companies = _companyRepository.GetAll();
                return _mapper.Map<List<CompanyDto>>(companies);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get companies", ex);
            }
        }

        public CompanyDto UpdateCompany(CompanyDto company)
        {
            try
            {
                var model = _companyRepository.Get(company.CompanyId);

                if (model is null)
                {
                    throw new Exception($"Company with ID {company.CompanyId} not found");
                }

                _companyRepository.Update(_mapper.Map<Company>(model));
                return _mapper.Map<CompanyDto>(model);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update company", ex);
            }
        }
    }
}
