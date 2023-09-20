using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novin.Foodland.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Restaurants",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "LogoType",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "ApplicationUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LogoType",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "ApplicationUsers");
        }
    }
}
