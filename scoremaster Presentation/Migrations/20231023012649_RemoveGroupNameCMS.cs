using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class RemoveGroupNameCMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CMSID",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CMSID",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
