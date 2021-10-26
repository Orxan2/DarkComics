using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(maxLength: 50, nullable: false),
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
                name: "Comics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Volume = table.Column<int>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Batman" },
                    { 2, "Nightwing" },
                    { 3, "Spiderman" }
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
                table: "Categories",
                columns: new[] { "Id", "CharacterId", "Image", "Name" },
                values: new object[,]
                {
                    { 2, 1, "nightwing.png", "Dedective Comics" },
                    { 1, 2, "nightwing.png", "Rebirth" },
                    { 3, 2, "nightwing-3.png", "New 52" }
                });

            migrationBuilder.InsertData(
                table: "TeamCharacters",
                columns: new[] { "Id", "CharacterId", "TeamId" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 1, 1, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "CategoryId", "ComicType", "DeActivatedDate", "Episode", "Image", "IsActive", "IsTeam", "Name", "Price", "Quantity", "TeamId", "Volume" },
                values: new object[] { 3, 2, 2, null, 9.0, null, false, false, "bat", 6.0, 6, null, 0 });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "CategoryId", "ComicType", "DeActivatedDate", "Episode", "Image", "IsActive", "IsTeam", "Name", "Price", "Quantity", "TeamId", "Volume" },
                values: new object[] { 1, 1, 2, null, 2.0, null, false, false, "Night", 9.5, 23, null, 0 });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "CategoryId", "ComicType", "DeActivatedDate", "Episode", "Image", "IsActive", "IsTeam", "Name", "Price", "Quantity", "TeamId", "Volume" },
                values: new object[] { 2, 3, 2, null, 6.0, null, false, false, "orxan", 4.5, 12, null, 0 });

            migrationBuilder.InsertData(
                table: "ComicCharacters",
                columns: new[] { "Id", "CharacterId", "ComicId" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "ComicCharacters",
                columns: new[] { "Id", "CharacterId", "ComicId" },
                values: new object[] { 3, 2, 1 });

            migrationBuilder.InsertData(
                table: "ComicCharacters",
                columns: new[] { "Id", "CharacterId", "ComicId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CharacterId",
                table: "Categories",
                column: "CharacterId");

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
                name: "IX_TeamCharacters_CharacterId",
                table: "TeamCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCharacters_TeamId",
                table: "TeamCharacters",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComicCharacters");

            migrationBuilder.DropTable(
                name: "TeamCharacters");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Comics");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
