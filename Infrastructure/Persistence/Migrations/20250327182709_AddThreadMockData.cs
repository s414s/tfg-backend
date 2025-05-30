using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddThreadMockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MessageThreads",
                columns: new[] { "Id", "Created", "CreatedBy", "DeletedBy", "DeletedDate", "FromId", "LastModified", "LastModifiedBy", "Subject", "Teaser", "ToId" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(2025, 3, 27, 18, 27, 8, 580, DateTimeKind.Unspecified).AddTicks(9730), new TimeSpan(0, 0, 0, 0, 0)), 1L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L, "Project Kickoff", "Let's schedule a kickoff meeting for the new project.", 2L },
                    { 2L, new DateTimeOffset(new DateTime(2025, 3, 27, 16, 27, 8, 580, DateTimeKind.Unspecified).AddTicks(9738), new TimeSpan(0, 0, 0, 0, 0)), 1L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L, "Meeting Reminder", "Don't forget about our meeting tomorrow at 10 AM.", 2L },
                    { 3L, new DateTimeOffset(new DateTime(2025, 3, 26, 18, 27, 8, 580, DateTimeKind.Unspecified).AddTicks(9742), new TimeSpan(0, 0, 0, 0, 0)), 1L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L, "No Subject", "", 2L },
                    { 4L, new DateTimeOffset(new DateTime(2025, 3, 27, 17, 57, 8, 580, DateTimeKind.Unspecified).AddTicks(9746), new TimeSpan(0, 0, 0, 0, 0)), 1L, 0L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L, "Follow-up on Proposal", "Please review the attached proposal document.", 2L }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Date", "IsRead", "MessageThreadId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 3, 27, 17, 42, 8, 580, DateTimeKind.Utc).AddTicks(6939), false, 1L, "Hey, are you available for a call?", 1L },
                    { 2L, new DateTime(2025, 3, 27, 17, 57, 8, 580, DateTimeKind.Utc).AddTicks(6944), true, 1L, "Yes, I can join in 5 minutes.", 1L },
                    { 3L, new DateTime(2025, 3, 26, 18, 27, 8, 580, DateTimeKind.Utc).AddTicks(6947), false, 2L, "The meeting has been rescheduled to tomorrow.", 1L },
                    { 4L, new DateTime(2025, 3, 26, 18, 37, 8, 580, DateTimeKind.Utc).AddTicks(6951), true, 2L, "Thanks for the update!", 1L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MessageThreads",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
