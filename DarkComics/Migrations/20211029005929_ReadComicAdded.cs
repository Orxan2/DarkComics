using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class ReadComicAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadingComic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    ComicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingComic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingComic_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReadingComic",
                columns: new[] { "Id", "ComicId", "Image" },
                values: new object[,]
                {
                    { 1, 1, "1.jpg" },
                    { 2, 1, "2.jpg" },
                    { 3, 1, "3.jpg" },
                    { 4, 1, "4.jpg" },
                    { 5, 5, "1.jpg" },
                    { 6, 1, "6.jpg" },
                    { 7, 1, "7.jpg" },
                    { 8, 1, "8.jpg" },
                    { 9, 1, "9.jpg" },
                    { 10, 5, "10.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadingComic_ComicId",
                table: "ReadingComic",
                column: "ComicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadingComic");
        }
    }
}
