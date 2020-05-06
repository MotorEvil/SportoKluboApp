using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SportoKluboApp.Migrations
{
    public partial class WorkoutUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WorkoutUser",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    TreniruoteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutUser", x => new { x.UserId, x.TreniruoteId });
                    table.ForeignKey(
                        name: "FK_WorkoutUser_Items_TreniruoteId",
                        column: x => x.TreniruoteId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutUser_TreniruoteId",
                table: "WorkoutUser",
                column: "TreniruoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutUser");

            migrationBuilder.AddColumn<Guid>(
                name: "TreniruoteId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
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
    }
}