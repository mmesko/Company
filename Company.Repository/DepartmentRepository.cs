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

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IRepository repository;

        public DepartmentRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #region Methods

        public async Task<Model.Common.IDepartment> GetAsync(int id)
        {
            try
            {
                return Mapper.Map<IDepartment>(await repository.Where<Department>()
                    .FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<Model.Common.IDepartment>> GetRangeAsync(GenericPaging filter)
        {
            try
            {
                if (filter == null)
                    filter = new GenericPaging(1, 5);

                return Mapper.Map<ICollection<IDepartment>>(await repository.Where<Department>()
                    .OrderBy(t => t.departmentName)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<IDepartment>> GetRangeAsync(GenericPaging filter, string search)
        {
            try
            {
                if (filter == null)
                    filter = new GenericPaging(1, 5);

                return Mapper.Map<ICollection<IDepartment>>(await repository.Where<Department>()
                    .Where(t => t.departmentName.Contains(search))
                    .OrderBy(t => t.departmentName)
                    .Skip((filter.PageNumber * filter.PageSize) - filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Task<int> AddAsync(Model.Common.IDepartment dep)
        {
            try
            {
                return repository.AddAsync<Department>(Mapper.Map<Department>(dep));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<int> UpdateAsync(Model.Common.IDepartment dep)
        {
            try
            {
                return repository.UpdateAsync<Department>(Mapper.Map<Department>(dep));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> DeletAsync(Model.Common.IDepartment dep)
        {
            try
            {
                return await repository.DeleteAsync<Department>(Mapper.Map<Department>(dep));
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
                return await repository.DeleteAsync<Department>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}