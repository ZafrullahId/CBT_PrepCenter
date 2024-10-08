using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBTPreparation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ddd_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cbtprep");

            migrationBuilder.CreateTable(
                name: "Admins",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CbtSessions",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    InProgress = table.Column<bool>(type: "bit", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumberOfQuestion = table.Column<int>(type: "int", nullable: false),
                    NumberOfQuestionAttempted = table.Column<int>(type: "int", nullable: false),
                    NumberOfWrongAnswers = table.Column<int>(type: "int", nullable: false),
                    NumberOfCorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    CurrentQuestionNumberInProgress = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CbtSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreeQuestions",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1044)", maxLength: 1044, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOAuthProvider = table.Column<bool>(type: "bit", nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionQuestions",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CbtSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChosenOption = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    IsChosenOptionCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionQuestions_CbtSessions_CbtSessionId",
                        column: x => x.CbtSessionId,
                        principalSchema: "cbtprep",
                        principalTable: "CbtSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreeOption",
                schema: "cbtprep",
                columns: table => new
                {
                    FreeQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionAlpha = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeOption", x => new { x.FreeQuestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_FreeOption_FreeQuestions_FreeQuestionId",
                        column: x => x.FreeQuestionId,
                        principalSchema: "cbtprep",
                        principalTable: "FreeQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnusedTrials = table.Column<int>(type: "int", nullable: false),
                    Department_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "cbtprep",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaidOptions",
                schema: "cbtprep",
                columns: table => new
                {
                    SessionQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionAlpha = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidOptions", x => new { x.SessionQuestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_PaidOptions_SessionQuestions_SessionQuestionId",
                        column: x => x.SessionQuestionId,
                        principalSchema: "cbtprep",
                        principalTable: "SessionQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "cbtprep",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => new { x.StudentId, x.Id });
                    table.ForeignKey(
                        name: "FK_Course_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "cbtprep",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "cbtprep",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrialTransactions",
                schema: "cbtprep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TrialPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrialTransactions_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "cbtprep",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentId",
                schema: "cbtprep",
                table: "Feedbacks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionQuestions_CbtSessionId",
                schema: "cbtprep",
                table: "SessionQuestions",
                column: "CbtSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                schema: "cbtprep",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrialTransactions_StudentId",
                schema: "cbtprep",
                table: "TrialTransactions",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "Feedbacks",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "FreeOption",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "PaidOptions",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "TrialTransactions",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "FreeQuestions",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "SessionQuestions",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "CbtSessions",
                schema: "cbtprep");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "cbtprep");
        }
    }
}
