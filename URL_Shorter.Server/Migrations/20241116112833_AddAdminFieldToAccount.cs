using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL_Shorter.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminFieldToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Accounts");
        }
    }
}
