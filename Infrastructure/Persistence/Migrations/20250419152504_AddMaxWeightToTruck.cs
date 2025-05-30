using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxWeightToTruck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8596), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8669), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8675), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 15, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 15, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(2060), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(2065), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 15, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(2067), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 18, 15, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(2070), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 15, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(2071), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 14, 55, 3, 952, DateTimeKind.Unspecified).AddTicks(2075), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 18, 15, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(2076), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 14, 40, 3, 951, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 14, 55, 3, 951, DateTimeKind.Utc).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 18, 15, 25, 3, 951, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 18, 15, 35, 3, 951, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "MaxWeight",
                value: 3000m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "MaxWeight",
                value: 3000m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "MaxWeight",
                value: 3000m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "MaxWeight",
                value: 3000m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "MaxWeight",
                value: 3000m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9640), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9649), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9654), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 19, 8, 12, 52, 410, DateTimeKind.Unspecified).AddTicks(9659), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "MaxWeight",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "MaxWeight",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "MaxWeight",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "MaxWeight",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "MaxWeight",
                value: 0m);
        }
    }
}
