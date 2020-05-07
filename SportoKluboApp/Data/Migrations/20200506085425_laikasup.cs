using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SportoKluboApp.Migrations
{
    public partial class laikasup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Laikas",
                table: "Items",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Laikas",
                table: "Items",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}