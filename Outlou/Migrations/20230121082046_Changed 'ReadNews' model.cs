using Microsoft.EntityFrameworkCore.Migrations;

namespace Outlou.Migrations
{
    public partial class ChangedReadNewsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsId",
                table: "ReadNews",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "ReadNews");
        }
    }
}
