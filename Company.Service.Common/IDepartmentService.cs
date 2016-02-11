using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Model.Common;
using Company.Common;

namespace Company.Service.Common
{
    public interface IDepartmentService
    {
        Task<IDepartment> GetAsync(int id);
        Task<ICollection<IDepartment>> GetRangeAsync(GenericPaging filter);
        Task<ICollection<IDepartment>> GetAsync();
        Task<ICollection<IDepartment>> GetRangeAsync(GenericPaging filter, string search);
        Task<int> AddAsync(IDepartment dep);
        Task<int> UpdateAsync(IDepartment dep);
        Task<int> DeleteAsync(IDepartment dep);
        Task<int> DeleteAsync(int id);
    }
}
