using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Covid19Pcr.Infrastructure.DataAccess.EntityConfigurations
{
    public class TestTypesEntityConfiguration : IEntityTypeConfiguration<TestTypes>
    {
        public void Configure(EntityTypeBuilder<TestTypes> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.HasData(new List<TestTypes>
            {
                new TestTypes
                {
                    Id=1,
                    Name= "PCR Tests",
                },
            });
        }
    }
}
