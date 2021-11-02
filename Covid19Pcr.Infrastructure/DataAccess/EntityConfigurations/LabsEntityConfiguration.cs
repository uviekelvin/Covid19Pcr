using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Covid19Pcr.Infrastructure.DataAccess.EntityConfigurations
{
    public class LabsEntityConfiguration : IEntityTypeConfiguration<Labs>
    {
        public void Configure(EntityTypeBuilder<Labs> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.HasData(new List<Labs>
            {
                new Labs
                {
                    Id=1,
                    Name= "Malens Diagnostic Solutions",
                    LocationId=1,
                },
                new Labs
                {
                    Id=2,
                    Name="African Biosciences Ltd",
                    LocationId=1
                },
                new Labs
                {
                    Id=3,
                  Name="Ice Field Industrial Ltd",
                  LocationId=1
                },
                new Labs
                {
                    Id=4,
                    Name="PathCare Laboratories",
                    LocationId=1,
                },
                new Labs
                {
                    Id=5,
                    Name="Argon Laboratories Ltd",
                    LocationId=1,
                },
                new Labs
                {
                    Id=6,
                    Name ="Azzon Medicals and Diagnostics",
                    LocationId=2,
                },
                new Labs
                {
                    Id=7,
                    Name="CrownChek Laboratories Ltd",
                     LocationId=2,
                },
                new Labs
                {
                    Id=8,
                    Name="Europharm Laboratories",
                     LocationId=2
                },
                new Labs
                {
                    Id=9,
                    Name="Nero Medical Diagnostic Laboratory",
                     LocationId=2
                }
            });
        }
    }
}
