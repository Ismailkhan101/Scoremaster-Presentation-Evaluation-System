using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    public partial class Marks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UsersRegistrations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ExternalUserscs",
                columns: table => new
                {
                    ExternalUserscsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalUserscs", x => x.ExternalUserscsId);
                    table.ForeignKey(
                        name: "FK_ExternalUserscs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalUserscs_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    MarksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UsersRegistrationId = table.Column<int>(type: "int", nullable: true),
                    ExternalUserscsId = table.Column<int>(type: "int", nullable: true),
                    MemberDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.MarksId);
                    table.ForeignKey(
                        name: "FK_Marks_ExternalUserscs_ExternalUserscsId",
                        column: x => x.ExternalUserscsId,
                        principalTable: "ExternalUserscs",
                        principalColumn: "ExternalUserscsId");
                    table.ForeignKey(
                        name: "FK_Marks_MemberDatas_MemberDataId",
                        column: x => x.MemberDataId,
                        principalTable: "MemberDatas",
                        principalColumn: "MemberDataId");
                    table.ForeignKey(
                        name: "FK_Marks_UsersRegistrations_UsersRegistrationId",
                        column: x => x.UsersRegistrationId,
                        principalTable: "UsersRegistrations",
                        principalColumn: "UsersRegistrationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalUserscs_DepartmentId",
                table: "ExternalUserscs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalUserscs_EventId",
                table: "ExternalUserscs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ExternalUserscsId",
                table: "Marks",
                column: "ExternalUserscsId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_MemberDataId",
                table: "Marks",
                column: "MemberDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_UsersRegistrationId",
                table: "Marks",
                column: "UsersRegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "ExternalUserscs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UsersRegistrations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Departments");
        }
    }
}
