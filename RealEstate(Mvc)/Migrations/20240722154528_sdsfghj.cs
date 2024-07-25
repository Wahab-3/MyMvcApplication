using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate_Mvc_.Migrations
{
    /// <inheritdoc />
    public partial class sdsfghj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "DateCrated", "DateDeleted", "DeletedBy", "Description", "IsDeleted", "Name" },
                values: new object[] { "abcd", "Wahab", null, new DateTime(2024, 7, 22, 16, 45, 25, 681, DateTimeKind.Local).AddTicks(3139), null, "SuperAdmin on the app", false, "Superadmin" });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Address", "Age", "CreatedBy", "DateCrated", "DateDeleted", "DeletedBy", "Dob", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "PhoneNumber", "ProfilePicturePath", "RoleName", "StaffTagNumber" },
                values: new object[] { "001", "Abk", 17, null, new DateTime(2024, 7, 22, 16, 45, 24, 866, DateTimeKind.Local).AddTicks(3396), null, "Wahab", new DateTime(2007, 2, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), "SuperAdmin@gmail.com", "AbdulWahab", 1, false, "Jokosenumi", 8080954101L, null, "SuperAdmin", "SuperAdmin001" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "DateCrated", "DateDeleted", "DeletedBy", "Email", "FullName", "IsDeleted", "Password" },
                values: new object[] { "Super001", "Wahab", new DateTime(2024, 7, 22, 16, 45, 24, 866, DateTimeKind.Local).AddTicks(4213), null, null, "SuperAdmin@gmail.com", "JokosenumiAbdulWahab", false, "qwert$2a$11$R/Z6TCpnA3YhV.0c7OYwIeq7cVxTwZ5CJf3K27eNkNFZPH6lmXQvK" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { "qwer", "abcd", "Super001" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "qwer");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "abcd");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "Super001");
        }
    }
}
