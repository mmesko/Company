using Company.DAL;
using Company.DAL.Models;
using Company.Repository.Common;

namespace Company.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICompanyContext>().To<CompanyContext>();
            Bind<IRepository>().To<Repository>();
            Bind<IDepartmentRepository>().To<DepartmentRepository>();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
        }
    }
}