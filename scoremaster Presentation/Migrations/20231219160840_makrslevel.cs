using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class makrslevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvaluationLevelId",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvaluationLevelsEvaluationLevelId",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_EvaluationLevelsEvaluationLevelId",
                table: "Marks",
                column: "EvaluationLevelsEvaluationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_EventId",
                table: "Marks",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_EvaluationLevels_EvaluationLevelsEvaluationLevelId",
                table: "Marks",
                column: "EvaluationLevelsEvaluationLevelId",
                principalTable: "EvaluationLevels",
                principalColumn: "EvaluationLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Event_EventId",
                table: "Marks",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_EvaluationLevels_EvaluationLevelsEvaluationLevelId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Event_EventId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_EvaluationLevelsEvaluationLevelId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_EventId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "EvaluationLevelId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "EvaluationLevelsEvaluationLevelId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Marks");
        }
    }
}
