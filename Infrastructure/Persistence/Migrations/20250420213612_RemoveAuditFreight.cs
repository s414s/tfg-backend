using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuditFreight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Freights");

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 20, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6501), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6506), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 20, 19, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6512), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6518), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6519), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 20, 21, 6, 12, 319, DateTimeKind.Unspecified).AddTicks(6524), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 19, 21, 36, 12, 319, DateTimeKind.Unspecified).AddTicks(6525), new TimeSpan(0, 0, 0, 0, 0)) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Freights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Freights",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "Freights",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "Freights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Freights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                table: "Freights",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "CreatedBy", "DeletedBy", "DeletedDate", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8588), new TimeSpan(0, 0, 0, 0, 0)), 0L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "CreatedBy", "DeletedBy", "DeletedDate", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8596), new TimeSpan(0, 0, 0, 0, 0)), 0L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "CreatedBy", "DeletedBy", "DeletedDate", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8669), new TimeSpan(0, 0, 0, 0, 0)), 0L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "CreatedBy", "DeletedBy", "DeletedDate", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 19, 13, 25, 3, 952, DateTimeKind.Unspecified).AddTicks(8675), new TimeSpan(0, 0, 0, 0, 0)), 0L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

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
        }
    }
}
