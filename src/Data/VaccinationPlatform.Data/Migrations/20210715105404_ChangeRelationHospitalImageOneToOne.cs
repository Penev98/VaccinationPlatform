using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccinationPlatform.Data.Migrations
{
    public partial class ChangeRelationHospitalImageOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_HospitalId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HospitalId",
                table: "Images",
                column: "HospitalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_HospitalId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HospitalId",
                table: "Images",
                column: "HospitalId");
        }
    }
}
