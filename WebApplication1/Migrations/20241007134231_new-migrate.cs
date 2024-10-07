using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPPLICATION1.Migrations
{
    /// <inheritdoc />
    public partial class newmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quiz_Grade",
                table: "Student_Attendance",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quiz_Grade",
                table: "Student_Attendance");
        }
    }
}
