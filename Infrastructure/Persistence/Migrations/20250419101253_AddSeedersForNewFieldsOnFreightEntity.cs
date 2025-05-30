using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedersForNewFieldsOnFreightEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDriverHour",
                table: "Freights",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerLiterFuel",
                table: "Freights",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "PricePerDriverHour", "PricePerLiterFuel" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)), 20m, 1.80m });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "PricePerDriverHour", "PricePerLiterFuel" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9649), new TimeSpan(0, 0, 0, 0, 0)), 20m, 1.80m });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "PricePerDriverHour", "PricePerLiterFuel" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 0, 0, 0, 0)), 20m, 1.80m });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "PricePerDriverHour", "PricePerLiterFuel" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, 0, 0, 0, 0)), 20m, 1.80m });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 10, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(3415), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 10, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(3420), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(3426), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 10, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(3427), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 18, 10, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(3431), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 10, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(3432), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 9, 42, 52, 410, DateTimeKind.Unspecified).AddTicks(3436), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 10, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(3437), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 9, 27, 52, 410, DateTimeKind.Utc).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 9, 42, 52, 410, DateTimeKind.Utc).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 18, 10, 12, 52, 410, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 18, 10, 22, 52, 410, DateTimeKind.Utc).AddTicks(486));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDriverHour",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "PricePerLiterFuel",
                table: "Freights");

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 7, 39, 25, 409, DateTimeKind.Unspecified).AddTicks(3163), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 7, 39, 25, 409, DateTimeKind.Unspecified).AddTicks(3169), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 7, 39, 25, 409, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 7, 39, 25, 409, DateTimeKind.Unspecified).AddTicks(3176), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 9, 39, 25, 408, DateTimeKind.Unspecified).AddTicks(8054), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 9, 39, 25, 408, DateTimeKind.Unspecified).AddTicks(8057), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 7, 39, 25, 408, DateTimeKind.Unspecified).AddTicks(8062), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 9, 39, 25, 408, DateTimeKind.Unspecified).AddTicks(8063), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 18, 9, 39, 25, 408, DateTimeKind.Unspecified).AddTicks(8066), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 9, 39, 25, 408, DateTimeKind.Unspecified).AddTicks(8068), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 9, 9, 25, 408, DateTimeKind.Unspecified).AddTicks(8071), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 9, 39, 25, 408, DateTimeKind.Unspecified).AddTicks(8072), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 8, 54, 25, 408, DateTimeKind.Utc).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 9, 9, 25, 408, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 18, 9, 39, 25, 408, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 18, 9, 49, 25, 408, DateTimeKind.Utc).AddTicks(5564));
        }
    }
}
