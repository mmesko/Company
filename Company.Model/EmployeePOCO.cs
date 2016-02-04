using Company.Model.Common;

namespace Company.Model
{
   public class EmployeePOCO: IEmployee
    {
        public int employeeNo { get; set; }
        public int departmentNo { get; set; }
        public string employeeName { get; set; }
        public decimal salary { get; set; }
        public System.DateTime lastModifyDate { get; set; }
        public IDepartment Department { get; set; }
    }
}
