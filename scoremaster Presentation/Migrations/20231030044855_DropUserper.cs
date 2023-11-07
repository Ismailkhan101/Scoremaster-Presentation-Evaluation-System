using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class DropUserper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermisions_ExternalUserscs_ExternalUserscsId",
                table: "UserPermisions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermisions_UsersRegistrations_UsersRegistrationId",
                table: "UserPermisions");

            migrationBuilder.DropIndex(
                name: "IX_UserPermisions_ExternalUserscsId",
                table: "UserPermisions");

            migrationBuilder.DropColumn(
                name: "ExternalUserscsId",
                table: "UserPermisions");

            migrationBuilder.RenameColumn(
                name: "UsersRegistrationId",
                table: "UserPermisions",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermisions_UsersRegistrationId",
                table: "UserPermisions",
                newName: "IX_UserPermisions_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermisions_Roles_RoleId",
                table: "UserPermisions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "ROleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermisions_Roles_RoleId",
                table: "UserPermisions");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserPermisions",
                newName: "UsersRegistrationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermisions_RoleId",
                table: "UserPermisions",
                newName: "IX_UserPermisions_UsersRegistrationId");

            migrationBuilder.AddColumn<int>(
                name: "ExternalUserscsId",
                table: "UserPermisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPermisions_ExternalUserscsId",
                table: "UserPermisions",
                column: "ExternalUserscsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermisions_ExternalUserscs_ExternalUserscsId",
                table: "UserPermisions",
                column: "ExternalUserscsId",
                principalTable: "ExternalUserscs",
                principalColumn: "ExternalUserscsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermisions_UsersRegistrations_UsersRegistrationId",
                table: "UserPermisions",
                column: "UsersRegistrationId",
                principalTable: "UsersRegistrations",
                principalColumn: "UsersRegistrationId");
        }
    }
}
