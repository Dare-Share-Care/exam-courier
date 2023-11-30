using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Courier.Web.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "CourierId", "DeliveryAddress", "DeliveryStatus", "OrderId", "TimeDelivered" },
                values: new object[,]
                {
                    { 1L, 1L, "Some address", 0, 1L, null },
                    { 2L, 2L, "Some address", 0, 2L, null },
                    { 3L, 3L, "Some address", 1, 3L, new DateTime(2023, 11, 30, 16, 19, 58, 639, DateTimeKind.Local).AddTicks(9524) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
