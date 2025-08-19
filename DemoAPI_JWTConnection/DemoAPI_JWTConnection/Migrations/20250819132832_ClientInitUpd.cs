using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI_JWTConnection.Migrations
{
    /// <inheritdoc />
    public partial class ClientInitUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Clients");
        }
    }
}
