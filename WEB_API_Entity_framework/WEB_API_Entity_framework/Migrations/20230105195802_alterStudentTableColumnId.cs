using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIEntityframework.Migrations
{
    /// <inheritdoc />
    public partial class alterStudentTableColumnId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"EXEC sp_RENAME 'Students.StudentId', 'Id', 'COLUMN'";
            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
