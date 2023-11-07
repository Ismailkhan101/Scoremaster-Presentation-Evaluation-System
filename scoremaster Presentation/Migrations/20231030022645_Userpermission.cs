using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class Userpermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesmissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "UserPermisions",
                columns: table => new
                {
                    UserPermisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<int>(type: "int", nullable: true),
                    ExternalUserscsId = table.Column<int>(type: "int", nullable: true),
                    UsersRegistrationId = table.Column<int>(type: "int", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermisions", x => x.UserPermisionId);
                    table.ForeignKey(
                        name: "FK_UserPermisions_ExternalUserscs_ExternalUserscsId",
                        column: x => x.ExternalUserscsId,
                        principalTable: "ExternalUserscs",
                        principalColumn: "ExternalUserscsId");
                    table.ForeignKey(
                        name: "FK_UserPermisions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId");
                    table.ForeignKey(
                        name: "FK_UserPermisions_UsersRegistrations_UsersRegistrationId",
                        column: x => x.UsersRegistrationId,
                        principalTable: "UsersRegistrations",
                        principalColumn: "UsersRegistrationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermisions_ExternalUserscsId",
                table: "UserPermisions",
                column: "ExternalUserscsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermisions_PermissionId",
                table: "UserPermisions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermisions_UsersRegistrationId",
                table: "UserPermisions",
                column: "UsersRegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermisions");

            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
