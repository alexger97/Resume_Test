using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_Resume.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementGraphs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    DominateLevel = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    ElementGraphId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementGraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementGraphs_ElementGraphs_ElementGraphId",
                        column: x => x.ElementGraphId,
                        principalTable: "ElementGraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementGraphs_ElementGraphId",
                table: "ElementGraphs",
                column: "ElementGraphId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementGraphs");
        }
    }
}
