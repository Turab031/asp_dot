using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pro5_auth.Migrations
{
    /// <inheritdoc />
    public partial class hashingandbcrypt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserModels",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserModels");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserModels",
                newName: "Password");
        }
    }
}
