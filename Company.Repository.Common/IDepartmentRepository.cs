using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Model.Common;
using Company.Common;

namespace Company.Repository.Common
{
   public interface IDepartmentRepository
    {
        Task<IDepartment> GetAsync(int id);
        Task<ICollection<IDepartment>> GetRangeAsync(GenericPaging filter);
        Task<ICollection<IDepartment>> GetRangeAsync(GenericPaging filter, string search);
        Task<int> AddAsync(IDepartment dep);
        Task<int> UpdateAsync(IDepartment dep);
        Task<int> DeletAsync(IDepartment dep);
        Task<int> DeleteAsync(int id);
    }
}
