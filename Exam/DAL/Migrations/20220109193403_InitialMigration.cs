using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MonsterName = table.Column<string>(type: "text", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    AttackModifiere = table.Column<int>(type: "integer", nullable: false),
                    AttackPerRound = table.Column<int>(type: "integer", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    DamageModifiere = table.Column<int>(type: "integer", nullable: false),
                    Weapon = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    MinAC = table.Column<int>(type: "integer", nullable: false),
                    DamagePerRound = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    AttackModifiere = table.Column<int>(type: "integer", nullable: false),
                    AttackPerRound = table.Column<int>(type: "integer", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    DamageModifiere = table.Column<int>(type: "integer", nullable: false),
                    Weapon = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    MinAC = table.Column<int>(type: "integer", nullable: false),
                    DamagePerRound = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifiere", "AttackPerRound", "Damage", "DamageModifiere", "DamagePerRound", "HitPoints", "MinAC", "MonsterName", "Weapon" },
                values: new object[,]
                {
                    { new Guid("51a14afb-3c36-448e-9aa4-c0d4a2c23d23"), 8, 16, 4, 3, 2, 10, 125, 10, "Revenant", 4 },
                    { new Guid("59e26b42-1b90-415a-8fc9-63563029b114"), 19, 13, 2, 4, 1, 10, 134, 10, "Dragonsoul", 1 },
                    { new Guid("6354f5c5-a7bd-4a71-8d6c-a4c6a62cd578"), 7, 15, 1, 3, 2, 10, 110, 10, "ShadowAssasin", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
