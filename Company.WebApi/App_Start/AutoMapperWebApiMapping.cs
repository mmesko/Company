using Company.Model;
using Company.Model.Common;
using Company.WebApi.Models;

namespace Company.WebApi.App_Start
{
    public static class AutoMapperWebApiMapping
    {
        public static void Initialize()
        {
            // Model
            Company.Model.AutoMapperModelMapping.Initialize();

            // AnswerChoiceContorller
            AutoMapper.Mapper.CreateMap<Company.WebApi.Models.EmployeeModel, EmployeePOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Company.WebApi.Models.EmployeeModel, IEmployee>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Company.WebApi.Models.DepartmentModel, DepartmentPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Company.WebApi.Models.DepartmentModel, IDepartment>().ReverseMap();

          


        }
    }
}