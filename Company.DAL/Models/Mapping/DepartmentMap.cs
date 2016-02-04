using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Company.DAL.Models.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.departmentNo);

            // Properties
            this.Property(t => t.departmentNo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.departmentName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.departmentLocation)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Department");
            this.Property(t => t.departmentNo).HasColumnName("departmentNo");
            this.Property(t => t.departmentName).HasColumnName("departmentName");
            this.Property(t => t.departmentLocation).HasColumnName("departmentLocation");
        }
    }
}
