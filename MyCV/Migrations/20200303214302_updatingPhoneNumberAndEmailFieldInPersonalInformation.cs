using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCV.Migrations
{
    public partial class updatingPhoneNumberAndEmailFieldInPersonalInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EMail",
                table: "PersonalInformation",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "PersonalInformation",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PersonalInformation",
                newName: "EMail");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
