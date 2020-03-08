using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCV.Migrations
{
    public partial class AddingAddressToCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CurriculumVitae",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVitae_AddressId",
                table: "CurriculumVitae",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumVitae_Address_AddressId",
                table: "CurriculumVitae",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitae_Address_AddressId",
                table: "CurriculumVitae");

            migrationBuilder.DropIndex(
                name: "IX_CurriculumVitae_AddressId",
                table: "CurriculumVitae");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CurriculumVitae");
        }
    }
}
