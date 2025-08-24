using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatentWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class updatedPatentGrant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grants_inPatents_ipId",
                table: "grants");

            migrationBuilder.DropForeignKey(
                name: "FK_grants_patents_patentId",
                table: "grants");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PatentGrant_PatentAndIP",
                table: "grants");

            migrationBuilder.RenameColumn(
                name: "ipId",
                table: "grants",
                newName: "internationalPatentipId");

            migrationBuilder.RenameIndex(
                name: "IX_grants_ipId",
                table: "grants",
                newName: "IX_grants_internationalPatentipId");

            migrationBuilder.UpdateData(
                table: "grants",
                keyColumn: "grantId",
                keyValue: 1001,
                column: "internationalPatentipId",
                value: null);

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
                principalColumn: "patentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grants_inPatents_internationalPatentipId",
                table: "grants");

            migrationBuilder.DropForeignKey(
                name: "FK_grants_patents_patentId",
                table: "grants");

            migrationBuilder.RenameColumn(
                name: "internationalPatentipId",
                table: "grants",
                newName: "ipId");

            migrationBuilder.RenameIndex(
                name: "IX_grants_internationalPatentipId",
                table: "grants",
                newName: "IX_grants_ipId");

            migrationBuilder.UpdateData(
                table: "grants",
                keyColumn: "grantId",
                keyValue: 1001,
                column: "ipId",
                value: 501);

            migrationBuilder.AddCheckConstraint(
                name: "CK_PatentGrant_PatentAndIP",
                table: "grants",
                sql: "patentId IS NOT NULL AND ipId IS NOT NULL");

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
    }
}
