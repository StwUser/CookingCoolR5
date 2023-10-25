using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingCoolR5.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionToUser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "GameModelUser",
                columns: table => new
                {
                    GameModelsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModelUser", x => new { x.GameModelsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GameModelUser_GamesModels_GameModelsId",
                        column: x => x.GameModelsId,
                        principalTable: "GamesModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameModelUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameModelUser_UsersId",
                table: "GameModelUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameModelUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GamesModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GamesModels_UserId",
                table: "GamesModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesModels_Users_UserId",
                table: "GamesModels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
