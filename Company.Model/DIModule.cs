using System;
using Company.Model.Common;

namespace Company.Model
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IDepartment>().To<DepartmentPOCO>();
            Bind<IEmployee>().To<EmployeePOCO>();

        }
    }
}