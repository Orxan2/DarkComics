using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    DeactivatedDate = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    HeroName = table.Column<string>(nullable: false),
                    FirstAppearance = table.Column<string>(nullable: false),
                    FirstImage = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    SecondImage = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    AboutCharacter = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Cover = table.Column<string>(maxLength: 50, nullable: false),
                    Backface = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPowers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerId = table.Column<int>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterPowers_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamCharacters_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToyCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(nullable: true),
                    ToyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToyCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToyCharacters_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Volume = table.Column<int>(nullable: false),
                    SaleQuantity = table.Column<int>(nullable: false),
                    Episode = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsTeam = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    DeActivatedDate = table.Column<DateTime>(type: "Date", nullable: true),
                    ComicType = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comics_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicId = table.Column<int>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComicCharacters_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReadingComics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    ComicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingComics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingComics_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Backface", "CharacterId", "Cover", "Name" },
                values: new object[] { 4, "backface.jpg", null, "cover.jpg", "Titans" });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Gotham" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Metropolis" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "New-York" }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "super speed" },
                    { 2, "exceptional martial artist" },
                    { 3, "Science" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Titans" },
                    { 2, "Justice League" },
                    { 3, "Avengers" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AboutCharacter", "CityId", "Creator", "FirstAppearance", "FirstImage", "HeroName", "IsActive", "Logo", "Name", "NickName", "Profile", "SecondImage" },
                values: new object[] { 1, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 1, "Bob Kane and Bill Finger", "Dedective Comics #1", "batman.png", "Batman", true, "batman-logo.png", "Bruce Wayne", "Dark Knight", "batman-profile.png", "batman-2.png" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AboutCharacter", "CityId", "Creator", "FirstAppearance", "FirstImage", "HeroName", "IsActive", "Logo", "Name", "NickName", "Profile", "SecondImage" },
                values: new object[] { 2, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 1, "Orxan Ibra", "Dedective Comics #14", "nightwing.png", "Nightwing", true, "nightwing-logo.png", "Dick  Grayson", "Wonder Boy", "nightwing-profile.png", "nightwing-2.png" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AboutCharacter", "CityId", "Creator", "FirstAppearance", "FirstImage", "HeroName", "IsActive", "Logo", "Name", "NickName", "Profile", "SecondImage" },
                values: new object[] { 3, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 3, "Stan Lee", "Spiderman #1", "batman.png", "Spiderman", true, "spiderman-logo.png", "Peter Parker", "Spidey", "batman-profile.png", "batman-2.png" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Backface", "CharacterId", "Cover", "Name" },
                values: new object[,]
                {
                    { 2, "backface.jpg", 1, "cover.jpg", "Dedective Comics" },
                    { 1, "backface.jpg", 2, "cover.jpg", "Rebirth" },
                    { 3, "backface.jpg", 2, "cover.jpg", "New 52" }
                });

            migrationBuilder.InsertData(
                table: "CharacterPowers",
                columns: new[] { "Id", "CharacterId", "PowerId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TeamCharacters",
                columns: new[] { "Id", "CharacterId", "TeamId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 1 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "CategoryId", "ComicType", "DeActivatedDate", "Episode", "Image", "IsActive", "IsTeam", "Name", "Price", "Quantity", "SaleQuantity", "TeamId", "Volume" },
                values: new object[,]
                {
                    { 3, 2, 2, null, 9.0, "1.jpg", true, false, "bat", 6.0, 6, 0, null, 0 },
                    { 4, 2, 1, null, 0.0, "1.jpg", true, false, "bat", 13.4, 3, 0, null, 1 },
                    { 1, 1, 2, null, 1.0, "1.jpg", true, false, "Night", 9.5, 23, 0, null, 0 },
                    { 5, 1, 1, null, 0.0, "1.jpg", true, false, "dick", 13.4, 3, 0, null, 1 },
                    { 2, 3, 2, null, 6.0, "1.jpg", true, false, "orxan", 4.5, 12, 0, null, 0 },
                    { 6, 3, 2, null, 30.0, "1.jpg", true, false, "orxan", 4.5, 12, 0, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "ComicCharacters",
                columns: new[] { "Id", "CharacterId", "ComicId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 3, 2, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ReadingComics",
                columns: new[] { "Id", "ComicId", "Image" },
                values: new object[,]
                {
                    { 1, 1, "1.jpg" },
                    { 2, 1, "2.jpg" },
                    { 3, 1, "3.jpg" },
                    { 4, 1, "4.jpg" },
                    { 5, 1, "5.jpg" },
                    { 6, 1, "6.jpg" },
                    { 7, 1, "7.jpg" },
                    { 8, 1, "8.jpg" },
                    { 9, 1, "9.jpg" },
                    { 10, 1, "10.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CharacterId",
                table: "Categories",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPowers_CharacterId",
                table: "CharacterPowers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPowers_PowerId",
                table: "CharacterPowers",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CityId",
                table: "Characters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicCharacters_CharacterId",
                table: "ComicCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicCharacters_ComicId",
                table: "ComicCharacters",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comics_CategoryId",
                table: "Comics",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comics_TeamId",
                table: "Comics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingComics_ComicId",
                table: "ReadingComics",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCharacters_CharacterId",
                table: "TeamCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCharacters_TeamId",
                table: "TeamCharacters",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyCharacters_CharacterId",
                table: "ToyCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyCharacters_ToyId",
                table: "ToyCharacters",
                column: "ToyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterPowers");

            migrationBuilder.DropTable(
                name: "ComicCharacters");

            migrationBuilder.DropTable(
                name: "ReadingComics");

            migrationBuilder.DropTable(
                name: "TeamCharacters");

            migrationBuilder.DropTable(
                name: "ToyCharacters");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Comics");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}
