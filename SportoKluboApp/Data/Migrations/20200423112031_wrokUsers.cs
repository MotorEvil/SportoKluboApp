using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportoKluboApp.Migrations
{
    public partial class wrokUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TreniruoteId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TreniruoteId",
                table: "AspNetUsers",
                column: "TreniruoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Items_TreniruoteId",
                table: "AspNetUsers",
                column: "TreniruoteId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Items_TreniruoteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TreniruoteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TreniruoteId",
                table: "AspNetUsers");
        }
    }
}
