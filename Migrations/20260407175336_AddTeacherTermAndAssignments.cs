using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Secondary_School_Result_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherTermAndAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Results",
                newName: "ExamScore");

            migrationBuilder.AddColumn<int>(
                name: "CAScore",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TermId",
                table: "Results",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicSession = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjectClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjectClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSubjectClasses_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSubjectClasses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSubjectClasses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_TermId",
                table: "Results",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjectClasses_SchoolClassId",
                table: "TeacherSubjectClasses",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjectClasses_SubjectId",
                table: "TeacherSubjectClasses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjectClasses_TeacherId",
                table: "TeacherSubjectClasses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Terms_TermId",
                table: "Results",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Terms_TermId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "TeacherSubjectClasses");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Results_TermId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CAScore",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TermId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "ExamScore",
                table: "Results",
                newName: "Score");
        }
    }
}
