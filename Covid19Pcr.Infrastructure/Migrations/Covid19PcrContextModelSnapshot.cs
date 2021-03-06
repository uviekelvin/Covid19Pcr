// <auto-generated />
using System;
using Covid19Pcr.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid19Pcr.Infrastructure.Migrations
{
    [DbContext(typeof(Covid19PcrContext))]
    partial class Covid19PcrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Bookings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("TestDayId")
                        .HasColumnType("bigint");

                    b.Property<long>("TestTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BookingCode")
                        .IsUnique()
                        .HasFilter("[BookingCode] IS NOT NULL");

                    b.HasIndex("PatientId");

                    b.HasIndex("TestDayId");

                    b.HasIndex("TestTypeId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BookingCode = "6978558196",
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 649, DateTimeKind.Local).AddTicks(5085),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 650, DateTimeKind.Local).AddTicks(9613),
                            IsDeleted = false,
                            PatientId = 1L,
                            Status = "0",
                            TestDayId = 1L,
                            TestTypeId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            BookingCode = "2673897780",
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(140),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(169),
                            IsDeleted = false,
                            PatientId = 2L,
                            Status = "0",
                            TestDayId = 2L,
                            TestTypeId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            BookingCode = "1641097345",
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(965),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(970),
                            IsDeleted = false,
                            PatientId = 2L,
                            Status = "0",
                            TestDayId = 2L,
                            TestTypeId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            BookingCode = "6900596816",
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(1125),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(1128),
                            IsDeleted = false,
                            PatientId = 3L,
                            Status = "0",
                            TestDayId = 3L,
                            TestTypeId = 1L
                        });
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Labs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Labs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(3113),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(3145),
                            IsDeleted = false,
                            LocationId = 1L,
                            Name = "Malens Diagnostic Solutions"
                        },
                        new
                        {
                            Id = 2L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4521),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4528),
                            IsDeleted = false,
                            LocationId = 1L,
                            Name = "African Biosciences Ltd"
                        },
                        new
                        {
                            Id = 3L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4535),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4537),
                            IsDeleted = false,
                            LocationId = 1L,
                            Name = "Ice Field Industrial Ltd"
                        },
                        new
                        {
                            Id = 4L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4541),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4543),
                            IsDeleted = false,
                            LocationId = 1L,
                            Name = "PathCare Laboratories"
                        },
                        new
                        {
                            Id = 5L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4546),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4548),
                            IsDeleted = false,
                            LocationId = 1L,
                            Name = "Argon Laboratories Ltd"
                        },
                        new
                        {
                            Id = 6L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4655),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4657),
                            IsDeleted = false,
                            LocationId = 2L,
                            Name = "Azzon Medicals and Diagnostics"
                        },
                        new
                        {
                            Id = 7L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4661),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4663),
                            IsDeleted = false,
                            LocationId = 2L,
                            Name = "CrownChek Laboratories Ltd"
                        },
                        new
                        {
                            Id = 8L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4666),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4668),
                            IsDeleted = false,
                            LocationId = 2L,
                            Name = "Europharm Laboratories"
                        },
                        new
                        {
                            Id = 9L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4671),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4673),
                            IsDeleted = false,
                            LocationId = 2L,
                            Name = "Nero Medical Diagnostic Laboratory"
                        });
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Locations", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(5298),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(5316),
                            IsDeleted = false,
                            Name = "Lagos"
                        },
                        new
                        {
                            Id = 2L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(6065),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(6072),
                            IsDeleted = false,
                            Name = "Abuja"
                        });
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Patients", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("SurName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email", "PhoneNumber");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(1087),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(1110),
                            Email = "uviekelvin@gmail.com",
                            FirstName = "Uvie",
                            IsDeleted = false,
                            PhoneNumber = "+2347059647234",
                            SurName = "Oghenejakpor"
                        },
                        new
                        {
                            Id = 2L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(4997),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(5016),
                            Email = "kelvin.uvie@gmail.com",
                            FirstName = "Kelvin",
                            IsDeleted = false,
                            PhoneNumber = "+2347030650790",
                            SurName = "Oghenejakpor"
                        },
                        new
                        {
                            Id = 3L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(5024),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(5026),
                            Email = "uviekelvin@gmail.com",
                            FirstName = "Odafe",
                            IsDeleted = false,
                            PhoneNumber = "+2347059647234",
                            SurName = "Oghenejakpor"
                        });
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.TestDays", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableSpace")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("LabId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LabId");

                    b.ToTable("TestDays");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AvailableSpace = 0,
                            Date = new DateTime(2021, 11, 8, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(4181),
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(4156),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(4176),
                            IsDeleted = false,
                            LabId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            AvailableSpace = 0,
                            Date = new DateTime(2021, 11, 9, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5743),
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5732),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5739),
                            IsDeleted = false,
                            LabId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            AvailableSpace = 0,
                            Date = new DateTime(2021, 11, 10, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5761),
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5757),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5759),
                            IsDeleted = false,
                            LabId = 3L
                        },
                        new
                        {
                            Id = 4L,
                            AvailableSpace = 0,
                            Date = new DateTime(2021, 11, 11, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5767),
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5764),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5765),
                            IsDeleted = false,
                            LabId = 3L
                        });
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.TestTypes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TestTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateCreated = new DateTime(2021, 11, 7, 12, 27, 26, 671, DateTimeKind.Local).AddTicks(6327),
                            DateUpdated = new DateTime(2021, 11, 7, 12, 27, 26, 671, DateTimeKind.Local).AddTicks(6348),
                            IsDeleted = false,
                            Name = "PCR Tests"
                        });
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Bookings", b =>
                {
                    b.HasOne("Covid19Pcr.Domain.Models.Patients", "Patient")
                        .WithMany("Bookings")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Covid19Pcr.Domain.Models.TestDays", "TestDay")
                        .WithMany()
                        .HasForeignKey("TestDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Covid19Pcr.Domain.Models.TestTypes", "TestType")
                        .WithMany()
                        .HasForeignKey("TestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Covid19Pcr.Domain.Models.TestResults", "TestResult", b1 =>
                        {
                            b1.Property<long>("BookingsId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("DateCreated")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Remarks")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("ResultType")
                                .HasColumnType("int");

                            b1.HasKey("BookingsId");

                            b1.ToTable("TestResults");

                            b1.WithOwner()
                                .HasForeignKey("BookingsId");
                        });

                    b.Navigation("Patient");

                    b.Navigation("TestDay");

                    b.Navigation("TestResult");

                    b.Navigation("TestType");
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Labs", b =>
                {
                    b.HasOne("Covid19Pcr.Domain.Models.Locations", "Location")
                        .WithMany("Labs")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.TestDays", b =>
                {
                    b.HasOne("Covid19Pcr.Domain.Models.Labs", "Lab")
                        .WithMany("TestDays")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lab");
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Labs", b =>
                {
                    b.Navigation("TestDays");
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Locations", b =>
                {
                    b.Navigation("Labs");
                });

            modelBuilder.Entity("Covid19Pcr.Domain.Models.Patients", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
