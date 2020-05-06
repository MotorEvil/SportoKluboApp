using Microsoft.EntityFrameworkCore.Migrations;

namespace SportoKluboApp.Migrations
{
    public partial class updateWU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutUser_Items_TreniruoteId",
                table: "WorkoutUser");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutUser_AspNetUsers_UserId",
                table: "WorkoutUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutUser",
                table: "WorkoutUser");

            migrationBuilder.RenameTable(
                name: "WorkoutUser",
                newName: "workoutUsers");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutUser_TreniruoteId",
                table: "workoutUsers",
                newName: "IX_workoutUsers_TreniruoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workoutUsers",
                table: "workoutUsers",
                columns: new[] { "UserId", "TreniruoteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_workoutUsers_Items_TreniruoteId",
                table: "workoutUsers",
                column: "TreniruoteId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workoutUsers_AspNetUsers_UserId",
                table: "workoutUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workoutUsers_Items_TreniruoteId",
                table: "workoutUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_workoutUsers_AspNetUsers_UserId",
                table: "workoutUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workoutUsers",
                table: "workoutUsers");

            migrationBuilder.RenameTable(
                name: "workoutUsers",
                newName: "WorkoutUser");

            migrationBuilder.RenameIndex(
                name: "IX_workoutUsers_TreniruoteId",
                table: "WorkoutUser",
                newName: "IX_WorkoutUser_TreniruoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutUser",
                table: "WorkoutUser",
                columns: new[] { "UserId", "TreniruoteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutUser_Items_TreniruoteId",
                table: "WorkoutUser",
                column: "TreniruoteId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutUser_AspNetUsers_UserId",
                table: "WorkoutUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}