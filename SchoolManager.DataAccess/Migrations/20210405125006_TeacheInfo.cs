using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManager.DataAccess.Migrations
{
    public partial class TeacheInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "common_teacher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InTake = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Code = table.Column<string>(type: "varchar(6) CHARACTER SET utf8mb4", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    CellPhone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ZipCode = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EmContacts = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EmConPhone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SchoolInfoId = table.Column<int>(type: "int", nullable: false),
                    MajorInfoId = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<Guid>(type: "char(36)", nullable: true),
                    GradeClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_common_teacher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_common_teacher_basic_gradeclasss_GradeClassId",
                        column: x => x.GradeClassId,
                        principalTable: "basic_gradeclasss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_common_teacher_basic_major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "basic_major",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_common_teacher_basic_major_MajorInfoId",
                        column: x => x.MajorInfoId,
                        principalTable: "basic_major",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_common_teacher_basic_position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "basic_position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_common_teacher_basic_schools_SchoolInfoId",
                        column: x => x.SchoolInfoId,
                        principalTable: "basic_schools",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_common_teacher_basic_titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "basic_titles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_common_teacher_FileAttachments_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Middle_TeacherHonor",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    HonorId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Middle_TeacherHonor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherHonor_basic_honors_HonorId",
                        column: x => x.HonorId,
                        principalTable: "basic_honors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherHonor_common_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "common_teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Middle_TeacherMajorManager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HonorId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Middle_TeacherMajorManager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherMajorManager_basic_honors_HonorId",
                        column: x => x.HonorId,
                        principalTable: "basic_honors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherMajorManager_common_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "common_teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Middle_TeacherProject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Middle_TeacherProject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherProject_basic_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "basic_projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherProject_common_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "common_teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Middle_TeacherProjectManager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Middle_TeacherProjectManager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherProjectManager_basic_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "basic_projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherProjectManager_common_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "common_teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Middle_TeacherSubject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Middle_TeacherSubject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherSubject_basic_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "basic_subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Middle_TeacherSubject_common_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "common_teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_GradeClassId",
                table: "common_teacher",
                column: "GradeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_MajorId",
                table: "common_teacher",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_MajorInfoId",
                table: "common_teacher",
                column: "MajorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_PhotoId",
                table: "common_teacher",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_PositionId",
                table: "common_teacher",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_SchoolInfoId",
                table: "common_teacher",
                column: "SchoolInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_common_teacher_TitleId",
                table: "common_teacher",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherHonor_HonorId",
                table: "Middle_TeacherHonor",
                column: "HonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherHonor_TeacherId",
                table: "Middle_TeacherHonor",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherMajorManager_HonorId",
                table: "Middle_TeacherMajorManager",
                column: "HonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherMajorManager_TeacherId",
                table: "Middle_TeacherMajorManager",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherProject_ProjectId",
                table: "Middle_TeacherProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherProject_TeacherId",
                table: "Middle_TeacherProject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherProjectManager_ProjectId",
                table: "Middle_TeacherProjectManager",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherProjectManager_TeacherId",
                table: "Middle_TeacherProjectManager",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherSubject_SubjectId",
                table: "Middle_TeacherSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Middle_TeacherSubject_TeacherId",
                table: "Middle_TeacherSubject",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Middle_TeacherHonor");

            migrationBuilder.DropTable(
                name: "Middle_TeacherMajorManager");

            migrationBuilder.DropTable(
                name: "Middle_TeacherProject");

            migrationBuilder.DropTable(
                name: "Middle_TeacherProjectManager");

            migrationBuilder.DropTable(
                name: "Middle_TeacherSubject");

            migrationBuilder.DropTable(
                name: "common_teacher");
        }
    }
}
