using System;
using System.Collections.Generic;

namespace Company.DAL.Models
{
    public partial class Department
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        }

        public int departmentNo { get; set; }
        public string departmentName { get; set; }
        public string departmentLocation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
