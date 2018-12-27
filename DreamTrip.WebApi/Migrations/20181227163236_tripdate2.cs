using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamTrip.WebApi.Migrations
{
    public partial class tripdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Trips",
                newName: "TripDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Trips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TripDate",
                table: "Trips",
                newName: "Date");
        }
    }
}
