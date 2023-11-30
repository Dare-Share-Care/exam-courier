using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courier.Web.Migrations
{
    /// <inheritdoc />
    public partial class @fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeClaimed",
                table: "Deliveries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DeliveryAddress", "TimeClaimed" },
                values: new object[] { "Janusevej 90, 2300 København S", new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6615) });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DeliveryAddress", "TimeClaimed" },
                values: new object[] { "Frederiksgade 9, 8000 Helsingør C", new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6666) });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DeliveryAddress", "TimeClaimed", "TimeDelivered" },
                values: new object[] { "Julisvej 9, 2300 København S", new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6669), new DateTime(2023, 11, 30, 19, 40, 49, 736, DateTimeKind.Local).AddTicks(6671) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeClaimed",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DeliveryAddress", "TimeClaimed" },
                values: new object[] { "Some address", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DeliveryAddress", "TimeClaimed" },
                values: new object[] { "Some address", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DeliveryAddress", "TimeClaimed", "TimeDelivered" },
                values: new object[] { "Some address", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 17, 58, 0, 471, DateTimeKind.Local).AddTicks(285) });
        }
    }
}
