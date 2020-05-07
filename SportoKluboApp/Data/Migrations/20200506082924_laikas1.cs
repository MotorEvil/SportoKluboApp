using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SportoKluboApp.Migrations
{
    public partial class laikas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Laikas",
                table: "Items",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Laikas",
                table: "Items",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}