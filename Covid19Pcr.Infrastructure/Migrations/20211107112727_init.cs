using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19Pcr.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestDays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableSpace = table.Column<int>(type: "int", nullable: false),
                    LabId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestDays_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BookingCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    TestTypeId = table.Column<long>(type: "bigint", nullable: false),
                    TestDayId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_TestDays_TestDayId",
                        column: x => x.TestDayId,
                        principalTable: "TestDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_TestTypes_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "TestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    BookingsId = table.Column<long>(type: "bigint", nullable: false),
                    ResultType = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.BookingsId);
                    table.ForeignKey(
                        name: "FK_TestResults_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(5298), new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(5316), false, "Lagos" },
                    { 2L, new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(6065), new DateTime(2021, 11, 7, 12, 27, 26, 665, DateTimeKind.Local).AddTicks(6072), false, "Abuja" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "IsDeleted", "PhoneNumber", "SurName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(1087), new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(1110), "uviekelvin@gmail.com", "Uvie", false, "+2347059647234", "Oghenejakpor" },
                    { 2L, new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(4997), new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(5016), "kelvin.uvie@gmail.com", "Kelvin", false, "+2347030650790", "Oghenejakpor" },
                    { 3L, new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(5024), new DateTime(2021, 11, 7, 12, 27, 26, 669, DateTimeKind.Local).AddTicks(5026), "uviekelvin@gmail.com", "Odafe", false, "+2347059647234", "Oghenejakpor" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { 1L, new DateTime(2021, 11, 7, 12, 27, 26, 671, DateTimeKind.Local).AddTicks(6327), new DateTime(2021, 11, 7, 12, 27, 26, 671, DateTimeKind.Local).AddTicks(6348), false, "PCR Tests" });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(3113), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(3145), false, 1L, "Malens Diagnostic Solutions" },
                    { 2L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4521), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4528), false, 1L, "African Biosciences Ltd" },
                    { 3L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4535), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4537), false, 1L, "Ice Field Industrial Ltd" },
                    { 4L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4541), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4543), false, 1L, "PathCare Laboratories" },
                    { 5L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4546), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4548), false, 1L, "Argon Laboratories Ltd" },
                    { 6L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4655), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4657), false, 2L, "Azzon Medicals and Diagnostics" },
                    { 7L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4661), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4663), false, 2L, "CrownChek Laboratories Ltd" },
                    { 8L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4666), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4668), false, 2L, "Europharm Laboratories" },
                    { 9L, new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4671), new DateTime(2021, 11, 7, 12, 27, 26, 664, DateTimeKind.Local).AddTicks(4673), false, 2L, "Nero Medical Diagnostic Laboratory" }
                });

            migrationBuilder.InsertData(
                table: "TestDays",
                columns: new[] { "Id", "AvailableSpace", "Date", "DateCreated", "DateUpdated", "IsDeleted", "LabId" },
                values: new object[,]
                {
                    { 1L, 0, new DateTime(2021, 11, 8, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(4181), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(4156), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(4176), false, 1L },
                    { 2L, 0, new DateTime(2021, 11, 9, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5743), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5732), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5739), false, 2L },
                    { 3L, 0, new DateTime(2021, 11, 10, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5761), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5757), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5759), false, 3L },
                    { 4L, 0, new DateTime(2021, 11, 11, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5767), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5764), new DateTime(2021, 11, 7, 12, 27, 26, 670, DateTimeKind.Local).AddTicks(5765), false, 3L }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingCode", "DateCreated", "DateUpdated", "IsDeleted", "PatientId", "Status", "TestDayId", "TestTypeId" },
                values: new object[,]
                {
                    { 1L, "6978558196", new DateTime(2021, 11, 7, 12, 27, 26, 649, DateTimeKind.Local).AddTicks(5085), new DateTime(2021, 11, 7, 12, 27, 26, 650, DateTimeKind.Local).AddTicks(9613), false, 1L, "0", 1L, 1L },
                    { 2L, "2673897780", new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(140), new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(169), false, 2L, "0", 2L, 1L },
                    { 3L, "1641097345", new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(965), new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(970), false, 2L, "0", 2L, 1L },
                    { 4L, "6900596816", new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(1125), new DateTime(2021, 11, 7, 12, 27, 26, 661, DateTimeKind.Local).AddTicks(1128), false, 3L, "0", 3L, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingCode",
                table: "Bookings",
                column: "BookingCode",
                unique: true,
                filter: "[BookingCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PatientId",
                table: "Bookings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TestDayId",
                table: "Bookings",
                column: "TestDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TestTypeId",
                table: "Bookings",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labs_LocationId",
                table: "Labs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email_PhoneNumber",
                table: "Patients",
                columns: new[] { "Email", "PhoneNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_TestDays_LabId",
                table: "TestDays",
                column: "LabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "TestDays");

            migrationBuilder.DropTable(
                name: "TestTypes");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
