using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamTrip.WebApi.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Trips",
                nullable: false,
                defaultValue: 0);
        }
    }
}
