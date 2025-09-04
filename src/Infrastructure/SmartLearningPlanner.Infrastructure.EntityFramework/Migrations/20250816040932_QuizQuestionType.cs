using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class QuizQuestionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_MindmapNodes_MindmapNodeId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "AnswerOptions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "QuizQuestions",
                newName: "QuestionTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "MindmapNodeId",
                table: "Quizzes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "QuizQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "QuizQuestionAnswerOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnswerText = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    QuizQuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionAnswerOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestionAnswerOptions_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeCode = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AllowsMultipleAnswers = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresTextAnswer = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuestionTypeId",
                table: "QuizQuestions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionAnswerOptions_QuizQuestionId",
                table: "QuizQuestionAnswerOptions",
                column: "QuizQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_QuizQuestionTypes_QuestionTypeId",
                table: "QuizQuestions",
                column: "QuestionTypeId",
                principalTable: "QuizQuestionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_MindmapNodes_MindmapNodeId",
                table: "Quizzes",
                column: "MindmapNodeId",
                principalTable: "MindmapNodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_QuizQuestionTypes_QuestionTypeId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_MindmapNodes_MindmapNodeId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "QuizQuestionAnswerOptions");

            migrationBuilder.DropTable(
                name: "QuizQuestionTypes");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_QuestionTypeId",
                table: "QuizQuestions");

            migrationBuilder.RenameColumn(
                name: "QuestionTypeId",
                table: "QuizQuestions",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "MindmapNodeId",
                table: "Quizzes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "QuizQuestions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "AnswerOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnswerText = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    QuizQuestionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerOptions_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOptions_QuizQuestionId",
                table: "AnswerOptions",
                column: "QuizQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_MindmapNodes_MindmapNodeId",
                table: "Quizzes",
                column: "MindmapNodeId",
                principalTable: "MindmapNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
