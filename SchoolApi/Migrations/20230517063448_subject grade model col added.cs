using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class subjectgrademodelcoladded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditHour",
                table: "SubjectGrades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "FinalPracticalFullMarks",
                table: "SubjectGrades",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FinalTheoryFullMarks",
                table: "SubjectGrades",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditHour",
                table: "SubjectGrades");

            migrationBuilder.DropColumn(
                name: "FinalPracticalFullMarks",
                table: "SubjectGrades");

            migrationBuilder.DropColumn(
                name: "FinalTheoryFullMarks",
                table: "SubjectGrades");
        }
    }
}
