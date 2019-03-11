using System.Collections.Generic;
using Company.Model.Common;


namespace Company.Model
{
   public class DepartmentPOCO: IDepartment 
    {  
       public DepartmentPOCO()
        {
            this.Employees = new List<IEmployee>();
        }
        public int departmentNo { get; set; }
        public string departmentName { get; set; }
        public string departmentLocation { get; set; }
        public ICollection<IEmployee> Employees { get; set; }
		public string departmentInfo{ get; set; }
    }
}
