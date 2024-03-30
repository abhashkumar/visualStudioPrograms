using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIEntityframework.Migrations
{
    /// <inheritdoc />
    public partial class updateNamesForBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"Update Students set Name = 'Bill Clinton' Where Name = 'Bill'";
            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
