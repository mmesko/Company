
namespace Company.Model.Common
{
    public interface IEmployee
    {
        int employeeNo { get; set; }
        int departmentNo { get; set; }
        string employeeName { get; set; }
        decimal salary { get; set; }
        System.DateTime lastModifyDate { get; set; }
        IDepartment Department { get; set; }
    }
}
