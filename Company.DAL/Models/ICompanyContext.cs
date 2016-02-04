using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Company.DAL.Models
{
    public interface ICompanyContext : IDisposable
    {
       DbSet<Department> Departments { get; set; }
       DbSet<Employee> Employees { get; set; }

       DbSet<TEntity> Set<TEntity>() where TEntity : class;
       DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
       Task<int> SaveChangesAsync();

    }
}
