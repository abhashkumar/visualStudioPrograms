using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIEntityframework.Migrations
{
    /// <inheritdoc />
    public partial class relatingGradeTableWithStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentGradeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentGradeId",
                table: "Students",
                column: "CurrentGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grade_CurrentGradeId",
                table: "Students",
                column: "CurrentGradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grade_CurrentGradeId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Students_CurrentGradeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentGradeId",
                table: "Students");
        }
    }
}
