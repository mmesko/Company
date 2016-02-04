using Company.Common;
using Company.Model.Common;
using Company.Repository.Common;
using Company.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

      
        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        #region Methods
       
        public async Task<IEmployee> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<ICollection<Model.Common.IEmployee>> GetRangeAsync(GenericPaging filter)
        {
            return await repository.GetRangeAsync(filter);
        }


        public async Task<ICollection<IEmployee>> GetRangeAsync(GenericPaging filter, string search)
        {
            return await repository.GetRangeAsync(filter, search);
        }


        public async Task<int> AddAsync(Model.Common.IEmployee emp)
        {
            return await repository.AddAsync(emp);
        }

        public Task<int> UpdateAsync(Model.Common.IEmployee emp)
        {
            return repository.UpdateAsync(emp);
        }


        public async Task<int> DeleteAsync(Model.Common.IEmployee emp)
        {
            try
            {
                return await repository.DeletAsync(emp);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                return await repository.DeleteAsync(id);
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}