using Microsoft.EntityFrameworkCore.Migrations;

namespace Outlou.Migrations
{
    public partial class ChangedpropertynaminUsermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "UserEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "UserName");
        }
    }
}
