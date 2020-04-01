using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportoKluboApp.Data.Migrations
{
    public partial class Treniruotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Laikas = table.Column<DateTime>(nullable: false),
                    Pavadinimas = table.Column<string>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    LaisvosVietos = table.Column<int>(nullable: false),
                    Registracijos = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
