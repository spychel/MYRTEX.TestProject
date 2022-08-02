using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.SecondName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Birthdate).IsRequired();
            builder.Property(p => p.Hiredate).IsRequired();
            builder.HasOne(p => p.Salary);
            builder.HasOne(p => p.Department).WithMany().HasForeignKey(p => p.DepartmentId);
        }
    }
}