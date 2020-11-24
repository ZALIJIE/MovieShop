using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class ReCreateJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_genresId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_moviesId",
                table: "MovieGenre");

            migrationBuilder.RenameColumn(
                name: "moviesId",
                table: "MovieGenre",
                newName: "movieId");

            migrationBuilder.RenameColumn(
                name: "genresId",
                table: "MovieGenre",
                newName: "genreId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenre_moviesId",
                table: "MovieGenre",
                newName: "IX_MovieGenre_movieId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_genreId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_movieId",
                table: "MovieGenre");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "MovieGenre",
                newName: "moviesId");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "MovieGenre",
                newName: "genresId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenre_movieId",
                table: "MovieGenre",
                newName: "IX_MovieGenre_moviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_genresId",
                table: "MovieGenre",
                column: "genresId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_moviesId",
                table: "MovieGenre",
                column: "moviesId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
