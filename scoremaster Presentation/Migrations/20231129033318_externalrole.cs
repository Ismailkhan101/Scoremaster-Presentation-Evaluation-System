using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class externalrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalUserscs_Roles_RolesROleId",
                table: "ExternalUserscs");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalUserscs_Roles_RolesROleId",
                table: "ExternalUserscs",
                column: "RolesROleId",
                principalTable: "Roles",
                principalColumn: "ROleId");
        }
    }
}
