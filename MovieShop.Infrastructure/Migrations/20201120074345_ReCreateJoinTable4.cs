using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class ReCreateJoinTable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_genreId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_movieId",
                table: "MovieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenre_movieId",
                table: "MovieGenre");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "MovieGenre",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "MovieGenre",
                newName: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_MovieId",
                table: "MovieGenre",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_MovieId",
                table: "MovieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "MovieGenre",
                newName: "genreId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieGenre",
                newName: "movieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre",
                columns: new[] { "genreId", "movieId" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_movieId",
                table: "MovieGenre",
                column: "movieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_genreId",
                table: "MovieGenre",
                column: "genreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_movieId",
                table: "MovieGenre",
                column: "movieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
