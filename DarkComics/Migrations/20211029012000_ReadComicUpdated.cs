using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class ReadComicUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ReadingComic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ComicId", "Image" },
                values: new object[] { 1, "5.jpg" });

            migrationBuilder.UpdateData(
                table: "ReadingComic",
                keyColumn: "Id",
                keyValue: 10,
                column: "ComicId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ReadingComic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ComicId", "Image" },
                values: new object[] { 5, "1.jpg" });

            migrationBuilder.UpdateData(
                table: "ReadingComic",
                keyColumn: "Id",
                keyValue: 10,
                column: "ComicId",
                value: 5);
        }
    }
}
