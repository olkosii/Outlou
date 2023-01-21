using Microsoft.EntityFrameworkCore.Migrations;

namespace Outlou.Migrations
{
    public partial class ChangedpropertyinReadNewsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedUrl",
                table: "ReadNews");

            migrationBuilder.AddColumn<int>(
                name: "FeedId",
                table: "ReadNews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedId",
                table: "ReadNews");

            migrationBuilder.AddColumn<string>(
                name: "FeedUrl",
                table: "ReadNews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
