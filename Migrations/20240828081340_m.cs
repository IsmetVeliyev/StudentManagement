using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Fee",
                table: "courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Hours",
                table: "courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "LessonName",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "teacherpassaportNumber",
                table: "courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_courses_teacherpassaportNumber",
                table: "courses",
                column: "teacherpassaportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Teachers_teacherpassaportNumber",
                table: "courses",
                column: "teacherpassaportNumber",
                principalTable: "Teachers",
                principalColumn: "passaportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Teachers_teacherpassaportNumber",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_teacherpassaportNumber",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "LessonName",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "teacherpassaportNumber",
                table: "courses");
        }
    }
}
