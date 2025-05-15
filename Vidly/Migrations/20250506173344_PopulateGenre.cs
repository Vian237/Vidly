using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*Les tableaux de reference doivent etre rempli de cette facon
            car ils doivent etre deploye avec l'app*/
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (2, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (3, 'Family')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (4, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (5, 'Comedy')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
