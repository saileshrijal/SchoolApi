using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Grades_GradeID",
                table: "SubjectGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectID",
                table: "SubjectGrades");

            migrationBuilder.RenameColumn(
                name: "SubjectID",
                table: "SubjectGrades",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "GradeID",
                table: "SubjectGrades",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGrades_SubjectID",
                table: "SubjectGrades",
                newName: "IX_SubjectGrades_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGrades_GradeID",
                table: "SubjectGrades",
                newName: "IX_SubjectGrades_GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Grades_GradeId",
                table: "SubjectGrades",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectId",
                table: "SubjectGrades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Grades_GradeId",
                table: "SubjectGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectId",
                table: "SubjectGrades");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "SubjectGrades",
                newName: "SubjectID");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "SubjectGrades",
                newName: "GradeID");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGrades_SubjectId",
                table: "SubjectGrades",
                newName: "IX_SubjectGrades_SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGrades_GradeId",
                table: "SubjectGrades",
                newName: "IX_SubjectGrades_GradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Grades_GradeID",
                table: "SubjectGrades",
                column: "GradeID",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectID",
                table: "SubjectGrades",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
