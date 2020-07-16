using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentalApp.Migrations
{
    public partial class InitialCreate : Migration
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
                    CloseningSong = table.Column<string>(maxLength: 100, nullable: true),
                    CloseningPrayer = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speech",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(nullable: false),
                    NameSpeaker = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speech", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speech_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speech_MeetingId",
                table: "Speech",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speech");

            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
