using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate_Mvc_.Migrations
{
    /// <inheritdoc />
    public partial class xcvbn6543 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "DateCrated", "DateDeleted", "DeletedBy", "Description", "IsDeleted", "Name" },
                values: new object[] { "abcd", "Wahab", new DateTime(2024, 7, 24, 15, 24, 25, 865, DateTimeKind.Local).AddTicks(2266), null, null, "Well Completed Building", false, "Completed Buildings" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateDeleted",
                value: new DateTime(2024, 7, 24, 15, 24, 25, 865, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: "001",
                column: "DateCrated",
                value: new DateTime(2024, 7, 24, 15, 24, 25, 655, DateTimeKind.Local).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "Super001",
                columns: new[] { "DateCrated", "Password" },
                values: new object[] { new DateTime(2024, 7, 24, 15, 24, 25, 655, DateTimeKind.Local).AddTicks(3804), "$2a$11$JT14otW1WtwhBmxP5NBDR.YyUgelLN5Mo7gKoUT3tC28Bf0ZqBIOW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "abcd");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateDeleted",
                value: new DateTime(2024, 7, 23, 16, 53, 21, 959, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: "001",
                column: "DateCrated",
                value: new DateTime(2024, 7, 23, 16, 53, 21, 738, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "Super001",
                columns: new[] { "DateCrated", "Password" },
                values: new object[] { new DateTime(2024, 7, 23, 16, 53, 21, 738, DateTimeKind.Local).AddTicks(2186), "$2a$11$Ig03mgRmDvaycTKUuRrLO.GGnZ131o4TM7sPgj2DnuSIjGyDKJBSC" });
        }
    }
}
