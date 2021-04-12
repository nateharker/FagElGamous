using Microsoft.EntityFrameworkCore.Migrations;

namespace FagElGamous.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeleteRoles",
                columns: table => new
                {
                    DeleteRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteRoles", x => x.DeleteRoleId);
                });

            migrationBuilder.CreateTable(
                name: "WriteRoles",
                columns: table => new
                {
                    WriteRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteRoles", x => x.WriteRoleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeleteRoles");

            migrationBuilder.DropTable(
                name: "WriteRoles");
        }
    }
}
