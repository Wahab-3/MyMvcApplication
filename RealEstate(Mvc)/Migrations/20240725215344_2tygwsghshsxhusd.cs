using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstate_Mvc_.Migrations
{
    /// <inheritdoc />
    public partial class _2tygwsghshsxhusd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateCrated",
                value: new DateTime(2024, 7, 25, 22, 53, 42, 146, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "DateCrated", "DateDeleted", "DeletedBy", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "abcd0987", "Wahab", new DateTime(2024, 7, 25, 22, 53, 42, 146, DateTimeKind.Local).AddTicks(4712), null, null, "unCompleted Building", false, "unCompleted Buildings" },
                    { "abcd123", "Wahab", new DateTime(2024, 7, 25, 22, 53, 42, 146, DateTimeKind.Local).AddTicks(4613), null, null, "Landed Property", false, "Landed Property" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "CreatedBy", "DateCrated", "DateDeleted", "DeletedBy", "Email", "IsAvailable", "IsDeleted", "ProfilePicturePath", "StaffNumber" },
                values: new object[] { "001", null, null, new DateTime(2024, 7, 25, 22, 53, 41, 848, DateTimeKind.Local).AddTicks(5044), "Wahab", "SuperAdmin@gmail.com", true, false, null, "Staff001" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateDeleted",
                value: new DateTime(2024, 7, 25, 22, 53, 42, 146, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: "001",
                column: "DateCrated",
                value: new DateTime(2024, 7, 25, 22, 53, 41, 848, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "Super001",
                columns: new[] { "DateCrated", "Password" },
                values: new object[] { new DateTime(2024, 7, 25, 22, 53, 41, 848, DateTimeKind.Local).AddTicks(5188), "$2a$11$qnjIlbbeDUe6wc49nS3RUuf6RhplNoBxOuT/W1iA05N0jW138k77e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "abcd0987");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "abcd123");

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: "001");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "abcd",
                column: "DateCrated",
                value: new DateTime(2024, 7, 24, 15, 24, 25, 865, DateTimeKind.Local).AddTicks(2266));

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
    }
}
