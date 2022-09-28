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
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 2, "Tir", 13, "+2 Mana Per Kill", "+2 Mana Per Kill", "+2 Mana Per Kill", "+2 Mana Per Kill" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 3, "Nef", 13, "Knockback", "+30 Defense vs. Missile", "+30 Defense vs. Missile", "+30 Defense vs. Missile" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 4, "Eth", 15, "-25% Target Defense", "Regenerate Mana 15%", "Regenerate Mana 15%", "Regenerate Mana 15%" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 5, "Ith", 15, "+9 to Maximum Damage", "15% Damage Taken Goes to Mana", "15% Damage Taken Goes to Mana", "15% Damage Taken Goes to Mana" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 6, "Tal", 17, "75 Poison damage over 5 seconds", "+30% Poison Resistance", "+30% Poison Resistance", "+35% Poison Resistance" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 7, "Ral", 19, "+5-30 Fire Damage", "+30% Fire Resistance", "+30% Fire Resistance", "+35% Fire Resistance" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 8, "Ort", 21, "+1-50 Lightning Damage", "+30% Lightning Resistance", "+30% Lightning Resistance", "+35% Lightning Resistance" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 9, "Thul", 23, "+3-14 Cold Damage (Cold Length 3 seconds)", "+30% Cold Resistance", "+30% Cold Resistance", "+35% Cold Resistance" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 10, "Amn", 25, "7% Life Stolen Per Hit", "Attacker takes 14 damage", "Attacker takes 14 damage", "Attacker takes 14 damage" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 11, "Sol", 27, "+9 to Minimum Damage", "-7 Damage Taken", "-7 Damage Taken", "-7 Damage Taken" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 12, "Shael", 29, "Faster Attack Rate (+20)", "Faster Hit Recovery (+20)", "Faster Hit Recovery (+20)", "Faster Block Rate (+20)" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 13, "Dol", 31, "25% Chance that Hit Causes Monster to Flee", "+7 Replenish Life", "+7 Replenish Life", "+7 Replenish Life" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 14, "Hel", null, "-20% Requirements", "-15% Requirements", "-15% Requirements", "-15% Requirements" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 15, "Io", 35, "+10 Vitality", "+10 Vitality", "+10 Vitality", "+10 Vitality" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 16, "Lum", 37, "+10 Energy", "+10 Energy", "+10 Energy", "+10 Energy" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 17, "Ko", 39, "+10 Dexterity", "+10 Dexterity", "+10 Dexterity", "+10 Dexterity" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 18, "Fal", 41, "+10 Strength", "+10 Strength", "+10 Strength", "+10 Strength" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 19, "Lem", 43, "+75% Extra Gold from Monsters", "+50% Extra Gold from Monsters", "+50% Extra Gold from Monsters", "+50% Extra Gold from Monsters" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 20, "Pul", 45, "+75% Damage to Demons;+100 AR against Demons", "+30% Defense", "+30% Defense", "+30% Defense" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 21, "Um", 47, "25% Chance of Open Wounds", "+15% Resist All", "+15% Resist All", "+22% Resist All" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 22, "Mal", 49, "Prevent Monster Healing", "Reduce Magic Damage by 7", "Reduce Magic Damage by 7", "Reduce Magic Damage by 7" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 23, "Ist", 51, "+30% Better Chance of Finding Magical Items", "+25% Better Chance of Finding Magical Items", "+25% Better Chance of Finding Magical Items", "+25% Better Chance of Finding Magical Items" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 24, "Gul", 53, "+20% Attack Rating", "+5 to Max Resist Poison", "+5 to Max Resist Poison", "+5 to Max Resist Poison" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 25, "Vex", 55, "7% Mana Leech", "+5 to Max Fire Resist", "+5 to Max Fire Resist", "+5 to Max Fire Resist" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 26, "Ohm", 57, "+50% Damage", "+5 to Max. Resist Cold", "+5 to Max. Resist Cold", "+5 to Max. Resist Cold" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 27, "Lo", 59, "20% Chance of Deadly Strike", "+5 to Max. Resist Lightning", "+5 to Max. Resist Lightning", "+5 to Max. Resist Lightning" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 28, "Sur", 61, "20% Chance of Hit Blinds Target", "+5% total Mana", "+5% total Mana", "+50 Mana" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 29, "Ber", 63, "20% Chance of Crushing Blow", "Damage Reduced by 8%", "Damage Reduced by 8%", "Damage Reduced by 8%" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 30, "Jah", 65, "Ignores Target Defense", "+5% of total Hit Points", "+5% of total Hit Points", "+50 Hit Points" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 31, "Cham", 67, "32% Chance of Hit Freezing Target for 3 seconds", "Cannot be Frozen", "Cannot be Frozen", "Cannot be Frozen" }, schema: "resurrected");
            migrationBuilder.InsertData("runes", new string[] { "id", "name", "level", "in_weapon", "in_helmet", "in_body_armor", "in_shield" },
                                                 new object[] { 32, "Zod", 69, "Indestructible", "Indestructible", "Indestructible", "Indestructible" }, schema: "resurrected");
        }
    }
}
