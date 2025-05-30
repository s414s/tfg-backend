using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCitiesAndRoutesSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonDocument>(
                name: "Points",
                table: "Routes",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "Name", "Location_Lat", "Location_Lon" },
                values: new object[,]
                {
                    { 1L, "ZAR", "Zaragoza", 41.648800000000001, -0.8891 },
                    { 2L, "BCN", "Barcelona", 41.385100000000001, 2.1734 },
                    { 3L, "MAD", "Madrid", 40.416800000000002, -3.7038000000000002 },
                    { 4L, "VAL", "Valencia", 39.469900000000003, -0.37630000000000002 },
                    { 5L, "SEV", "Sevilla", 37.389099999999999, -5.9844999999999997 },
                    { 6L, "COR", "Cordoba", 37.888199999999998, -4.7793999999999999 },
                    { 7L, "MUR", "Murcia", 37.992199999999997, -1.1307 },
                    { 8L, "LER", "Lerida", 41.617600000000003, 0.62 },
                    { 9L, "ALB", "Albacete", 38.994300000000003, -1.8561000000000001 },
                    { 10L, "CR", "Ciudad Real", 38.9861, -3.9268999999999998 },
                    { 11L, "GRA", "Granada", 37.18817, -3.6066699999999998 },
                    { 12L, "TER", "Teruel", 40.345300000000002, -1.1068 }
                });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 11, 19, 1, 17, 871, DateTimeKind.Unspecified).AddTicks(8473), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 10, 19, 1, 17, 871, DateTimeKind.Unspecified).AddTicks(8477), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 11, 17, 1, 17, 871, DateTimeKind.Unspecified).AddTicks(8483), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 10, 19, 1, 17, 871, DateTimeKind.Unspecified).AddTicks(8484), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 10, 19, 1, 17, 871, DateTimeKind.Unspecified).AddTicks(8536), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 10, 19, 1, 17, 871, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 11, 18, 31, 17, 871, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 10, 19, 1, 17, 871, DateTimeKind.Unspecified).AddTicks(8543), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 11, 18, 16, 17, 871, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 11, 18, 31, 17, 871, DateTimeKind.Utc).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 10, 19, 1, 17, 871, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 10, 19, 11, 17, 871, DateTimeKind.Utc).AddTicks(5317));

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "AvgSpeed", "DestinationId", "Distance", "OriginId", "Points" },
                values: new object[,]
                {
                    { 1L, 100.0, 3L, 320.0, 1L, null },
                    { 2L, 95.0, 5L, 530.0, 3L, null },
                    { 3L, 90.0, 7L, 400.0, 5L, null },
                    { 4L, 100.0, 4L, 240.0, 7L, null },
                    { 5L, 100.0, 2L, 350.0, 4L, null },
                    { 6L, 100.0, 8L, 150.0, 2L, null },
                    { 7L, 100.0, 1L, 150.0, 8L, null },
                    { 8L, 90.0, 12L, 200.0, 1L, null },
                    { 9L, 90.0, 4L, 250.0, 12L, null },
                    { 10L, 90.0, 9L, 150.0, 7L, null },
                    { 11L, 90.0, 4L, 170.0, 9L, null },
                    { 12L, 100.0, 3L, 400.0, 9L, null },
                    { 13L, 100.0, 4L, 240.0, 7L, null },
                    { 14L, 90.0, 10L, 130.0, 9L, null },
                    { 15L, 90.0, 10L, 180.0, 6L, null },
                    { 16L, 90.0, 5L, 140.0, 6L, null },
                    { 17L, 90.0, 11L, 200.0, 6L, null },
                    { 18L, 90.0, 3L, 200.0, 10L, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "Points",
                table: "Routes",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 30, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9757), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 30, 18, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9761), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9762), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9766), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 30, 20, 2, 59, 68, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 3, 30, 19, 47, 59, 68, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 3, 30, 20, 2, 59, 68, DateTimeKind.Utc).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 3, 29, 20, 42, 59, 68, DateTimeKind.Utc).AddTicks(7341));
        }
    }
}
