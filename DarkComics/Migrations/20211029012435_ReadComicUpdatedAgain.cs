using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class ReadComicUpdatedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingComic_Comics_ComicId",
                table: "ReadingComic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingComic",
                table: "ReadingComic");

            migrationBuilder.RenameTable(
                name: "ReadingComic",
                newName: "ReadingComics");

            migrationBuilder.RenameIndex(
                name: "IX_ReadingComic_ComicId",
                table: "ReadingComics",
                newName: "IX_ReadingComics_ComicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingComics",
                table: "ReadingComics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingComics_Comics_ComicId",
                table: "ReadingComics",
                column: "ComicId",
                principalTable: "Comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingComics_Comics_ComicId",
                table: "ReadingComics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingComics",
                table: "ReadingComics");

            migrationBuilder.RenameTable(
                name: "ReadingComics",
                newName: "ReadingComic");

            migrationBuilder.RenameIndex(
                name: "IX_ReadingComics_ComicId",
                table: "ReadingComic",
                newName: "IX_ReadingComic_ComicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingComic",
                table: "ReadingComic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingComic_Comics_ComicId",
                table: "ReadingComic",
                column: "ComicId",
                principalTable: "Comics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
