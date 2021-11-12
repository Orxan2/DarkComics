using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class AddedNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "News",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShortDescription",
                value: "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShortDescription",
                value: "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShortDescription",
                value: "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "News");
        }
    }
}
