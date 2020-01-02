using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Team.Migrations
{
    public partial class AddAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    SetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Player1PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player1Points = table.Column<int>(type: "int", nullable: false),
                    Player2PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player2Points = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerPlayerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.SetID);
                    table.ForeignKey(
                        name: "FK_Sets_Players_Player1PlayerID",
                        column: x => x.Player1PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sets_Players_Player2PlayerID",
                        column: x => x.Player2PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sets_Players_WinnerPlayerID",
                        column: x => x.WinnerPlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Player1PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player2PlayerID = table.Column<int>(type: "int", nullable: true),
                    Set1SetID = table.Column<int>(type: "int", nullable: true),
                    Set2SetID = table.Column<int>(type: "int", nullable: true),
                    Set3SetID = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerPlayerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matchs_Players_Player1PlayerID",
                        column: x => x.Player1PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Players_Player2PlayerID",
                        column: x => x.Player2PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Sets_Set1SetID",
                        column: x => x.Set1SetID,
                        principalTable: "Sets",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Sets_Set2SetID",
                        column: x => x.Set2SetID,
                        principalTable: "Sets",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Sets_Set3SetID",
                        column: x => x.Set3SetID,
                        principalTable: "Sets",
                        principalColumn: "SetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Players_WinnerPlayerID",
                        column: x => x.WinnerPlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamMatchs",
                columns: table => new
                {
                    TeamMatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Match1MatchID = table.Column<int>(type: "int", nullable: true),
                    Match2MatchID = table.Column<int>(type: "int", nullable: true),
                    Match3MatchID = table.Column<int>(type: "int", nullable: true),
                    Match4MatchID = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Team1TeamID = table.Column<int>(type: "int", nullable: true),
                    Team2TeamID = table.Column<int>(type: "int", nullable: true),
                    WinnerPlayerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMatchs", x => x.TeamMatchID);
                    table.ForeignKey(
                        name: "FK_TeamMatchs_Matchs_Match1MatchID",
                        column: x => x.Match1MatchID,
                        principalTable: "Matchs",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMatchs_Matchs_Match2MatchID",
                        column: x => x.Match2MatchID,
                        principalTable: "Matchs",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMatchs_Matchs_Match3MatchID",
                        column: x => x.Match3MatchID,
                        principalTable: "Matchs",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMatchs_Matchs_Match4MatchID",
                        column: x => x.Match4MatchID,
                        principalTable: "Matchs",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMatchs_Teams_Team1TeamID",
                        column: x => x.Team1TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMatchs_Teams_Team2TeamID",
                        column: x => x.Team2TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMatchs_Players_WinnerPlayerID",
                        column: x => x.WinnerPlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Player1PlayerID",
                table: "Matchs",
                column: "Player1PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Player2PlayerID",
                table: "Matchs",
                column: "Player2PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Set1SetID",
                table: "Matchs",
                column: "Set1SetID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Set2SetID",
                table: "Matchs",
                column: "Set2SetID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_Set3SetID",
                table: "Matchs",
                column: "Set3SetID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_WinnerPlayerID",
                table: "Matchs",
                column: "WinnerPlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_Player1PlayerID",
                table: "Sets",
                column: "Player1PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_Player2PlayerID",
                table: "Sets",
                column: "Player2PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_WinnerPlayerID",
                table: "Sets",
                column: "WinnerPlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_Match1MatchID",
                table: "TeamMatchs",
                column: "Match1MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_Match2MatchID",
                table: "TeamMatchs",
                column: "Match2MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_Match3MatchID",
                table: "TeamMatchs",
                column: "Match3MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_Match4MatchID",
                table: "TeamMatchs",
                column: "Match4MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_Team1TeamID",
                table: "TeamMatchs",
                column: "Team1TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_Team2TeamID",
                table: "TeamMatchs",
                column: "Team2TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_WinnerPlayerID",
                table: "TeamMatchs",
                column: "WinnerPlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMatchs");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Sets");
        }
    }
}
