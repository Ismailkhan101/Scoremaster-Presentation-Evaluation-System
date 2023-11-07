using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ROleId",
                table: "UsersRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ROleId",
                table: "ExternalUserscs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ROleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ROleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRegistrations_ROleId",
                table: "UsersRegistrations",
                column: "ROleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalUserscs_ROleId",
                table: "ExternalUserscs",
                column: "ROleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalUserscs_Roles_ROleId",
                table: "ExternalUserscs",
                column: "ROleId",
                principalTable: "Roles",
                principalColumn: "ROleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRegistrations_Roles_ROleId",
                table: "UsersRegistrations",
                column: "ROleId",
                principalTable: "Roles",
                principalColumn: "ROleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalUserscs_Roles_ROleId",
                table: "ExternalUserscs");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRegistrations_Roles_ROleId",
                table: "UsersRegistrations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_UsersRegistrations_ROleId",
                table: "UsersRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_ExternalUserscs_ROleId",
                table: "ExternalUserscs");

            migrationBuilder.DropColumn(
                name: "ROleId",
                table: "UsersRegistrations");

            migrationBuilder.DropColumn(
                name: "ROleId",
                table: "ExternalUserscs");
        }
    }
}
