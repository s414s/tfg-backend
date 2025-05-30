using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addOldBehaviourForTimestampUtc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "MessageThreads",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "MessageThreads",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MessageThreads",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueStart",
                table: "Freights",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 20, 4, 30, 851, DateTimeKind.Utc).AddTicks(8648), new DateTime(2025, 4, 25, 20, 4, 30, 851, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 18, 4, 30, 851, DateTimeKind.Utc).AddTicks(8654), new DateTime(2025, 4, 25, 20, 4, 30, 851, DateTimeKind.Utc).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 25, 20, 4, 30, 851, DateTimeKind.Utc).AddTicks(8657), new DateTime(2025, 4, 25, 20, 4, 30, 851, DateTimeKind.Utc).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 19, 34, 30, 851, DateTimeKind.Utc).AddTicks(8661), new DateTime(2025, 4, 25, 20, 4, 30, 851, DateTimeKind.Utc).AddTicks(8662) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 26, 19, 19, 30, 851, DateTimeKind.Utc).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 26, 19, 34, 30, 851, DateTimeKind.Utc).AddTicks(5543));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 25, 20, 4, 30, 851, DateTimeKind.Utc).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 25, 20, 14, 30, 851, DateTimeKind.Utc).AddTicks(5551));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "MessageThreads",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "MessageThreads",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MessageThreads",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueStart",
                table: "Freights",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1092), new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 17, 50, 42, 943, DateTimeKind.Utc).AddTicks(1098), new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1102), new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 4, 26, 19, 20, 42, 943, DateTimeKind.Utc).AddTicks(1105), new DateTime(2025, 4, 25, 19, 50, 42, 943, DateTimeKind.Utc).AddTicks(1106) });

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
    }
}
