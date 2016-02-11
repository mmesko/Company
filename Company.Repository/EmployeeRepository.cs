using AutoMapper;
using Company.Common;
using Company.DAL.Models;
using Company.Model.Common;
using Company.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Repository
{
    
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IRepository repository;

        public EmployeeRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #region Methods



        public async Task<Model.Common.IEmployee> GetAsync(int id)
        {
            try
            {
                return Mapper.Map<IEmployee>(await repository.Where<Employee>()
                    .SingleAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Model.Common.IEmployee>> GetRangeAsync(GenericPaging filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericPaging(1, 5);

                return Mapper.Map<ICollection<IEmployee>>(await repository.Where<Employee>()
                    .OrderBy(t => t.employeeName)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<IEmployee>> GetRangeAsync(GenericPaging filter, string search)
        {
            try
            {
                if (filter == null)
                    filter = new GenericPaging(1, 5);

                return Mapper.Map<ICollection<IEmployee>>(await repository.Where<Employee>()
                    .Where(t => t.employeeName.Contains(search))
                    .OrderBy(t => t.employeeName)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Task<int> AddAsync(Model.Common.IEmployee emp)
        {
            try
            {
                return repository.AddAsync<Employee>(Mapper.Map<Employee>(emp));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<int> UpdateAsync(Model.Common.IEmployee emp)
        {
            try
            {
                return repository.UpdateAsync<Employee>(Mapper.Map<Employee>(emp));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> DeletAsync(Model.Common.IEmployee emp)
        {
            try
            {
                return await repository.DeleteAsync<Employee>(Mapper.Map<Employee>(emp));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                return await repository.DeleteAsync<Employee>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}