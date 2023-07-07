using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookingCoolR5.Migrations
{
    /// <inheritdoc />
    public partial class AddRelevance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Relevance",
                table: "GamesModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relevance",
                table: "GamesModels");
        }
    }
}
