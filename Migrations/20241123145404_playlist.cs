using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicG.Migrations
{
    /// <inheritdoc />
    public partial class playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users_table",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users_table",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users_table",
                newName: "Email");

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_Playlist_Users_table_UserId",
                        column: x => x.UserId,
                        principalTable: "Users_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlaylistEntityTrackEntity",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    TracksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistEntityTrackEntity", x => new { x.PlaylistId, x.TracksId });
                    table.ForeignKey(
                        name: "FK_PlaylistEntityTrackEntity_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistEntityTrackEntity_Track_table_TracksId",
                        column: x => x.TracksId,
                        principalTable: "Track_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistEntityTrackEntity_TracksId",
                table: "PlaylistEntityTrackEntity",
                column: "TracksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistEntityTrackEntity");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users_table",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users_table",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users_table",
                newName: "email");
        }
    }
}
