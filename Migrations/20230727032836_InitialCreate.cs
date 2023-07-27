using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WrestlingMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Defunct = table.Column<bool>(type: "bit", nullable: false),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shuttered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wrestlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wrestlers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Defunct = table.Column<bool>(type: "bit", nullable: false),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Retired = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Championships_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionshipId = table.Column<int>(type: "int", nullable: true),
                    WrestlerId = table.Column<int>(type: "int", nullable: true),
                    ReignDateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReignDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reigns_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reigns_Wrestlers_WrestlerId",
                        column: x => x.WrestlerId,
                        principalTable: "Wrestlers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championships_PromotionId",
                table: "Championships",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reigns_ChampionshipId",
                table: "Reigns",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Reigns_WrestlerId",
                table: "Reigns",
                column: "WrestlerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reigns");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "Wrestlers");

            migrationBuilder.DropTable(
                name: "Promotions");
        }
    }
}
