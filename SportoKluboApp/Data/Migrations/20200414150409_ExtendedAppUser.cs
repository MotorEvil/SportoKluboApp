using Microsoft.EntityFrameworkCore.Migrations;

namespace SportoKluboApp.Migrations
{
    public partial class ExtendedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Subscription",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscription",
                table: "AspNetUsers");
        }
    }
}