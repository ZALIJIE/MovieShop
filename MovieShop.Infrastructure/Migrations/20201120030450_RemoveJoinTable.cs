﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class RemoveJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer");

            migrationBuilder.DropIndex(
                name: "IX_Trailer_MovieId",
                table: "Trailer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trailer_MovieId",
                table: "Trailer",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
