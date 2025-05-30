using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class makeUpdateNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "MessageThreads",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "MessageThreads",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 20, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6501), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6506), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 20, 19, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6512), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6519), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "DeletedDate", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 20, 21, 6, 12, 319, DateTimeKind.Unspecified).AddTicks(6524), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6525), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 20, 20, 51, 12, 319, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 20, 21, 6, 12, 319, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 19, 21, 46, 12, 319, DateTimeKind.Utc).AddTicks(3037));
        }
    }
}
