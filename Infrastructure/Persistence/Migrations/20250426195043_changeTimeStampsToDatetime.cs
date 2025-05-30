using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeTimeStampsToDatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1092), null, new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 17, 50, 42, 943, DateTimeKind.Utc).AddTicks(1098), null, new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1102), null, new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 19, 20, 42, 943, DateTimeKind.Utc).AddTicks(1105), null, new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 26, 19, 5, 42, 942, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 26, 19, 20, 42, 942, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 25, 19, 50, 42, 942, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 25, 20, 0, 42, 942, DateTimeKind.Utc).AddTicks(8134));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 19, 18, 2, 394, DateTimeKind.Unspecified).AddTicks(2868), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2025, 4, 25, 19, 18, 2, 394, DateTimeKind.Unspecified).AddTicks(2876), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 17, 18, 2, 394, DateTimeKind.Unspecified).AddTicks(2881), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2025, 4, 25, 19, 18, 2, 394, DateTimeKind.Unspecified).AddTicks(2882), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 25, 19, 18, 2, 394, DateTimeKind.Unspecified).AddTicks(2886), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2025, 4, 25, 19, 18, 2, 394, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 26, 18, 48, 2, 394, DateTimeKind.Unspecified).AddTicks(2890), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2025, 4, 25, 19, 18, 2, 394, DateTimeKind.Unspecified).AddTicks(2891), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 26, 18, 33, 2, 393, DateTimeKind.Utc).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 26, 18, 48, 2, 393, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 25, 19, 18, 2, 393, DateTimeKind.Utc).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 25, 19, 28, 2, 393, DateTimeKind.Utc).AddTicks(9408));
        }
    }
}
