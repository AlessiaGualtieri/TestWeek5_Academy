using Microsoft.EntityFrameworkCore.Migrations;

namespace Week5.Test.Restaurant.Core.EF.Migrations
{
    public partial class AddDefaultDishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dish",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "ID_Dish", "Description", "Name", "Price", "Type" },
                values: new object[] { 1, "Gnocchi con salsa e ragu di cervo", "Gnocchi", 12m, 0 });

            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "ID_Dish", "Description", "Name", "Price", "Type" },
                values: new object[] { 2, "Stufato di maiale", "Stufato", 18.60m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "ID_Dish",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "ID_Dish",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dish");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dish",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}
