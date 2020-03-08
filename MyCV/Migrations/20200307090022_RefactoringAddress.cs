using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCV.Migrations
{
    public partial class RefactoringAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_AddressId",
                table: "PersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_ApplicableCompany_AddressId",
                table: "ApplicableCompany");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ApplicableCompany");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "WorkExperience",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "PersonalInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PersonalInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PersonalInformation",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "PersonalInformation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zip",
                table: "PersonalInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Education",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExperienceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_CategoryId",
                table: "WorkExperience",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_CategoryId",
                table: "Education",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_ExperienceCategory_CategoryId",
                table: "Education",
                column: "CategoryId",
                principalTable: "ExperienceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_ExperienceCategory_CategoryId",
                table: "WorkExperience",
                column: "CategoryId",
                principalTable: "ExperienceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_ExperienceCategory_CategoryId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_ExperienceCategory_CategoryId",
                table: "WorkExperience");

            migrationBuilder.DropTable(
                name: "ExperienceCategory");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_CategoryId",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_Education_CategoryId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Education");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "PersonalInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PersonalInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ApplicableCompany",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_AddressId",
                table: "PersonalInformation",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicableCompany_AddressId",
                table: "ApplicableCompany",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicableCompany_Address_AddressId",
                table: "ApplicableCompany",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_Address_AddressId",
                table: "PersonalInformation",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
