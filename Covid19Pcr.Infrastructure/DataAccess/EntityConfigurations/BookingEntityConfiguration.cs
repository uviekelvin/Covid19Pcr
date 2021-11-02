

using Covid19Pcr.Common.Helpers;
using Covid19Pcr.Domain.Enums;
using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Covid19Pcr.Infrastructure.DataAccess.EntityConfigurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Bookings>
    {
        public void Configure(EntityTypeBuilder<Bookings> builder)
        {
            builder.Property(x => x.BookingCode).HasMaxLength(10);
            builder.OwnsOne(x => x.TestResult).ToTable("TestResults");
            builder.Property(x => x.Status).HasMaxLength(20)
                .HasConversion(x => x.ToString(), x => (BookingStatus)Enum.Parse(typeof(BookingStatus), x));
            builder.HasIndex(x => x.BookingCode).IsUnique();

            builder.HasData(new List<Bookings>
            {
                new Bookings
                {

                    Id=1,
                    TestDayId=1,
                    PatientId=1,
                    TestTypeId=1
                },
                new Bookings
                {

                    Id=2,
                    TestDayId=2,
                    PatientId=2,
                    TestTypeId=1
                },
                new Bookings
                {
                    Id=3,

                    TestDayId=2,
                    PatientId=2,
                    TestTypeId=1
                },
                new Bookings
                {
                  Id=4,
                  TestDayId=3,
                  TestTypeId=1,
                  PatientId=3                }

            });

        }
    }



}
