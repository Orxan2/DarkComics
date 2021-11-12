using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class UpdatedCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterNews_Characters_CharacterId",
                table: "CharacterNews");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterNews_News_NewsId",
                table: "CharacterNews");

            migrationBuilder.DropForeignKey(
                name: "FK_TagNews_News_NewsId",
                table: "TagNews");

            migrationBuilder.DropForeignKey(
                name: "FK_TagNews_Tags_TagId",
                table: "TagNews");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "TagNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "TagNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "CharacterNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 13, 0, 36, 21, 604, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterNews_Characters_CharacterId",
                table: "CharacterNews",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterNews_News_NewsId",
                table: "CharacterNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TagNews_News_NewsId",
                table: "TagNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TagNews_Tags_TagId",
                table: "TagNews",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterNews_Characters_CharacterId",
                table: "CharacterNews");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterNews_News_NewsId",
                table: "CharacterNews");

            migrationBuilder.DropForeignKey(
                name: "FK_TagNews_News_NewsId",
                table: "TagNews");

            migrationBuilder.DropForeignKey(
                name: "FK_TagNews_Tags_TagId",
                table: "TagNews");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "TagNews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "TagNews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "CharacterNews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterNews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 12, 15, 59, 34, 702, DateTimeKind.Local).AddTicks(8907));

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterNews_Characters_CharacterId",
                table: "CharacterNews",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterNews_News_NewsId",
                table: "CharacterNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagNews_News_NewsId",
                table: "TagNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagNews_Tags_TagId",
                table: "TagNews",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
