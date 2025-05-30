using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFreightSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "RouteId", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8723), new TimeSpan(0, 0, 0, 0, 0)), 1L, 1L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "RouteId", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 0, 0, 0, 0)), 1L, 1L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "RouteId", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 0, 0, 0, 0)), 1L, 3L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 20, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(764), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(769), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(775), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(776), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 12, 20, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(781), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(782), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 20, 2, 18, 493, DateTimeKind.Unspecified).AddTicks(786), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(788), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 13, 19, 47, 18, 492, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 13, 20, 2, 18, 492, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 12, 20, 32, 18, 492, DateTimeKind.Utc).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 12, 20, 42, 18, 492, DateTimeKind.Utc).AddTicks(7503));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(7290), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "RouteId", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(7347), new TimeSpan(0, 0, 0, 0, 0)), 5L, 2L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "RouteId", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(7351), new TimeSpan(0, 0, 0, 0, 0)), 2L, 5L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "RouteId", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(7355), new TimeSpan(0, 0, 0, 0, 0)), 6L, 8L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 20, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(1699), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(1704), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(1709), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(1711), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 12, 20, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(1714), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(1715), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 19, 52, 17, 318, DateTimeKind.Unspecified).AddTicks(1719), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 22, 17, 318, DateTimeKind.Unspecified).AddTicks(1720), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 13, 19, 37, 17, 317, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 13, 19, 52, 17, 317, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 12, 20, 22, 17, 317, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 12, 20, 32, 17, 317, DateTimeKind.Utc).AddTicks(8828));
        }
    }
}
