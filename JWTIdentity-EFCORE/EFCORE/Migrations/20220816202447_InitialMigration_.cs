using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCWebApp2.Migrations
{
    public partial class InitialMigration_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE MyCustomProcedure
                               AS
                               SELECT * FROM Students");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE MyCustomProcedure");
        }
    }
}
