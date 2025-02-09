using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    public partial class mjj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Teachers_teacherpassaportNumber",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_courses_teacherpassaportNumber",
                table: "Courses",
                newName: "IX_Courses_teacherpassaportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_teacherpassaportNumber",
                table: "Courses",
                column: "teacherpassaportNumber",
                principalTable: "Teachers",
                principalColumn: "passaportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_teacherpassaportNumber",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "courses");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_teacherpassaportNumber",
                table: "courses",
                newName: "IX_courses_teacherpassaportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Teachers_teacherpassaportNumber",
                table: "courses",
                column: "teacherpassaportNumber",
                principalTable: "Teachers",
                principalColumn: "passaportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
