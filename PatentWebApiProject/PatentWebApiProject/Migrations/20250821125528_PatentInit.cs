using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatentWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class PatentInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    memId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.memId);
                });

            migrationBuilder.CreateTable(
                name: "patents",
                columns: table => new
                {
                    patentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patents", x => x.patentId);
                });

            migrationBuilder.CreateTable(
                name: "inPatents",
                columns: table => new
                {
                    ipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patentId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fieledDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inPatents", x => x.ipId);
                    table.ForeignKey(
                        name: "FK_inPatents_patents_patentId",
                        column: x => x.patentId,
                        principalTable: "patents",
                        principalColumn: "patentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersPatent",
                columns: table => new
                {
                    membersmemId = table.Column<int>(type: "int", nullable: false),
                    patentspatentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersPatent", x => new { x.membersmemId, x.patentspatentId });
                    table.ForeignKey(
                        name: "FK_MembersPatent_members_membersmemId",
                        column: x => x.membersmemId,
                        principalTable: "members",
                        principalColumn: "memId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersPatent_patents_patentspatentId",
                        column: x => x.patentspatentId,
                        principalTable: "patents",
                        principalColumn: "patentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grants",
                columns: table => new
                {
                    grantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patentId = table.Column<int>(type: "int", nullable: true),
                    ipId = table.Column<int>(type: "int", nullable: true),
                    domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    score = table.Column<int>(type: "int", nullable: true),
                    grantDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    internationalPatentipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grants", x => x.grantId);
                    table.CheckConstraint("CK_PatentGrant_PatentAndIP", "patentId IS NOT NULL AND ipId IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_grants_inPatents_internationalPatentipId",
                        column: x => x.internationalPatentipId,
                        principalTable: "inPatents",
                        principalColumn: "ipId");
                    table.ForeignKey(
                        name: "FK_grants_patents_patentId",
                        column: x => x.patentId,
                        principalTable: "patents",
                        principalColumn: "patentId");
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "memId", "city", "createdAt", "email", "name", "role" },
                values: new object[,]
                {
                    { 1, "Chennai", new DateTime(2024, 8, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), "janu@gmail.com", "Janu", "user" },
                    { 2, "Chennai", new DateTime(2024, 8, 21, 10, 5, 0, 0, DateTimeKind.Unspecified), "lali@gmail.com", "Laith", "user" }
                });

            migrationBuilder.InsertData(
                table: "patents",
                columns: new[] { "patentId", "appliedDate", "description", "status", "title" },
                values: new object[,]
                {
                    { 101, new DateTime(2024, 9, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), "AI-powered biomedical cancer detection system", "Pending", "Cancer Detection Patent" },
                    { 102, new DateTime(2024, 9, 21, 9, 30, 0, 0, DateTimeKind.Unspecified), "Novel vaccine delivery method", "Pending", "Vaccine Delivery Patent" }
                });

            migrationBuilder.InsertData(
                table: "grants",
                columns: new[] { "grantId", "domain", "grantDate", "internationalPatentipId", "ipId", "patentId", "score" },
                values: new object[] { 1001, "Biomedical", new DateTime(2025, 4, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 501, 101, 7 });

            migrationBuilder.InsertData(
                table: "inPatents",
                columns: new[] { "ipId", "country", "fieledDate", "patentId", "status" },
                values: new object[] { 501, "US", new DateTime(2025, 6, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), 101, "Pending" });

            migrationBuilder.CreateIndex(
                name: "IX_grants_internationalPatentipId",
                table: "grants",
                column: "internationalPatentipId");

            migrationBuilder.CreateIndex(
                name: "IX_grants_patentId",
                table: "grants",
                column: "patentId");

            migrationBuilder.CreateIndex(
                name: "IX_inPatents_patentId",
                table: "inPatents",
                column: "patentId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersPatent_patentspatentId",
                table: "MembersPatent",
                column: "patentspatentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grants");

            migrationBuilder.DropTable(
                name: "MembersPatent");

            migrationBuilder.DropTable(
                name: "inPatents");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "patents");
        }
    }
}
