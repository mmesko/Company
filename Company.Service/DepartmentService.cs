using Company.Common;
using Company.Model.Common;
using Company.Repository.Common;
using Company.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository repository;


        public DepartmentService(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        #region Methods

        public async Task<IDepartment> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<ICollection<IDepartment>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<ICollection<Model.Common.IDepartment>> GetRangeAsync(GenericPaging filter)
        {
            return await repository.GetRangeAsync(filter);
        }


        public async Task<ICollection<IDepartment>> GetRangeAsync(GenericPaging filter, string search)
        {
            return await repository.GetRangeAsync(filter, search);
        }


        public async Task<int> AddAsync(Model.Common.IDepartment dep)
        {
            return await repository.AddAsync(dep);
        }

        public Task<int> UpdateAsync(Model.Common.IDepartment dep)
        {
            return repository.UpdateAsync(dep);
        }


        public async Task<int> DeleteAsync(Model.Common.IDepartment dep)
        {
            try
            {
                return await repository.DeletAsync(dep);
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