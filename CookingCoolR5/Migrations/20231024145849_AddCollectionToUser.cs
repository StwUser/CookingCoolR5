using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingCoolR5.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GamesModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesModels_UserId",
                table: "GamesModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesModels_Users_UserId",
                table: "GamesModels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesModels_Users_UserId",
                table: "GamesModels");

            migrationBuilder.DropIndex(
                name: "IX_GamesModels_UserId",
                table: "GamesModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GamesModels");
        }
    }
}
