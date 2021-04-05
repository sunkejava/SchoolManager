using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManager.DataAccess.Migrations
{
    public partial class EditTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_common_teacher_basic_major_MajorId",
                table: "common_teacher");

            migrationBuilder.DropIndex(
                name: "IX_common_teacher_MajorId",
                table: "common_teacher");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "common_teacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "common_teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_MajorId",
                table: "common_teacher",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_common_teacher_basic_major_MajorId",
                table: "common_teacher",
                column: "MajorId",
                principalTable: "basic_major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
