using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "Consumption", "DriverId", "LastMaintenance", "ManufacturingDate", "Mileage", "Plate" },
                values: new object[] { 4L, 26m, 1L, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 95000m, "1122ABC" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role", "Surname" },
                values: new object[,]
                {
                    { 3L, "maria@gmail.com", "maria", "root", 1, "hernandez" },
                    { 4L, "violeta@gmail.com", "violeta", "root", 1, "salas" },
                    { 5L, "gimena@gmail.com", "gimena", "root", 1, "salas" },
                    { 6L, "sara@gmail.com", "sara", "root", 1, "salas" }
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "Consumption", "DriverId", "LastMaintenance", "ManufacturingDate", "Mileage", "Plate" },
                values: new object[,]
                {
                    { 2L, 30m, 3L, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 75000m, "8923XYZ" },
                    { 3L, 28m, 5L, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 120000m, "5634QWE" },
                    { 5L, 27m, 4L, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 80000m, "7834LMN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
