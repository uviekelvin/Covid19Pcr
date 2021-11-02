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
                    SpaceAvailable = table.Column<int>(type: "int", nullable: false),
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
                    BookingId = table.Column<long>(type: "bigint", nullable: false),
                    ResultType = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_TestResults_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 2, 23, 19, 1, 454, DateTimeKind.Local).AddTicks(9625), new DateTime(2021, 11, 2, 23, 19, 1, 454, DateTimeKind.Local).AddTicks(9655), false, "Lagos" },
                    { 2L, new DateTime(2021, 11, 2, 23, 19, 1, 455, DateTimeKind.Local).AddTicks(410), new DateTime(2021, 11, 2, 23, 19, 1, 455, DateTimeKind.Local).AddTicks(418), false, "Abuja" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "IsDeleted", "PhoneNumber", "SurName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 2, 23, 19, 1, 465, DateTimeKind.Local).AddTicks(6170), new DateTime(2021, 11, 2, 23, 19, 1, 465, DateTimeKind.Local).AddTicks(6197), "uviekelvin@gmail.com", "Uvie", false, "+2347059647234", "Oghenejakpor" },
                    { 2L, new DateTime(2021, 11, 2, 23, 19, 1, 465, DateTimeKind.Local).AddTicks(8775), new DateTime(2021, 11, 2, 23, 19, 1, 465, DateTimeKind.Local).AddTicks(8787), "kelvin.uvie@gmail.com", "Kelvin", false, "+2347030650790", "Oghenejakpor" },
                    { 3L, new DateTime(2021, 11, 2, 23, 19, 1, 465, DateTimeKind.Local).AddTicks(8794), new DateTime(2021, 11, 2, 23, 19, 1, 465, DateTimeKind.Local).AddTicks(8796), "uviekelvin@gmail.com", "Odafe", false, "+2347059647234", "Oghenejakpor" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "Name" },
                values: new object[] { 1L, new DateTime(2021, 11, 2, 23, 19, 1, 468, DateTimeKind.Local).AddTicks(2169), new DateTime(2021, 11, 2, 23, 19, 1, 468, DateTimeKind.Local).AddTicks(2196), false, "PCR Tests" });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsDeleted", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(3187), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(3213), false, 1L, "Malens Diagnostic Solutions" },
                    { 2L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4730), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4740), false, 1L, "African Biosciences Ltd" },
                    { 3L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4747), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4749), false, 1L, "Ice Field Industrial Ltd" },
                    { 4L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4753), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4755), false, 1L, "PathCare Laboratories" },
                    { 5L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4762), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4764), false, 1L, "Argon Laboratories Ltd" },
                    { 6L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4892), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4896), false, 2L, "Azzon Medicals and Diagnostics" },
                    { 7L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4900), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4902), false, 2L, "CrownChek Laboratories Ltd" },
                    { 8L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4905), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4907), false, 2L, "Europharm Laboratories" },
                    { 9L, new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4911), new DateTime(2021, 11, 2, 23, 19, 1, 453, DateTimeKind.Local).AddTicks(4913), false, 2L, "Nero Medical Diagnostic Laboratory" }
                });

            migrationBuilder.InsertData(
                table: "TestDays",
                columns: new[] { "Id", "Date", "DateCreated", "DateUpdated", "IsDeleted", "LabId", "SpaceAvailable" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 11, 3, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(7880), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(7858), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(7875), false, 1L, 0 },
                    { 2L, new DateTime(2021, 11, 4, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9442), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9427), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9436), false, 2L, 0 },
                    { 3L, new DateTime(2021, 11, 5, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9465), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9461), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9463), false, 3L, 0 },
                    { 4L, new DateTime(2021, 11, 6, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9472), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9468), new DateTime(2021, 11, 2, 23, 19, 1, 466, DateTimeKind.Local).AddTicks(9470), false, 3L, 0 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingCode", "DateCreated", "DateUpdated", "IsDeleted", "PatientId", "Status", "TestDayId", "TestTypeId" },
                values: new object[,]
                {
                    { 1L, "0649346476", new DateTime(2021, 11, 2, 23, 19, 1, 422, DateTimeKind.Local).AddTicks(7973), new DateTime(2021, 11, 2, 23, 19, 1, 424, DateTimeKind.Local).AddTicks(3313), false, 1L, "0", 1L, 1L },
                    { 2L, "7766935364", new DateTime(2021, 11, 2, 23, 19, 1, 447, DateTimeKind.Local).AddTicks(2550), new DateTime(2021, 11, 2, 23, 19, 1, 447, DateTimeKind.Local).AddTicks(2582), false, 2L, "0", 2L, 1L },
                    { 3L, "4436818880", new DateTime(2021, 11, 2, 23, 19, 1, 447, DateTimeKind.Local).AddTicks(3624), new DateTime(2021, 11, 2, 23, 19, 1, 447, DateTimeKind.Local).AddTicks(3629), false, 2L, "0", 2L, 1L },
                    { 4L, "9121366194", new DateTime(2021, 11, 2, 23, 19, 1, 447, DateTimeKind.Local).AddTicks(3668), new DateTime(2021, 11, 2, 23, 19, 1, 447, DateTimeKind.Local).AddTicks(3671), false, 3L, "0", 3L, 1L }
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
