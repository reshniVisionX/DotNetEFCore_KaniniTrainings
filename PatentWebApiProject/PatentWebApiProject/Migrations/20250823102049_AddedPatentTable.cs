using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatentWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedPatentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grants_inPatents_internationalPatentipId",
                table: "grants");

            migrationBuilder.DropForeignKey(
                name: "FK_grants_patents_patentId",
                table: "grants");

            migrationBuilder.DropIndex(
                name: "IX_grants_internationalPatentipId",
                table: "grants");

            migrationBuilder.DropColumn(
                name: "internationalPatentipId",
                table: "grants");

            migrationBuilder.CreateIndex(
                name: "IX_grants_ipId",
                table: "grants",
                column: "ipId");

            migrationBuilder.AddForeignKey(
                name: "FK_grants_inPatents_ipId",
                table: "grants",
                column: "ipId",
                principalTable: "inPatents",
                principalColumn: "ipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grants_patents_patentId",
                table: "grants",
                column: "patentId",
                principalTable: "patents",
                principalColumn: "patentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grants_inPatents_ipId",
                table: "grants");

            migrationBuilder.DropForeignKey(
                name: "FK_grants_patents_patentId",
                table: "grants");

            migrationBuilder.DropIndex(
                name: "IX_grants_ipId",
                table: "grants");

            migrationBuilder.AddColumn<int>(
                name: "internationalPatentipId",
                table: "grants",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "grants",
                keyColumn: "grantId",
                keyValue: 1001,
                column: "internationalPatentipId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_grants_internationalPatentipId",
                table: "grants",
                column: "internationalPatentipId");

            migrationBuilder.AddForeignKey(
                name: "FK_grants_inPatents_internationalPatentipId",
                table: "grants",
                column: "internationalPatentipId",
                principalTable: "inPatents",
                principalColumn: "ipId");

            migrationBuilder.AddForeignKey(
                name: "FK_grants_patents_patentId",
                table: "grants",
                column: "patentId",
                principalTable: "patents",
                principalColumn: "patentId");
        }
    }
}
