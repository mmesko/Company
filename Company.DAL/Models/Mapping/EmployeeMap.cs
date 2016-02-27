


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace Company.DAL.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key

            this.HasKey(t => t.employeeNo);


            // Properties

            this.Property(t => t.employeeName)
                .IsRequired()
                .HasMaxLength(50);


            // Table & Column Mappings

            this.ToTable("Employee");

            this.Property(t => t.employeeNo).HasColumnName("employeeNo");

            this.Property(t => t.departmentNo).HasColumnName("departmentNo");

            this.Property(t => t.employeeName).HasColumnName("employeeName");

            this.Property(t => t.salary).HasColumnName("salary");

            this.Property(t => t.lastModifyDate).HasColumnName("lastModifyDate");


            // Relationships

            this.HasRequired(t => t.Department)

                .WithMany(t => t.Employees)

                .HasForeignKey(d => d.departmentNo);



        }
    }
}
