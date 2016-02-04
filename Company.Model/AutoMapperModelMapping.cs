using AutoMapper;
using Company.Model.Common;
using Company.DAL.Models;

namespace Company.Model
{
    public class AutoMapperModelMapping{
        public static void Initialize()
        {

            Mapper.CreateMap<IEmployee, Employee>().ReverseMap();
            Mapper.CreateMap<Employee, EmployeePOCO>().ReverseMap();

            Mapper.CreateMap<IDepartment, Department>().ReverseMap();
            Mapper.CreateMap<Department, DepartmentPOCO>().ReverseMap();
        }

       
    }
}
