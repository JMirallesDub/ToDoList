using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo_List.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModification",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModification",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
