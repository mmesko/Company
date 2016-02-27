

using System;
using System.Collections.Generic;

namespace Company.DAL.Models
{
    public partial class Employee
    {

        public int employeeNo { get; set; }

        public int departmentNo { get; set; }

        public string employeeName { get; set; }

        public decimal salary { get; set; }

        public Nullable<System.DateTime> lastModifyDate { get; set; }

        public virtual Department Department { get; set; }

    }
}
