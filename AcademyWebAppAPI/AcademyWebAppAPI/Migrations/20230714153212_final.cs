using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyWebAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SupervisorName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SupervisorPhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupervisorLandlineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    CourseDurationInHours = table.Column<int>(type: "int", nullable: false),
                    CourseCost = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    AcademyInNumbersPage = table.Column<bool>(type: "bit", nullable: false),
                    GroupsPage = table.Column<bool>(type: "bit", nullable: false),
                    UsersPage = table.Column<bool>(type: "bit", nullable: false),
                    BranchesPage = table.Column<bool>(type: "bit", nullable: false),
                    CoursesPage = table.Column<bool>(type: "bit", nullable: false),
                    SubjectsPage = table.Column<bool>(type: "bit", nullable: false),
                    TraineeAdditionPage = table.Column<bool>(type: "bit", nullable: false),
                    CoursesToTraineeAdditionPage = table.Column<bool>(type: "bit", nullable: false),
                    TraineeCombinedAccountStatementPage = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    TraineeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeNationalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicFullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EnglishFullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    FirstPhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondPhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LandlineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AcademicQualification = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    QualificationObtainingYear = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<int>(type: "int", nullable: true),
                    MilitaryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalPhoto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NationalIdCardCopy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AcademicQualificationCopy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.TraineeId);
                    table.ForeignKey(
                        name: "FK_Trainee_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Branch",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_User_Group",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_User_Language",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId");
                });

            migrationBuilder.CreateTable(
                name: "TraineeCourseRelation",
                columns: table => new
                {
                    TraineeId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeCourseRelation", x => new { x.TraineeId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_TraineeCourseRelation_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_TraineeCourseRelation_Trainee",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "TraineeId");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReceivedMoneyAmount = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    DashboardUser = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    TraineeId = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_Transaction_Trainee",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "TraineeId");
                });

            migrationBuilder.CreateIndex(
                name: "branchIsDeletedIndex",
                table: "Branch",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "courseIsDeletedIndex",
                table: "Course",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseName",
                table: "Course",
                column: "CourseName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "groupIsDeletedIndex",
                table: "Group",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "languageIsDeletedIndex",
                table: "Language",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CourseId",
                table: "Subject",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "subjectIsDeletedIndex",
                table: "Subject",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_BranchId",
                table: "Trainee",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "traineeIsDeletedIndex",
                table: "Trainee",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourseRelation_CourseId",
                table: "TraineeCourseRelation",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CourseId",
                table: "Transaction",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TraineeId",
                table: "Transaction",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "transactionIsDeletedIndex",
                table: "Transaction",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_User_BranchId",
                table: "User",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FullName",
                table: "User",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId",
                table: "User",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LanguageId",
                table: "User",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "userIsDeletedIndex",
                table: "User",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "TraineeCourseRelation");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
