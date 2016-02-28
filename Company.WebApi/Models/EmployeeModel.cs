
using System;
namespace Company.WebApi.Models
{
    public class EmployeeModel
    {
        public int employeeNo { get; set; }
        public int departmentNo { get; set; }
        public string employeeName { get; set; }
        public decimal salary { get; set; }
        public Nullable<System.DateTime> lastModifyDate { get; set; }

        public DepartmentModel Department { get; set; }
      
    }
}