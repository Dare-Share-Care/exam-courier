using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courier.Web.Migrations
{
    /// <inheritdoc />
    public partial class timeclaimed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeClaimed",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1L,
                column: "TimeClaimed",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2L,
                column: "TimeClaimed",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "TimeClaimed", "TimeDelivered" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 17, 58, 0, 471, DateTimeKind.Local).AddTicks(285) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeClaimed",
                table: "Deliveries");

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L,
                column: "TimeDelivered",
                value: new DateTime(2023, 11, 30, 16, 19, 58, 639, DateTimeKind.Local).AddTicks(9524));
        }
    }
}
