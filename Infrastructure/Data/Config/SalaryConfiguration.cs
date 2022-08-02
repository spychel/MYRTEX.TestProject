using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Value).IsRequired().HasColumnType("DECIMAL");
        }
    }
}