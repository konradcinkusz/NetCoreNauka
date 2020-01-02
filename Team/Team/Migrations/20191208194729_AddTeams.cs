using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Team.Migrations
{
    public partial class AddTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player10PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player11PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player12PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player1PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player2PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player3PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player4PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player5PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player6PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player7PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player8PlayerID = table.Column<int>(type: "int", nullable: true),
                    Player9PlayerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player10PlayerID",
                        column: x => x.Player10PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player11PlayerID",
                        column: x => x.Player11PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player12PlayerID",
                        column: x => x.Player12PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player1PlayerID",
                        column: x => x.Player1PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player2PlayerID",
                        column: x => x.Player2PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player3PlayerID",
                        column: x => x.Player3PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player4PlayerID",
                        column: x => x.Player4PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player5PlayerID",
                        column: x => x.Player5PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player6PlayerID",
                        column: x => x.Player6PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player7PlayerID",
                        column: x => x.Player7PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player8PlayerID",
                        column: x => x.Player8PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player9PlayerID",
                        column: x => x.Player9PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player10PlayerID",
                table: "Teams",
                column: "Player10PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player11PlayerID",
                table: "Teams",
                column: "Player11PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player12PlayerID",
                table: "Teams",
                column: "Player12PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player1PlayerID",
                table: "Teams",
                column: "Player1PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player2PlayerID",
                table: "Teams",
                column: "Player2PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player3PlayerID",
                table: "Teams",
                column: "Player3PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player4PlayerID",
                table: "Teams",
                column: "Player4PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player5PlayerID",
                table: "Teams",
                column: "Player5PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player6PlayerID",
                table: "Teams",
                column: "Player6PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player7PlayerID",
                table: "Teams",
                column: "Player7PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player8PlayerID",
                table: "Teams",
                column: "Player8PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player9PlayerID",
                table: "Teams",
                column: "Player9PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
