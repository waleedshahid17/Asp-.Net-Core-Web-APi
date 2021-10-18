using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Repository.RepositoryBase<Entities.Models.Company>;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositorycontext;
        private ICompanyRepository companyRepository;
        private IEmployeeRepository employeeRepository;

        public RepositoryManager(RepositoryContext repositorycontext)
        {
            _repositorycontext = repositorycontext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if (companyRepository == null)
                {
                    companyRepository = new CompanyRepository(_repositorycontext);
                }
                return companyRepository;
            }
        }        
        public IEmployeeRepository Employee
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(_repositorycontext);
                }
                return employeeRepository;
            }
        }

        public Task SaveAsync() => _repositorycontext.SaveChangesAsync();

        
    }
}
