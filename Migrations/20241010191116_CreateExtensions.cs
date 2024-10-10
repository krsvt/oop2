using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class CreateExtensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS pg_trgm;");
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS fuzzystrmatch;");
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS unaccent;");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
