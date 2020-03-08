using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCV.Migrations
{
    public partial class UpdatingPersonalInformationWithImageFileAnAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitae_Address_AddressId",
                table: "CurriculumVitae");

            migrationBuilder.DropIndex(
                name: "IX_CurriculumVitae_AddressId",
                table: "CurriculumVitae");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CurriculumVitae");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "PersonalInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageFileId",
                table: "PersonalInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_AddressId",
                table: "PersonalInformation",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_ImageFileId",
                table: "PersonalInformation",
                column: "ImageFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_Address_AddressId",
                table: "PersonalInformation",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_ImageFile_ImageFileId",
                table: "PersonalInformation",
                column: "ImageFileId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_Address_AddressId",
                table: "PersonalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_ImageFile_ImageFileId",
                table: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "ImageFile");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_AddressId",
                table: "PersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_ImageFileId",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "ImageFileId",
                table: "PersonalInformation");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "PersonalInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CurriculumVitae",
                type: "int",
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
    }
}
