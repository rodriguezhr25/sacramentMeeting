using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentalApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ConductingLeader = table.Column<string>(maxLength: 100, nullable: true),
                    OpeningSong = table.Column<string>(maxLength: 100, nullable: true),
                    OpeningPrayer = table.Column<string>(maxLength: 100, nullable: true),
                    SacramentHymn = table.Column<string>(maxLength: 100, nullable: true),
                    Speaker = table.Column<string>(maxLength: 100, nullable: true),
                    CloseningSong = table.Column<string>(maxLength: 100, nullable: true),
                    CloseningPrayer = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
