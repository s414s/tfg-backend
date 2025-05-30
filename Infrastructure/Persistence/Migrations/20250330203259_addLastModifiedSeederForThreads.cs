using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addLastModifiedSeederForThreads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "MaxPalletsLoad",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pallets");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Trucks",
                newName: "MaxWeight");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "Pallets",
                newName: "OriginId");

            migrationBuilder.AddColumn<long>(
                name: "DestinationId",
                table: "Pallets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StartCityId",
                table: "Freights",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 30, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9753), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9757), new TimeSpan(0, 0, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 30, 18, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9761), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9762), new TimeSpan(0, 0, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9765), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9766), new TimeSpan(0, 0, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 30, 20, 2, 59, 68, DateTimeKind.Unspecified).AddTicks(9769), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 29, 20, 32, 59, 68, DateTimeKind.Unspecified).AddTicks(9770), new TimeSpan(0, 0, 0, 0, 0)), 1L });

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

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_DestinationId",
                table: "Pallets",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_OriginId",
                table: "Pallets",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Freights_StartCityId",
                table: "Freights",
                column: "StartCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Freights_Cities_StartCityId",
                table: "Freights",
                column: "StartCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Cities_DestinationId",
                table: "Pallets",
                column: "DestinationId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Cities_OriginId",
                table: "Pallets",
                column: "OriginId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freights_Cities_StartCityId",
                table: "Freights");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Cities_DestinationId",
                table: "Pallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Cities_OriginId",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_DestinationId",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_OriginId",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_Freights_StartCityId",
                table: "Freights");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "StartCityId",
                table: "Freights");

            migrationBuilder.RenameColumn(
                name: "MaxWeight",
                table: "Trucks",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "OriginId",
                table: "Pallets",
                newName: "ShiftId");

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Trucks",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "Trucks",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaxPalletsLoad",
                table: "Trucks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Pallets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Pallets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 27, 18, 27, 8, 580, DateTimeKind.Unspecified).AddTicks(9730), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 27, 16, 27, 8, 580, DateTimeKind.Unspecified).AddTicks(9738), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 26, 18, 27, 8, 580, DateTimeKind.Unspecified).AddTicks(9742), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Created", "LastModified", "LastModifiedBy" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 27, 17, 57, 8, 580, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2025, 3, 27, 17, 42, 8, 580, DateTimeKind.Utc).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2025, 3, 27, 17, 57, 8, 580, DateTimeKind.Utc).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2025, 3, 26, 18, 27, 8, 580, DateTimeKind.Utc).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Date",
                value: new DateTime(2025, 3, 26, 18, 37, 8, 580, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad" },
                values: new object[] { 0m, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad" },
                values: new object[] { 0m, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad" },
                values: new object[] { 0m, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad" },
                values: new object[] { 0m, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad" },
                values: new object[] { 0m, 0m, 0 });
        }
    }
}
