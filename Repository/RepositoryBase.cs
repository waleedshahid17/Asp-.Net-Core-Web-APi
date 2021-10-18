using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {

            RepositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Findall(bool trackChanges) =>
            !trackChanges ?
            RepositoryContext.Set<T>()
            .AsNoTracking() :
            RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
             bool trackChanges) =>
             !trackChanges ?
             RepositoryContext.Set<T>()
             .Where(expression)
             .AsNoTracking() :
             RepositoryContext.Set<T>()
             .Where(expression);

        public void Update(T entity)
        {

            RepositoryContext.Set<T>().Update(entity);
        }
        public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
        {
            public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
            {
            }

            public async Task<List<Company>> GetAllCompaniesAsync(bool trackChanges) =>
             await Findall(trackChanges)
             .OrderBy(c => c.name)
             .ToListAsync();

            public async Task<Company> GetOneCompanyAsync(Guid companyID, bool trackChanges) =>
                await FindByCondition(c => c.id == companyID, trackChanges).SingleOrDefaultAsync();
            public void CreateCompany(Company company) => Create(company);
            public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
             await FindByCondition(x => ids.Contains(x.id), trackChanges)
             .ToListAsync();

            public void DeleteCompany(Company company)
            {
                Delete(company);
            }
                    }
        public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
        {
            public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
            {
            }

            public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,
            EmployeeParameters employeeParameters, bool trackChanges)
            {
                var employees = await FindByCondition(e => e.CompanyID.Equals(companyId),
                trackChanges)
                .FilterEmployees(employeeParameters.minAge, employeeParameters.maxAge)
                .Search(employeeParameters.searchTerm).OrderBy(e => e.name)
                .Sort(employeeParameters.OrderBy)
                .ToListAsync();

                return PagedList<Employee>
                .ToPagedList(employees, employeeParameters.PageNumber,
               employeeParameters.PageSize);
            }
            public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
                await FindByCondition(e => e.CompanyID.Equals(companyId) && e.id.Equals(id), trackChanges).SingleOrDefaultAsync();
            public void CreateEmployeeForCompany(Guid companyId, Employee employee)
            {
                employee.CompanyID = companyId;
                Create(employee);
            }
            public void DeleteEmployee(Employee employee)
            {
                Delete(employee);
            }
        }
        
    }
}
