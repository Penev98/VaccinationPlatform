using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccinationPlatform.Data.Migrations
{
    public partial class AddDescriptionToHospitalEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Vaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Diseases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Information",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "Information",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Bookings");
        }
    }
}
