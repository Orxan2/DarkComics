using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class AddedContactAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contact",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 26, 18, 54, 10, 699, DateTimeKind.Local).AddTicks(6542),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "dateadd(hour,4,getutcdate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contact",
                type: "Date",
                nullable: false,
                defaultValueSql: "dateadd(hour,4,getutcdate())",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2021, 11, 26, 18, 54, 10, 699, DateTimeKind.Local).AddTicks(6542));
        }
    }
}
