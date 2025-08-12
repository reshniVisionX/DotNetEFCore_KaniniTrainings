using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_MVC_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "students",
                type: "int",
                nullable: true
                );

            migrationBuilder.CreateIndex(
                name: "IX_students_ItemId",
                table: "students",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_items_ItemId",
                table: "students",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_items_ItemId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_ItemId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "students");
        }
    }
}
