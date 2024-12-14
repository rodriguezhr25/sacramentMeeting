using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicSelection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HymnNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicSelection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConductingLeader = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OpeningSongId = table.Column<int>(type: "int", nullable: true),
                    OpeningPrayer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SacramentHymnId = table.Column<int>(type: "int", nullable: true),
                    IntermediateHymnId = table.Column<int>(type: "int", nullable: true),
                    CloseningSongId = table.Column<int>(type: "int", nullable: true),
                    CloseningPrayer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    Announcements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Acknowledgements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_MusicSelection_CloseningSongId",
                        column: x => x.CloseningSongId,
                        principalTable: "MusicSelection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meeting_MusicSelection_IntermediateHymnId",
                        column: x => x.IntermediateHymnId,
                        principalTable: "MusicSelection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meeting_MusicSelection_OpeningSongId",
                        column: x => x.OpeningSongId,
                        principalTable: "MusicSelection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meeting_MusicSelection_SacramentHymnId",
                        column: x => x.SacramentHymnId,
                        principalTable: "MusicSelection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Speech",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    NameSpeaker = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                name: "IX_Meeting_CloseningSongId",
                table: "Meeting",
                column: "CloseningSongId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_IntermediateHymnId",
                table: "Meeting",
                column: "IntermediateHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_OpeningSongId",
                table: "Meeting",
                column: "OpeningSongId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_SacramentHymnId",
                table: "Meeting",
                column: "SacramentHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_Speech_MeetingId",
                table: "Speech",
                column: "MeetingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speech");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "MusicSelection");
        }
    }
}
