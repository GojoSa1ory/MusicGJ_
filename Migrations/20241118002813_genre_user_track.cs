using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicG.Migrations
{
    /// <inheritdoc />
    public partial class genre_user_track : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Track_table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Track_table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Track_table_GenreId",
                table: "Track_table",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_table_UserId",
                table: "Track_table",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_table_Genre_GenreId",
                table: "Track_table",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_table_Users_table_UserId",
                table: "Track_table",
                column: "UserId",
                principalTable: "Users_table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_table_Genre_GenreId",
                table: "Track_table");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_table_Users_table_UserId",
                table: "Track_table");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Track_table_GenreId",
                table: "Track_table");

            migrationBuilder.DropIndex(
                name: "IX_Track_table_UserId",
                table: "Track_table");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Track_table");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Track_table");
        }
    }
}
