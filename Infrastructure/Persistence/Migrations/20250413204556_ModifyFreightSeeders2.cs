using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFreightSeeders2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 45, 56, 224, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 0, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 45, 56, 224, DateTimeKind.Unspecified).AddTicks(5328), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 45, 56, 224, DateTimeKind.Unspecified).AddTicks(5333), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 45, 56, 224, DateTimeKind.Unspecified).AddTicks(5337), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 20, 45, 56, 223, DateTimeKind.Unspecified).AddTicks(9065), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 45, 56, 223, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 45, 56, 223, DateTimeKind.Unspecified).AddTicks(9076), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 45, 56, 223, DateTimeKind.Unspecified).AddTicks(9077), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 12, 20, 45, 56, 223, DateTimeKind.Unspecified).AddTicks(9082), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 45, 56, 223, DateTimeKind.Unspecified).AddTicks(9083), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 20, 15, 56, 223, DateTimeKind.Unspecified).AddTicks(9087), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 12, 20, 45, 56, 223, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 13, 20, 0, 56, 223, DateTimeKind.Utc).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 13, 20, 15, 56, 223, DateTimeKind.Utc).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 12, 20, 45, 56, 223, DateTimeKind.Utc).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 12, 20, 55, 56, 223, DateTimeKind.Utc).AddTicks(5896));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "StartCityId" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 0, 0, 0, 0)), 3L });

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8723), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8727), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 13, 18, 32, 18, 493, DateTimeKind.Unspecified).AddTicks(8733), new TimeSpan(0, 0, 0, 0, 0)));

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
    }
}
