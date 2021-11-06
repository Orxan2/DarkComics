using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
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
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Cover = table.Column<string>(nullable: true),
                    Backface = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    IsTeam = table.Column<bool>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
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
                    DeactivatedDate = table.Column<DateTime>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Height = table.Column<string>(maxLength: 20, nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    EyeColor = table.Column<string>(maxLength: 20, nullable: false),
                    HairStyle = table.Column<string>(maxLength: 20, nullable: false),
                    Education = table.Column<string>(maxLength: 30, nullable: false),
                    Fighting = table.Column<int>(nullable: false),
                    Durability = table.Column<int>(nullable: false),
                    Energy = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    LayoutImage = table.Column<string>(nullable: true),
                    AboutCharacter = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Backface = table.Column<string>(nullable: true),
                    IsCover = table.Column<bool>(nullable: false),
                    PageCount = table.Column<int>(nullable: true),
                    SerieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicDetails_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    Description = table.Column<string>(nullable: true),
                    DeActivatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ComicDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
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
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    ComicDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingComics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingComics_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCharacters_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, false, "Gotham" },
                    { 2, false, "Metropolis" },
                    { 3, false, "New-York" }
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
                table: "Series",
                columns: new[] { "Id", "Backface", "Cover", "DeletedDate", "Discount", "IsDeleted", "IsTeam", "Name" },
                values: new object[,]
                {
                    { 1, "backface.png", "cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, false, "Nightwing Rebirth" },
                    { 2, "backface.png", "cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, false, "Batman Rebirth" },
                    { 3, "backface.png", "cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, true, "Justice League Rebirth" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AboutCharacter", "CityId", "Creator", "DeactivatedDate", "Durability", "Education", "Energy", "EyeColor", "Fighting", "FirstAppearance", "FirstImage", "HairStyle", "Height", "HeroName", "Intelligence", "IsActive", "LayoutImage", "Logo", "Name", "NickName", "Profile", "SecondImage", "Speed", "Strength", "Weight" },
                values: new object[,]
                {
                    { 1, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 1, "Bob Kane and Bill Finger", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gotham City School", 8, "Blue", 9, "Dedective Comics #1", "batman.png", "Black", "1.89", "Batman", 7, true, "layout.png", "batman-logo.png", "Bruce Wayne", "Dark Knight", "batman-profile.png", "batman-2.png", 6, 7, 70 },
                    { 2, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 1, "Orxan Ibra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gotham City School", 8, "Blue", 9, "Dedective Comics #14", "nightwing.png", "Black", "1.89", "Nightwing", 7, true, "layout.png", "nightwing-logo.png", "Dick  Grayson", "Wonder Boy", "nightwing-profile.png", "nightwing-2.png", 6, 7, 70 },
                    { 3, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 3, "Stan Lee", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gotham City School", 8, "Blue", 9, "Spiderman #1", "batman.png", "Black", "1.89", "Spiderman", 7, true, "layout.png", "spiderman-logo.png", "Peter Parker", "Spidey", "batman-profile.png", "batman-2.png", 6, 7, 70 }
                });

            migrationBuilder.InsertData(
                table: "ComicDetails",
                columns: new[] { "Id", "Backface", "IsCover", "PageCount", "SerieId" },
                values: new object[,]
                {
                    { 1, "backface.png", true, 12, 1 },
                    { 2, "backface.png", true, 7, 2 },
                    { 3, "backface.png", true, 10, 3 }
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
                table: "Products",
                columns: new[] { "Id", "Category", "ComicDetailId", "DeActivatedDate", "Description", "Image", "IsActive", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 16, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #29", 7.5, 8 },
                    { 17, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #13", 7.5, 8 },
                    { 18, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #7", 7.5, 23 },
                    { 19, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman New 52 #2", 7.5, 8 },
                    { 20, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #1", 7.5, 12 },
                    { 21, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "justice League #15", 7.5, 8 },
                    { 22, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #78", 7.5, 8 },
                    { 23, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #29", 7.5, 8 },
                    { 24, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #13", 7.5, 8 },
                    { 27, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #1", 7.5, 12 },
                    { 26, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman New 52 #2", 7.5, 8 },
                    { 15, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #78", 7.5, 8 },
                    { 28, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #13", 7.5, 8 },
                    { 29, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #7", 7.5, 23 },
                    { 30, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman New 52 #2", 7.5, 8 },
                    { 31, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #1", 7.5, 12 },
                    { 32, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "justice League #15", 7.5, 8 },
                    { 33, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #78", 7.5, 8 },
                    { 34, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #29", 7.5, 8 },
                    { 25, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #7", 7.5, 23 },
                    { 14, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "justice League #15", 7.5, 8 },
                    { 11, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #7", 7.5, 23 },
                    { 12, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman New 52 #2", 7.5, 8 },
                    { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Nightwing Rebirth #1", 6.5, 3 },
                    { 13, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #1", 7.5, 12 },
                    { 2, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #1", 7.5, 8 },
                    { 4, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #7", 7.5, 23 },
                    { 5, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman New 52 #2", 7.5, 8 },
                    { 3, 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Justice League Rebirth #1", 10.0, 12 },
                    { 7, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "justice League #15", 7.5, 8 },
                    { 8, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #78", 7.5, 8 },
                    { 9, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #29", 7.5, 8 },
                    { 10, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #13", 7.5, 8 },
                    { 35, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Batman Rebirth #13", 7.5, 8 },
                    { 6, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, "Dedective Comics #1", 7.5, 12 }
                });

            migrationBuilder.InsertData(
                table: "ReadingComics",
                columns: new[] { "Id", "ComicDetailId", "Image" },
                values: new object[,]
                {
                    { 10, 1, "10.jpg" },
                    { 8, 1, "8.jpg" },
                    { 7, 1, "7.jpg" },
                    { 6, 1, "6.jpg" },
                    { 5, 1, "5.jpg" },
                    { 4, 1, "4.jpg" },
                    { 3, 1, "3.jpg" },
                    { 2, 1, "2.jpg" },
                    { 1, 1, "1.jpg" },
                    { 9, 1, "9.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProductCharacters",
                columns: new[] { "Id", "CharacterId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 32, 1, 32 },
                    { 31, 1, 31 },
                    { 30, 1, 30 },
                    { 29, 1, 29 },
                    { 27, 1, 27 },
                    { 26, 1, 26 },
                    { 25, 1, 25 },
                    { 24, 1, 24 },
                    { 23, 1, 23 },
                    { 22, 1, 22 },
                    { 21, 1, 21 },
                    { 20, 1, 20 },
                    { 19, 1, 19 },
                    { 18, 1, 18 },
                    { 33, 1, 33 },
                    { 28, 1, 17 },
                    { 16, 1, 16 },
                    { 15, 1, 15 },
                    { 14, 1, 14 },
                    { 13, 1, 13 },
                    { 12, 1, 12 },
                    { 11, 1, 11 },
                    { 10, 1, 10 },
                    { 9, 1, 9 },
                    { 8, 1, 8 },
                    { 7, 1, 7 },
                    { 6, 1, 6 },
                    { 5, 1, 5 },
                    { 4, 1, 4 },
                    { 2, 1, 2 },
                    { 17, 1, 17 },
                    { 3, 3, 3 }
                });

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
                name: "IX_ComicDetails_SerieId",
                table: "ComicDetails",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacters_CharacterId",
                table: "ProductCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacters_ProductId",
                table: "ProductCharacters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ComicDetailId",
                table: "Products",
                column: "ComicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingComics_ComicDetailId",
                table: "ReadingComics",
                column: "ComicDetailId");

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
                name: "ProductCharacters");

            migrationBuilder.DropTable(
                name: "ReadingComics");

            migrationBuilder.DropTable(
                name: "ToyCharacters");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "ComicDetails");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
