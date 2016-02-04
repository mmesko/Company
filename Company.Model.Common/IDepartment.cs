using System.Collections.Generic;

namespace Company.Model.Common
{
    public interface IDepartment
    {
        int departmentNo { get; set; }
        string departmentName { get; set; }
        string departmentLocation { get; set; }
        ICollection<IEmployee> Employees { get; set; }
    }
}
