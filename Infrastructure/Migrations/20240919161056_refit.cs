using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBTPreparation_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_SessionResults_SessionQuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionResults_CbtSessions_CbtSessionId",
                table: "SessionResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionResults",
                table: "SessionResults");

            migrationBuilder.RenameTable(
                name: "SessionResults",
                newName: "SessionQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_SessionResults_CbtSessionId",
                table: "SessionQuestions",
                newName: "IX_SessionQuestions_CbtSessionId");

            migrationBuilder.AddColumn<int>(
                name: "CurrentQuestionNumberInProgress",
                table: "CbtSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InProgress",
                table: "CbtSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionQuestions",
                table: "SessionQuestions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FreeQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "FreeOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionAlpha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_FreeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeOptions_FreeQuestions_FreeQuestionId",
                        column: x => x.FreeQuestionId,
                        principalTable: "FreeQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreeOptions_FreeQuestionId",
                table: "FreeOptions",
                column: "FreeQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_SessionQuestions_SessionQuestionId",
                table: "Option",
                column: "SessionQuestionId",
                principalTable: "SessionQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionQuestions_CbtSessions_CbtSessionId",
                table: "SessionQuestions",
                column: "CbtSessionId",
                principalTable: "CbtSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_SessionQuestions_SessionQuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionQuestions_CbtSessions_CbtSessionId",
                table: "SessionQuestions");

            migrationBuilder.DropTable(
                name: "FreeOptions");

            migrationBuilder.DropTable(
                name: "FreeQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionQuestions",
                table: "SessionQuestions");

            migrationBuilder.DropColumn(
                name: "CurrentQuestionNumberInProgress",
                table: "CbtSessions");

            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "CbtSessions");

            migrationBuilder.RenameTable(
                name: "SessionQuestions",
                newName: "SessionResults");

            migrationBuilder.RenameIndex(
                name: "IX_SessionQuestions_CbtSessionId",
                table: "SessionResults",
                newName: "IX_SessionResults_CbtSessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionResults",
                table: "SessionResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_SessionResults_SessionQuestionId",
                table: "Option",
                column: "SessionQuestionId",
                principalTable: "SessionResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionResults_CbtSessions_CbtSessionId",
                table: "SessionResults",
                column: "CbtSessionId",
                principalTable: "CbtSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
