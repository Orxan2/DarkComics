using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class AddedFooterDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Powers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Powers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Footer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    FooterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLinks_Footer_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Footer",
                columns: new[] { "Id", "Address", "Email", "Phone" },
                values: new object[] { 1, "Mybook Book Store 48 Boulevard Jourdan, Paris, France", "orxan.ibrahimli.98@gmail.com", "+994 55 748 26 00" });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "Id", "FooterId", "Icon", "Link" },
                values: new object[] { 1, 1, "fab fa-facebook-f", "facebook.com" });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "Id", "FooterId", "Icon", "Link" },
                values: new object[] { 2, 1, "fab fa-twitter", "twitter.com" });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "Id", "FooterId", "Icon", "Link" },
                values: new object[] { 3, 1, "fab fa-instagram", "instagram.com" });

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_FooterId",
                table: "SocialLinks",
                column: "FooterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "Footer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Powers");
        }
    }
}
