using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class RubricCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalUserscs_Roles_ROleId",
                table: "ExternalUserscs");

            migrationBuilder.RenameColumn(
                name: "ROleId",
                table: "ExternalUserscs",
                newName: "RolesROleId");

            migrationBuilder.RenameIndex(
                name: "IX_ExternalUserscs_ROleId",
                table: "ExternalUserscs",
                newName: "IX_ExternalUserscs_RolesROleId");

            migrationBuilder.AddColumn<int>(
                name: "RubricCreateId",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RubricCreates",
                columns: table => new
                {
                    RubricCreateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RubricName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubricCreates", x => x.RubricCreateId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramlearingOutcomes",
                columns: table => new
                {
                    ProgramlearingOutcomesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RubricCreateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramlearingOutcomes", x => x.ProgramlearingOutcomesId);
                    table.ForeignKey(
                        name: "FK_ProgramlearingOutcomes_RubricCreates_RubricCreateId",
                        column: x => x.RubricCreateId,
                        principalTable: "RubricCreates",
                        principalColumn: "RubricCreateId");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriteria",
                columns: table => new
                {
                    EvaluationCriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramlearingOutcomesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriteria", x => x.EvaluationCriteriaId);
                    table.ForeignKey(
                        name: "FK_EvaluationCriteria_ProgramlearingOutcomes_ProgramlearingOutcomesId",
                        column: x => x.ProgramlearingOutcomesId,
                        principalTable: "ProgramlearingOutcomes",
                        principalColumn: "ProgramlearingOutcomesId");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationLevels",
                columns: table => new
                {
                    EvaluationLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BelowAverae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboveAverae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excellent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EvaluationCriteriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationLevels", x => x.EvaluationLevelId);
                    table.ForeignKey(
                        name: "FK_EvaluationLevels_EvaluationCriteria_EvaluationCriteriaId",
                        column: x => x.EvaluationCriteriaId,
                        principalTable: "EvaluationCriteria",
                        principalColumn: "EvaluationCriteriaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_RubricCreateId",
                table: "Event",
                column: "RubricCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriteria_ProgramlearingOutcomesId",
                table: "EvaluationCriteria",
                column: "ProgramlearingOutcomesId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationLevels_EvaluationCriteriaId",
                table: "EvaluationLevels",
                column: "EvaluationCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramlearingOutcomes_RubricCreateId",
                table: "ProgramlearingOutcomes",
                column: "RubricCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_RubricCreates_RubricCreateId",
                table: "Event",
                column: "RubricCreateId",
                principalTable: "RubricCreates",
                principalColumn: "RubricCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalUserscs_Roles_RolesROleId",
                table: "ExternalUserscs",
                column: "RolesROleId",
                principalTable: "Roles",
                principalColumn: "ROleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_RubricCreates_RubricCreateId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalUserscs_Roles_RolesROleId",
                table: "ExternalUserscs");

            migrationBuilder.DropTable(
                name: "EvaluationLevels");

            migrationBuilder.DropTable(
                name: "EvaluationCriteria");

            migrationBuilder.DropTable(
                name: "ProgramlearingOutcomes");

            migrationBuilder.DropTable(
                name: "RubricCreates");

            migrationBuilder.DropIndex(
                name: "IX_Event_RubricCreateId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "RubricCreateId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "RolesROleId",
                table: "ExternalUserscs",
                newName: "ROleId");

            migrationBuilder.RenameIndex(
                name: "IX_ExternalUserscs_RolesROleId",
                table: "ExternalUserscs",
                newName: "IX_ExternalUserscs_ROleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalUserscs_Roles_ROleId",
                table: "ExternalUserscs",
                column: "ROleId",
                principalTable: "Roles",
                principalColumn: "ROleId");
        }
    }
}
