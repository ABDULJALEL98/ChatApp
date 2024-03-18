using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class messageSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "DateRead", "IsActive", "MessageSend", "ModifiedDate", "RecipientDeleted", "RecipientId", "RecipientUserName", "SenderDeleted", "SenderId", "SenderUserName" },
                values: new object[,]
                {
                    { 1, "test-one", null, true, new DateTime(2024, 3, 18, 13, 21, 49, 397, DateTimeKind.Utc).AddTicks(9490), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "ahmed", false, 1, "ali" },
                    { 2, "test-two", null, true, new DateTime(2024, 3, 18, 13, 21, 49, 397, DateTimeKind.Utc).AddTicks(9497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "ahmed", false, 1, "mohamad" },
                    { 3, "test-two", null, true, new DateTime(2024, 3, 18, 13, 21, 49, 397, DateTimeKind.Utc).AddTicks(9500), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "ahmed", false, 1, "basem" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
