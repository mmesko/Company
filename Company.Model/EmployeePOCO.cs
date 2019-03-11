using Company.Model.Common;
using System;

namespace Company.Model
{
   public class EmployeePOCO: IEmployee
    {
        public int employeeNo { get; set; }
        public int departmentNo { get; set; }
        public string employeeName { get; set; }
        public decimal salary { get; set; }
        public string employeeStatus { get; set; }

        public Nullable<System.DateTime> lastModifyDate { get; set; }
        public IDepartment Department { get; set; }
    }
}
