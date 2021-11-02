using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Covid19Pcr.Infrastructure.DataAccess.EntityConfigurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Locations>
    {
        public void Configure(EntityTypeBuilder<Locations> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200);

            builder.HasData(new List<Locations>
            {

                new Locations
                {
                    Id= 1,
                    Name="Lagos"
                },
                new Locations
                {
                    Id=2,
                    Name="Abuja"
                }
            });

        }
    }

}
