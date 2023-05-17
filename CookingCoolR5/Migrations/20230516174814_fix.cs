using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingCoolR5.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameModels",
                table: "GameModels");

            migrationBuilder.RenameTable(
                name: "GameModels",
                newName: "GamesModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesModels",
                table: "GamesModels",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesModels",
                table: "GamesModels");

            migrationBuilder.RenameTable(
                name: "GamesModels",
                newName: "GameModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameModels",
                table: "GameModels",
                column: "Id");
        }
    }
}
