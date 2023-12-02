using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class externalRubric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RubricCreateId",
                table: "ExternalUserscs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalUserscs_RubricCreateId",
                table: "ExternalUserscs",
                column: "RubricCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalUserscs_RubricCreates_RubricCreateId",
                table: "ExternalUserscs",
                column: "RubricCreateId",
                principalTable: "RubricCreates",
                principalColumn: "RubricCreateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalUserscs_RubricCreates_RubricCreateId",
                table: "ExternalUserscs");

            migrationBuilder.DropIndex(
                name: "IX_ExternalUserscs_RubricCreateId",
                table: "ExternalUserscs");

            migrationBuilder.DropColumn(
                name: "RubricCreateId",
                table: "ExternalUserscs");
        }
    }
}
