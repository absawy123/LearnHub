using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class finalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResult_Students_Trainee_Id",
                table: "CrsResult");

            migrationBuilder.DropIndex(
                name: "IX_CrsResult_Trainee_Id",
                table: "CrsResult");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CrsResult",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Trainee_Id",
                table: "CrsResult",
                newName: "Student_id");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_StudentId",
                table: "CrsResult",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResult_Students_StudentId",
                table: "CrsResult",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResult_Students_StudentId",
                table: "CrsResult");

            migrationBuilder.DropIndex(
                name: "IX_CrsResult_StudentId",
                table: "CrsResult");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CrsResult",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Student_id",
                table: "CrsResult",
                newName: "Trainee_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_Trainee_Id",
                table: "CrsResult",
                column: "Trainee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResult_Students_Trainee_Id",
                table: "CrsResult",
                column: "Trainee_Id",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
