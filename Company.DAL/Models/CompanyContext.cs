
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Company.DAL.Models.Mapping;
using System.Threading.Tasks;
using System;

namespace Company.DAL.Models
{
    public partial class CompanyContext : DbContext, ICompanyContext
    {
        static CompanyContext()
        {
            Database.SetInitializer<CompanyContext>(null);
        }

        public CompanyContext()
            : base("Name=CompanyContext")
        {
        }


        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

     


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new DepartmentMap());

            modelBuilder.Configurations.Add(new EmployeeMap());

          

        }
    }

}
