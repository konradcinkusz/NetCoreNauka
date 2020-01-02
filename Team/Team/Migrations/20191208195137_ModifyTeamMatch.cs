using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Team.Migrations
{
    public partial class ModifyTeamMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchs_Players_WinnerPlayerID",
                table: "TeamMatchs");

            migrationBuilder.DropIndex(
                name: "IX_TeamMatchs_WinnerPlayerID",
                table: "TeamMatchs");

            migrationBuilder.DropColumn(
                name: "WinnerPlayerID",
                table: "TeamMatchs");

            migrationBuilder.AddColumn<int>(
                name: "WinnerTeamID",
                table: "TeamMatchs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_WinnerTeamID",
                table: "TeamMatchs",
                column: "WinnerTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchs_Teams_WinnerTeamID",
                table: "TeamMatchs",
                column: "WinnerTeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchs_Teams_WinnerTeamID",
                table: "TeamMatchs");

            migrationBuilder.DropIndex(
                name: "IX_TeamMatchs_WinnerTeamID",
                table: "TeamMatchs");

            migrationBuilder.DropColumn(
                name: "WinnerTeamID",
                table: "TeamMatchs");

            migrationBuilder.AddColumn<int>(
                name: "WinnerPlayerID",
                table: "TeamMatchs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchs_WinnerPlayerID",
                table: "TeamMatchs",
                column: "WinnerPlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchs_Players_WinnerPlayerID",
                table: "TeamMatchs",
                column: "WinnerPlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
