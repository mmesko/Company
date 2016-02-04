using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Model.Common;
using Company.Common;

namespace Company.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<IEmployee> GetAsync(int id);
        Task<ICollection<IEmployee>> GetRangeAsync(GenericPaging filter);
        Task<ICollection<IEmployee>> GetRangeAsync(GenericPaging filter, string search);
        Task<int> AddAsync(IEmployee emp);
        Task<int> UpdateAsync(IEmployee emp);
        Task<int> DeletAsync(IEmployee emp);
        Task<int> DeleteAsync(int id);
    }
}
