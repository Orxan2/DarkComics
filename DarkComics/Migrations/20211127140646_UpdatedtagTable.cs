using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class UpdatedtagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tags",
                nullable: false,
                defaultValueSql: "dateadd(hour,4,getutcdate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tags");
        }
    }
}
