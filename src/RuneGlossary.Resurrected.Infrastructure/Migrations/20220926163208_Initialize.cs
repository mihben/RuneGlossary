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
            migrationBuilder.CreateAndFillSkills();
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

        public static void CreateAndFillSkills(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "skills",
               schema: "resurrected",
               columns: table => new
               {
                   id = table.Column<int>(type: "integer", nullable: false)
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   name = table.Column<string>(type: "text", nullable: false),
                   description = table.Column<string>(type: "text", nullable: false),
                   url = table.Column<string>(type: "text", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_skills", x => x.id);
               });

            var index = 0;
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Fanaticism", "Fanaticism increases the damage, attack speed, and attack rating of the Paladin and everyone in his party.", "https://diablo2.diablowiki.net/Fanaticism" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Werebear", "This skill enables the Druid to transform into a Werebear. It includes substantial bonuses to his defense, damage, and life.", "https://diablo2.diablowiki.net/Werebear" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Lycanthropy", "This skill adds a passive bonus that allows the Druid to remain in fur form much longer. There is also a substantial hit point boost.", "https://diablo2.diablowiki.net/Lycanthropy" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Summon Grizzly", "Summoned Grizzlies are fierce minions, capable of inflicting heavy damage. Grizzlies move slowly, but have strong attacks that stun and knock back their targets.", "https://diablo2.diablowiki.net/Summon_Grizzly" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Corpse Explosion", "One of the messiest and most fun skills in the game, Corpse Explosion detonates fallen monster corpses in messy sprays of bone and blood, striking all nearby enemies for substantial fire and physical damage.", "https://diablo2.diablowiki.net/Corpse_Explosion" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Bone Armor", "An orbiting shield that absorbs a set amount of physical damage before vanishing.", "https://diablo2.diablowiki.net/Bone_Armor" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Bone Spear", "Bone Spear fires a straight shot of magical damage bone that can pass through any number of targets. It does less damage to each target than Bone Spirit (until very high levels), but can hit multiple enemies, and is very effective against large mobs, or in narrow hallways, such as inside the Maggot Lair. Their damage is magical so only by raise skill levels can you increase it.", "https://diablo2.diablowiki.net/Bone_Spear" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Thorns", "Creates a spiky barrier around the Paladin and all in his party, reflecting huge damage back against melee, physical attackers. Has no effect against ranged or elemental attacks.", "https://diablo2.diablowiki.net/Thorns" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Spirit of Barbs", "This spirit bestows a Thorns aura on the Druid and all in his party.", "https://diablo2.diablowiki.net/Spirit_of_Barbs" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Amplify Damage", "Amplify damage greatly increases the physical damage taken by any afflicted target.", "https://diablo2.diablowiki.net/Amplify_Damage" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Exploding Arrow", "Enchants arrows by adding explosive fire damage to them. The flame splashes enough to strike several monsters in a tight cluster, and there is an accuracy bonus as well.", "https://diablo2.diablowiki.net/Exploding_Arrow#Exploding_Arrow" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Poison Nova", "Poison Nova sends out an expanding circle of toxic bolts, poisoning everything within range, and virtually everything on the screen.", "https://diablo2.diablowiki.net/Poison_Nova" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Battle Command", "Battle Command adds a +1 to all of the Barbarian's skills, and does the same for all characters and minions in his party.", "https://diablo2.diablowiki.net/Battle_Command" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Battle Orders", "Improve party members' life, mana and stamina.", "https://diablo2.diablowiki.net/Battle_Orders" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Battle Cry", "Fearsome cry reduces enemy effectiveness.", "https://diablo2.diablowiki.net/Battle_Cry" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Frozen Orb", "One of the more awesome spells in the game, Frozen Orb fires out a glowing orb of ice that spins across most of the visible screen, emitting dozens of tiny Ice Bolts in all directions.", "https://diablo2.diablowiki.net/Frozen_Orb" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Charged Bolt", "Charged bolt is one of the first skills a sorceress can learn, and is one of the few level 1 skills that scales well end game.", "https://diablo2.diablowiki.net/Charged_Bolt" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Whirlwind", "Whirlwind is the Tasmanian Devil of Barbarian skills, turning the character into a spinning death-dealer, capable of passing through huge mobs and hitting dozens of targets with a single use of the skill.", "https://diablo2.diablowiki.net/Whirlwind" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Chain Lightning", "Chain Lightning jumps from target to target, and can be quite impressive when cast on a cluster of enemies.", "https://diablo2.diablowiki.net/Chain_Lightning" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Static Field", "Static Field hits every monster in range, instantly chopping 25% off of their current hit points (similar to crushing blow).", "https://diablo2.diablowiki.net/Static" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Summon Spirit Wolf", "This gift of Nature allows the Druid to conjure forth one or more wolf allies who, with their mystical powers, provide the Druid a potent and ferocious colleague.", "https://diablo2.diablowiki.net/Summon_Spirit_Wolf" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Glacial Spike", "Shoots a large snowball that hits with substantial damage and a large splash effect, freezing the targeted monster and anything within 2.6 yards.", "https://diablo2.diablowiki.net/Glacial_Spike" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Blood Golem", "Blood Golems are linked to the Necromancer who casts them. As the Blood Golem damages the target it leeches life, and shares this with the Necromancer.", "https://diablo2.diablowiki.net/Blood_Golem" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Mind Blast", "Focusing her anima, an Assassin using this potent ability can crush the will of a group of enemies. Mind Blast stuns and confuses the feeble minded into attacking their comrades.", "https://diablo2.diablowiki.net/Mind_Blast" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Terror", "Cursed monsters run away at very high speed.", "https://diablo2.diablowiki.net/Terror" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Confuse", "Confused monsters attack whatever target is nearest them, including other monsters.", "https://diablo2.diablowiki.net/Confuse" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Volcano", "A more powerful version of Fissure, the Volcano erupts from one point and deals substantial fire damage to everything in the vicinity.", "https://diablo2.diablowiki.net/Volcano" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Holy Freeze", "This aura chills and slows the movement and attack speed of all enemies within range. It also deals constant cold damage, and adds cold damage to the Paladin's attacks.", "https://diablo2.diablowiki.net/Holy_Freeze" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Venom", "Poison use is another technique an Assassin has to help even the odds when battling demons and their ilk. An Assassin who has mastered this skill secretly coats her weapons with vile toxins.", "https://diablo2.diablowiki.net/Venom_(skill)" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Hydra", "Hydras are three-headed dragons composed of pure flame. The heads each fire a constant stream of Fire Bolts, dealing damage to the target, but not splashing to the sides.", "https://diablo2.diablowiki.net/Hydra" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Holy Fire", "Holy Fire adds fire damage to the Paladin's attacks, as well as dealing a few points of fire damage to every monster in range.", "https://diablo2.diablowiki.net/Holy_Fire" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Holy Shock", "Holy Shock adds lightning damage to the Paladin's attacks, as well as dealing a few points of lightning damage to every monster in range.", "https://diablo2.diablowiki.net/Holy_Shock" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Teleport", "Teleport moves the Sorceress instantly to any valid location she can point her cursor at.", "https://diablo2.diablowiki.net/Teleport" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Blaze", "Blaze leaves a trail of fire behind the Sorceress as she walks or runs along, for as long as she keeps the spell active.", "https://diablo2.diablowiki.net/Blaze" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Fireball", "A substantial upgrade from Firebolt, Fireballs are larger and more damaging, and they hit with splash damage, burning the target and any nearby monsters too.", "https://diablo2.diablowiki.net/Fireball" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Warmth", "Warmth increases the Sorceress' mana regeneration rate.", "https://diablo2.diablowiki.net/Warmth" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Revive", "Revives the dead monster, raising it up in its living form, but coloured dark gray.", "https://diablo2.diablowiki.net/Revive" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Life Tap", "Life Tap causes huge life leech to flow to any physical damage attacker.", "https://diablo2.diablowiki.net/Life_Tap" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Defiance", "This aura boosts the defense of the Paladin and all characters and minions in his party.", "https://diablo2.diablowiki.net/Defiance" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Chilling Armor", "Chilling Armor provides a slightly smaller defensive bonus than Shiver Armor (but larger than Frozen Armor).", "https://diablo2.diablowiki.net/Chilling_Armor" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Frenzy", "Frenzy allows the Barbarian to strike and move much faster, with any skill.", "https://diablo2.diablowiki.net/Frenzy" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Dim Vision", "Monsters that have had their vision dimmed no longer see their enemies.", "https://diablo2.diablowiki.net/Dim_Vision" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Meteor", "A flaming ball of rock is called down from above, dealing explosive damage to the target and leaving a patch of fiery burning earth behind.", "https://diablo2.diablowiki.net/Meteor" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Vigor", "Vigor boosts the running speed, maximum stamina, and stamina regeneration rate for the Paladin and all in his party.", "https://diablo2.diablowiki.net/Vigor" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Valkyrie", "Valkyries are powerful magical tanks. They spawn with high defense and hit points, and can stand up to a tremendous amount of damage.", "https://diablo2.diablowiki.net/Valkyrie" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Oak Sage", "The Oak Sage spirit floats around, radiating a hit point enhancing aura that affects the Druid and all characters and minions in his party.", "https://diablo2.diablowiki.net/Oak_Sage" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Raven", "Ravens swarm in a cloud and look nifty, but their damage is negligible and their AI is lacking.", "https://diablo2.diablowiki.net/Raven" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Blizzard", "Blizzard is an area effect spell, calling down an icy storm that chills and cold damages everything over a wide area.", "https://diablo2.diablowiki.net/Blizzard" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Frost Nova", "Creates and expanding ring of ice that damages enemies with cold damage and slows enemies.", "https://diablo2.diablowiki.net/Frost_Nova" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Conviction", "This aura lowers the defense and fire, lightning, and cold resistances of monsters, making it ideal to pair with an elemental weapon or skill, such as Vengeance.", "https://diablo2.diablowiki.net/Conviction" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Cyclone Armor", "This shielding spell is essentially an elemental version of the Necromancer's Bone Shield. It absorbs a set amount of elemental damage, but has no effect against physical attacks.", "https://diablo2.diablowiki.net/Cyclone_Armor" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Meditation", "Boosts the mana regeneration rate for the Paladin and all his party members.", "https://diablo2.diablowiki.net/Meditation" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Twister", "Each cast of Twister sets up a small tornado that stuns and deals physical damage to any enemies in the area.", "https://diablo2.diablowiki.net/Twister" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Vengeance", "A powerful single-hit attack that adds fire, lightning, and cold damage.", "https://diablo2.diablowiki.net/Vengeance" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Fade", "Raises all resistances and resists curses for a period of time.", "https://diablo2.diablowiki.net/Fade" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Might", "Might increases the output of all physical damage attacks by the Paladin or his party.", "https://diablo2.diablowiki.net/Might" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Decrepify", "This powerful curse lowers movement, attack speed, damage and physical resistance by 50%.", "https://diablo2.diablowiki.net/Decrepify" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Sanctuary", "This aura only works against the Undead, but provides the Paladin with a substantial damage bonus, as well as working to push back and constantly deal holy damage to all Undead in range.", "https://diablo2.diablowiki.net/Sanctuary_(skill)" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Inferno", "Inferno turns a Sorceress into a human flamethrower, capable of emitting a massive spout of flame for as long as the spell is kept active.", "https://diablo2.diablowiki.net/Inferno" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Fire Bolt", "Shoots a small ball of fire. Fire Bolts hit only one target and have no splash damage.", "https://diablo2.diablowiki.net/Fire_Bolt" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Slow Missiles", "A curse-like debuff skill that slows the missles of all monsters within the skill's range.", "https://diablo2.diablowiki.net/Slow_Missiles" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Dodge", "Allows the Amazon to dodge melee attacks while standing still or attacking.", "https://diablo2.diablowiki.net/Dodge" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Critical Strike", "This extremely powerful skill gives a chance to deal a critical strike, doubling the physical damage of an attack with any sort of weapon.", "https://diablo2.diablowiki.net/Critical_Strike" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Energy Shield", "Energy Shield allows the Sorceress to redirect damage from life to mana.", "https://diablo2.diablowiki.net/Energy_Shield" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Howl", "Howling will cause affected monsters to cease attacking and retreat as a green 'rain' drizzles down on them.", "https://diablo2.diablowiki.net/Howl" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Taunt", "Taunt is set up to get those pesky fleeing monsters to come to you.", "https://diablo2.diablowiki.net/Taunt" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Cloak of Shadows", "This spell blocks some monster effects; sand maggots cannot lay eggs, unravelers cannot use their poison breath, venom lords cannot use their Inferno attack etc.", "https://diablo2.diablowiki.net/Cloak_of_Shadows" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Bone Spirit", "Bone Spirits are slow-moving, homing missiles that will track targets for quite a distance off the screen.", "https://diablo2.diablowiki.net/Bone_Spirit" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Heart of Wolverine", "This spirit's aura provides a hearty attack rating and damage bonus to the Druid and all players and minions in his party.", "https://diablo2.diablowiki.net/Heart_of_Wolverine" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Iron Golem", "This golem is created from the item, and takes on properties of the item.", "https://diablo2.diablowiki.net/Iron_Golem" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Enchant", "Temporarily grants bonus fire damage and boosts the Attack Rating of any friendly player or minion.", "https://diablo2.diablowiki.net/Enchant" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Berserk", "Berserk gives the Barbarian a way to deal a huge amount of magical (non-physical) damage with a melee attack, saving him from needing to use elemental damage weapons to kill Stone Skin and Physical Immune monsters.", "https://diablo2.diablowiki.net/Berserk" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Zeal", "Zeal is a rapid, multi-strike attack with substantial bonuses to attack rating, attack speed, and damage.", "https://diablo2.diablowiki.net/Zeal" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Firestorm", "Wielding this ability, the Druid projects waves of molten earth that spread outward and burn a wide swath of destruction through his foes.", "https://diablo2.diablowiki.net/Firestorm" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Redemption", "Redemption uses up corpses, making them vanish with a lovely rising spirit graphic (also seen coming up from the skeletons after Radament is defeated in the Act Two Sewers), and transferring substantial mana and life to the Paladin.", "https://diablo2.diablowiki.net/Redemption" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Fire Wall", "A wall of flame springs up in both directions from the spot the Sorceress targets for ignition.", "https://diablo2.diablowiki.net/Fire_Wall" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Concentration", "Concentration greatly increases the physical damage of the Paladin and all in his party.", "https://diablo2.diablowiki.net/Concentration" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Holy Bolt", "A glowing, magical projectile is fired out at a medium rate of speed.", "https://diablo2.diablowiki.net/Holy_Bolt" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Tornado", "An upgraded version of Twister, a Tornado is much larger and more powerful, but lacks the stunning effect of the smaller Twisters.", "https://diablo2.diablowiki.net/Tornado" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Iron Maiden", "Causes the physical, melee damage inflicted by the target to reflect back to themselves.", "https://diablo2.diablowiki.net/Iron_Maiden" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Weaken", "Lowers the physical damage the target inflicts by 33%.", "https://diablo2.diablowiki.net/Weaken" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Molten Boulder", "A fun skill to use, this one sends forth a rolling boulder of molten stone.", "https://diablo2.diablowiki.net/Molten_Boulder" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Clay Golem", "Raises a Golem from the earth to fight for you.", "https://diablo2.diablowiki.net/Clay_Golem" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Poison Explosion", "Like Corpse Explosion, but with poison damage.", "https://diablo2.diablowiki.net/Poison_Explosion" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Ice Blast", "Shoots a large snowball that hits with cold damage, freezing the target.", "https://diablo2.diablowiki.net/Ice_Blast" });
            migrationBuilder.InsertData("skills", new string[] { "id", "name", "description", "url" },
                                                        new object[] { index++, "Skeleton Mastery", "Increases the hit points and damage dealt by Skeletons, Skeleton Mages, and Revived.", "https://diablo2.diablowiki.net/Skeleton_Mastery" });
        }
    }
}
