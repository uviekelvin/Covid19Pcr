using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Covid19Pcr.Infrastructure.DataAccess.EntityConfigurations
{
    public class TestDayEntityConfiguration : IEntityTypeConfiguration<TestDays>
    {
        public void Configure(EntityTypeBuilder<TestDays> builder)
        {


            builder.HasData(new List<TestDays>
            {
                new TestDays
                {

                    Id=1,
                    Date= DateTime.Now.AddDays(1),
                    LabId=1
                },
                new TestDays
                {

                    Id=2,
                  Date= DateTime.Now.AddDays(2),
                  LabId=2
                },
                new TestDays
                {
                    Id=3,

                   Date= DateTime.Now.AddDays(3),
                   LabId=3
                },
                new TestDays
                {
                  Id=4,
                  Date=DateTime.Now.AddDays(4),
                  LabId=3
                }

            });

        }
    }
}
