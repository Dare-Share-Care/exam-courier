using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courier.Web.Migrations
{
    /// <inheritdoc />
    public partial class fixed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1L,
                column: "TimeClaimed",
                value: new DateTime(2023, 11, 30, 19, 49, 21, 649, DateTimeKind.Local).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2L,
                column: "TimeClaimed",
                value: new DateTime(2023, 11, 30, 19, 49, 21, 649, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "TimeClaimed", "TimeDelivered" },
                values: new object[] { new DateTime(2023, 11, 30, 19, 49, 21, 649, DateTimeKind.Local).AddTicks(9645), new DateTime(2023, 11, 30, 19, 49, 21, 649, DateTimeKind.Local).AddTicks(9647) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1L,
                column: "TimeClaimed",
                value: new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2L,
                column: "TimeClaimed",
                value: new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "TimeClaimed", "TimeDelivered" },
                values: new object[] { new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6669), new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6671) });
        }
    }
}
