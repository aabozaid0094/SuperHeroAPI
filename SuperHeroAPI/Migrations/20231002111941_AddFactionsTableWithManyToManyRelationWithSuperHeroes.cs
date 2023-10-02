using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFactionsTableWithManyToManyRelationWithSuperHeroes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactionSuperHero",
                columns: table => new
                {
                    FactionsId = table.Column<int>(type: "int", nullable: false),
                    SuperHeroesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionSuperHero", x => new { x.FactionsId, x.SuperHeroesId });
                    table.ForeignKey(
                        name: "FK_FactionSuperHero_Factions_FactionsId",
                        column: x => x.FactionsId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactionSuperHero_SuperHeroes_SuperHeroesId",
                        column: x => x.SuperHeroesId,
                        principalTable: "SuperHeroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactionSuperHero_SuperHeroesId",
                table: "FactionSuperHero",
                column: "SuperHeroesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactionSuperHero");

            migrationBuilder.DropTable(
                name: "Factions");
        }
    }
}
