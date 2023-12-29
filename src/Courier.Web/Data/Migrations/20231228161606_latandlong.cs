using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courier.Web.Migrations
{
    /// <inheritdoc />
    public partial class latandlong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Deliveries",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Deliveries",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Latitude", "Longitude", "TimeClaimed" },
                values: new object[] { null, null, new DateTime(2023, 12, 28, 17, 16, 6, 158, DateTimeKind.Local).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Latitude", "Longitude", "TimeClaimed" },
                values: new object[] { null, null, new DateTime(2023, 12, 28, 17, 16, 6, 158, DateTimeKind.Local).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Latitude", "Longitude", "TimeClaimed", "TimeDelivered" },
                values: new object[] { null, null, new DateTime(2023, 12, 28, 17, 16, 6, 158, DateTimeKind.Local).AddTicks(4278), new DateTime(2023, 12, 28, 17, 16, 6, 158, DateTimeKind.Local).AddTicks(4280) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Deliveries");

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
    }
}
