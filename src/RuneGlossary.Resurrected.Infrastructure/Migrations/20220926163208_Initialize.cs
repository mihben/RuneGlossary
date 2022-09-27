using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RuneGlossary.Resurrected.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "resurrected");

            migrationBuilder.CreateAndFillClasses();
            migrationBuilder.CreateAndFillItemTypes();
            migrationBuilder.CreateAndFillRunes();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classes",
                schema: "resurrected");
        }
    }

    internal static class InitializeMigration
    {
        public static void CreateAndFillClasses(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                schema: "resurrected",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.id);
                });

            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 0, "Amazon" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 1, "Assassin" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 2, "Barbarian" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 3, "Druid" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 4, "Necromancer" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 5, "Paladin" }, schema: "resurrected");
            migrationBuilder.InsertData("classes", new string[] { "id", "name" }, new object[] { 6, "Sorceress" }, schema: "resurrected");
        }

        public static void CreateAndFillItemTypes(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "item_types",
                 schema: "resurrected",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     name = table.Column<string>(type: "text", nullable: false),
                     @class = table.Column<string>(name: "class", type: "text", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_item_types", x => x.id);
                 });

            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 0, "Helmet", "Armor" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 1, "Body Armor", "Armor" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 2, "Shield", "Armor" }, schema: "resurrected");

            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 3, "Axe", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 4, "Claw", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 5, "Club", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 6, "Dagger", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 7, "Hammer", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 8, "Javelin", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 9, "Mace", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 10, "Orb", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 11, "Scepter", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 12, "Sword", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 13, "Throwing Axe", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 14, "Throwing Knife", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 15, "Wand", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 16, "Bow", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 17, "Spear", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 18, "Crossbow", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 19, "Polearm", "Weapon" }, schema: "resurrected");
            migrationBuilder.InsertData("item_types", new string[] { "id", "name", "class" }, new object[] { 20, "Stave", "Weapon" }, schema: "resurrected");
        }

        public static void CreateAndFillRunes(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "runes",
                schema: "resurrected",
                columns: table => new
                {
                    Id = table.Column<int>(name: "id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "name", type: "text", nullable: false),
                    Level = table.Column<int>(name: "level", type: "integer", nullable: true),
                    InWeapon = table.Column<string>(name: "in_weapon", type: "text", nullable: false),
                    InHelmet = table.Column<string>(name: "in_helmet", type: "text", nullable: false),
                    InBodyArmor = table.Column<string>(name: "in_body_armor", type: "text", nullable: false),
                    InShield = table.Column<string>(name: "in_shield", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_runes", x => x.Id);
                });

            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 0, "El", 11, "+50 attack rating;+1 light radius", "+15 defense;+1 light radius", "+15 defense;+1 light radius", "+15 defense;+1 light radius" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 1, "Eld", 11, "+75% Damage vs. Undead;+50 Attack Rating vs. Undead", "Lowers Stamina drain by 15%", "Lowers Stamina drain by 15%", "+7% Blocking" }, schema: "resurrected");
        }
    }
}
