using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCV.Migrations
{
    public partial class ImageCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_ImageFile_ImageFileId",
                table: "PersonalInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "PersonalInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImageFileId",
                table: "PersonalInformation",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_ImageFile_ImageFileId",
                table: "PersonalInformation",
                column: "ImageFileId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_ImageFile_ImageFileId",
                table: "PersonalInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "PersonalInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ImageFileId",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_ImageFile_ImageFileId",
                table: "PersonalInformation",
                column: "ImageFileId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
