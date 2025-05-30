using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Shifts_ShiftId",
                table: "Pallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Users_DriverId",
                table: "Trucks");

            migrationBuilder.DropTable(
                name: "RouteShifts");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_DriverId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_ShiftId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Trucks");

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
                name: "Width",
                table: "Trucks",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "FreightId",
                table: "Pallets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pallets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Freights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TruckId = table.Column<long>(type: "bigint", nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    DueStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freights_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Freights_Users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageThreads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromId = table.Column<long>(type: "bigint", nullable: false),
                    ToId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Teaser = table.Column<string>(type: "text", nullable: false),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageThreads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageThreads_Users_FromId",
                        column: x => x.FromId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageThreads_Users_ToId",
                        column: x => x.ToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreightRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    FreightId = table.Column<long>(type: "bigint", nullable: false),
                    RouteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreightRoutes_Freights_FreightId",
                        column: x => x.FreightId,
                        principalTable: "Freights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreightRoutes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MessageThreadId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_MessageThreads_MessageThreadId",
                        column: x => x.MessageThreadId,
                        principalTable: "MessageThreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad", "Width" },
                values: new object[] { 0m, 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad", "Width" },
                values: new object[] { 0m, 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad", "Width" },
                values: new object[] { 0m, 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad", "Width" },
                values: new object[] { 0m, 0m, 0, 0m });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Height", "Length", "MaxPalletsLoad", "Width" },
                values: new object[] { 0m, 0m, 0, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_FreightId",
                table: "Pallets",
                column: "FreightId");

            migrationBuilder.CreateIndex(
                name: "IX_FreightRoutes_FreightId",
                table: "FreightRoutes",
                column: "FreightId");

            migrationBuilder.CreateIndex(
                name: "IX_FreightRoutes_RouteId",
                table: "FreightRoutes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Freights_DriverId",
                table: "Freights",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Freights_TruckId",
                table: "Freights",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageThreadId",
                table: "Messages",
                column: "MessageThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageThreads_FromId",
                table: "MessageThreads",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageThreads_ToId",
                table: "MessageThreads",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Freights_FreightId",
                table: "Pallets",
                column: "FreightId",
                principalTable: "Freights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_Freights_FreightId",
                table: "Pallets");

            migrationBuilder.DropTable(
                name: "FreightRoutes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Freights");

            migrationBuilder.DropTable(
                name: "MessageThreads");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_FreightId",
                table: "Pallets");

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
                name: "Width",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "FreightId",
                table: "Pallets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pallets");

            migrationBuilder.AddColumn<long>(
                name: "DriverId",
                table: "Trucks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Height = table.Column<decimal>(type: "numeric", nullable: false),
                    Length = table.Column<decimal>(type: "numeric", nullable: false),
                    Width = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrailerId = table.Column<long>(type: "bigint", nullable: true),
                    TruckId = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shifts_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RouteShifts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RouteId = table.Column<long>(type: "bigint", nullable: false),
                    ShiftId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteShifts_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteShifts_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trailers",
                columns: new[] { "Id", "Height", "Length", "Width" },
                values: new object[] { 1L, 4m, 12m, 2.5m });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DriverId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DriverId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DriverId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DriverId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DriverId",
                value: 4L);

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_DriverId",
                table: "Trucks",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_ShiftId",
                table: "Pallets",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteShifts_RouteId",
                table: "RouteShifts",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteShifts_ShiftId",
                table: "RouteShifts",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_TrailerId",
                table: "Shifts",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_TruckId",
                table: "Shifts",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_Shifts_ShiftId",
                table: "Pallets",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Users_DriverId",
                table: "Trucks",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
