using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class UpdateNewsAgain3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Image" },
                values: new object[] { new DateTime(2021, 11, 12, 15, 59, 34, 702, DateTimeKind.Local).AddTicks(8907), "cover.jpg" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "cover.jpg");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "cover.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Image" },
                values: new object[] { new DateTime(2021, 11, 12, 15, 55, 30, 84, DateTimeKind.Local).AddTicks(9615), "cover.png" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "cover.png");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "cover.png");
        }
    }
}
