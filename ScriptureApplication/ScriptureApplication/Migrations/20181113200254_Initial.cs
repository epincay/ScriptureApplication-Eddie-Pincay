using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScriptureApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Scripture",
                newName: "Note");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Added",
                table: "Scripture",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Added",
                table: "Scripture");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Scripture",
                newName: "Text");
        }
    }
}
