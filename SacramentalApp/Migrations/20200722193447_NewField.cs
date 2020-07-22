using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentalApp.Migrations
{
    public partial class NewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IntermediateHymn",
                table: "Meeting",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntermediateHymn",
                table: "Meeting");
        }
    }
}
