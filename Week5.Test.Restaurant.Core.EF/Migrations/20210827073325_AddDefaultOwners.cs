using Microsoft.EntityFrameworkCore.Migrations;

namespace Week5.Test.Restaurant.Core.EF.Migrations
{
    public partial class AddDefaultOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID_User", "IsOwner", "Password", "Username" },
                values: new object[] { 1, true, "1234", "Alfredo" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID_User", "IsOwner", "Password", "Username" },
                values: new object[] { 2, true, "1234", "Maria" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID_User",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID_User",
                keyValue: 2);
        }
    }
}
