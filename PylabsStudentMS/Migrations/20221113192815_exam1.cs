using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PylabsStudentMS.Migrations
{
    public partial class exam1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CryptoLink",
                table: "ExamResult",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "ExamResult",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JsonExamId",
                table: "ExamResult",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CryptoLink",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "JsonExamId",
                table: "ExamResult");
        }
    }
}
