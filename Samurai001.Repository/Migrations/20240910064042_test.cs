using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samurai001.Repository.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samurai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HorseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samurai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samurai_Horse_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleSamurai",
                columns: table => new
                {
                    BattlesId = table.Column<int>(type: "int", nullable: false),
                    SamuraisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleSamurai", x => new { x.BattlesId, x.SamuraisId });
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Battle_BattlesId",
                        column: x => x.BattlesId,
                        principalTable: "Battle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Samurai_SamuraisId",
                        column: x => x.SamuraisId,
                        principalTable: "Samurai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Battle",
                columns: new[] { "Id", "Description", "Name", "end", "start" },
                values: new object[] { 100, "Really bad", "Imperious", new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Horse",
                columns: new[] { "Id", "name" },
                values: new object[] { 1, "Tarok" });

            migrationBuilder.InsertData(
                table: "Samurai",
                columns: new[] { "Id", "Age", "Description", "HorseId", "Name" },
                values: new object[] { 1, 20, "This is serios", 1, "Ulla Skallesmækker" });

            migrationBuilder.InsertData(
                table: "BattleSamurai",
                columns: new[] { "BattlesId", "SamuraisId" },
                values: new object[] { 100, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BattleSamurai_SamuraisId",
                table: "BattleSamurai",
                column: "SamuraisId");

            migrationBuilder.CreateIndex(
                name: "IX_Samurai_HorseId",
                table: "Samurai",
                column: "HorseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleSamurai");

            migrationBuilder.DropTable(
                name: "Battle");

            migrationBuilder.DropTable(
                name: "Samurai");

            migrationBuilder.DropTable(
                name: "Horse");
        }
    }
}
