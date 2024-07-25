using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate_Mvc_.Migrations
{
    /// <inheritdoc />
    public partial class rderwywiows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateDeleted",
                value: new DateTime(2024, 7, 22, 16, 45, 25, 681, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: "001",
                column: "DateCrated",
                value: new DateTime(2024, 7, 22, 16, 45, 24, 866, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "Super001",
                columns: new[] { "DateCrated", "Password" },
                values: new object[] { new DateTime(2024, 7, 22, 16, 45, 24, 866, DateTimeKind.Local).AddTicks(4213), "qwert$2a$11$R/Z6TCpnA3YhV.0c7OYwIeq7cVxTwZ5CJf3K27eNkNFZPH6lmXQvK" });
        }
    }
}
