using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class AddingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Powers",
                table: "Characters");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Backface", "CharacterId", "Cover", "Name" },
                values: new object[] { 4, "backface.jpg", null, "cover.jpg", "Titans" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Powers",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
