using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiproj.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SqlMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlMovie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SqlReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reviewer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    SqlMovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SqlReview_SqlMovie_SqlMovieId",
                        column: x => x.SqlMovieId,
                        principalTable: "SqlMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SqlReview_SqlMovieId",
                table: "SqlReview",
                column: "SqlMovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SqlReview");

            migrationBuilder.DropTable(
                name: "SqlMovie");
        }
    }
}
