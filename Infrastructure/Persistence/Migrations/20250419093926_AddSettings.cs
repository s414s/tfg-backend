using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Pallets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Pallets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PricePerKilogram = table.Column<decimal>(type: "numeric", nullable: false),
                    PricePerLiterFuel = table.Column<decimal>(type: "numeric", nullable: false),
                    PricePerHourDriver = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "PricePerHourDriver", "PricePerKilogram", "PricePerLiterFuel" },
                values: new object[] { 1L, 20m, 50m, 1.80m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Pallets");

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 15, 16, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(7002), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 15, 16, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 15, 16, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(7014), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Freights",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 4, 15, 16, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(7018), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 15, 18, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(353), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 14, 18, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(357), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 15, 16, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(364), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 14, 18, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 14, 18, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(369), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 14, 18, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(370), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 4, 15, 18, 19, 33, 842, DateTimeKind.Unspecified).AddTicks(374), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 4, 14, 18, 49, 33, 842, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 4, 15, 18, 4, 33, 841, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 4, 15, 18, 19, 33, 841, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 4, 14, 18, 49, 33, 841, DateTimeKind.Utc).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 4, 14, 18, 59, 33, 841, DateTimeKind.Utc).AddTicks(7225));
        }
    }
}
