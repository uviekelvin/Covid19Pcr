using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Covid19Pcr.Infrastructure.DataAccess.EntityConfigurations
{
    public class PatientsEntityConfiguration : IEntityTypeConfiguration<Patients>
    {
        public void Configure(EntityTypeBuilder<Patients> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).HasMaxLength(40);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.SurName).HasMaxLength(100);

            builder.HasIndex(c => new { c.Email, c.PhoneNumber });


            builder.HasData(new List<Patients>
            {
                new Patients
                {
                    Id=1,
                    FirstName="Uvie",
                    SurName="Oghenejakpor",
                    Email= "uviekelvin@gmail.com",
                    PhoneNumber="+2347059647234"
                },
                 new Patients
                {
                    Id=2,
                    FirstName="Kelvin",
                    SurName="Oghenejakpor",
                    Email= "kelvin.uvie@gmail.com",
                    PhoneNumber="+2347030650790"
                },
                  new Patients
                {
                    Id=3,
                    FirstName="Odafe",
                    SurName="Oghenejakpor",
                    Email= "uviekelvin@gmail.com",
                    PhoneNumber="+2347059647234"
                }
            });
        }
    }
}
