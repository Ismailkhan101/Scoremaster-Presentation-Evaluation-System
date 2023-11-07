using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class GroupRelationEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_EventId",
                table: "Groups",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Event_EventId",
                table: "Groups",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Event_EventId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_EventId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Groups");
        }
    }
}
