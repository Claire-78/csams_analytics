using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSAMS.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Prefix = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: true),
                    Created = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    HasComment = table.Column<int>(type: "INTEGER", maxLength: 1, nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    Choices = table.Column<string>(type: "TEXT", nullable: true),
                    Required = table.Column<int>(type: "INTEGER", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fields_Forms_FormID",
                        column: x => x.FormID,
                        principalTable: "Forms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_Forms_FormID",
                        column: x => x.FormID,
                        principalTable: "Forms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Submissions_Forms_FormID",
                        column: x => x.FormID,
                        principalTable: "Forms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Role",
                        column: x => x.Role,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hash = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: true),
                    CourseCode = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: true),
                    CourseName = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: true),
                    Teacher = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Users_Teacher",
                        column: x => x.Teacher,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    SubmissionID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    ReviewEnabled = table.Column<byte>(type: "INTEGER", maxLength: 1, nullable: false),
                    ReviewID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    ReviewDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reviewers = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Reviews_ReviewID",
                        column: x => x.ReviewID,
                        principalTable: "Reviews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Submissions_SubmissionID",
                        column: x => x.SubmissionID,
                        principalTable: "Submissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    CourseID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeerReviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignmentID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    ReviewUserID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerReviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PeerReviews_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeerReviews_Users_ReviewUserID",
                        column: x => x.ReviewUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeerReviews_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserReviewer = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    UserTarget = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    ReviewID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    AssignmentID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserReviews_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviews_Reviews_ReviewID",
                        column: x => x.ReviewID,
                        principalTable: "Reviews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviews_Users_UserReviewer",
                        column: x => x.UserReviewer,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviews_Users_UserTarget",
                        column: x => x.UserTarget,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubmissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    AssignmentID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    SubmissionID = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubmissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserSubmissions_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubmissions_Submissions_SubmissionID",
                        column: x => x.SubmissionID,
                        principalTable: "Submissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubmissions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ReviewID",
                table: "Assignments",
                column: "ReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SubmissionID",
                table: "Assignments",
                column: "SubmissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Teacher",
                table: "Courses",
                column: "Teacher");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FormID",
                table: "Fields",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_PeerReviews_AssignmentID",
                table: "PeerReviews",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PeerReviews_ReviewUserID",
                table: "PeerReviews",
                column: "ReviewUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PeerReviews_UserID",
                table: "PeerReviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FormID",
                table: "Reviews",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_FormID",
                table: "Submissions",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseID",
                table: "UserCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserID",
                table: "UserCourses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_AssignmentID",
                table: "UserReviews",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewID",
                table: "UserReviews",
                column: "ReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_UserReviewer",
                table: "UserReviews",
                column: "UserReviewer");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_UserTarget",
                table: "UserReviews",
                column: "UserTarget");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role",
                table: "Users",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubmissions_AssignmentID",
                table: "UserSubmissions",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubmissions_SubmissionID",
                table: "UserSubmissions",
                column: "SubmissionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubmissions_UserID",
                table: "UserSubmissions",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "PeerReviews");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "UserReviews");

            migrationBuilder.DropTable(
                name: "UserSubmissions");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
