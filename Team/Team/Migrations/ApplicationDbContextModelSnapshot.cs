﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Team.Models;

namespace Team.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Team.Models.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<int?>("Player1PlayerID");

                    b.Property<int?>("Player2PlayerID");

                    b.Property<int?>("Set1SetID");

                    b.Property<int?>("Set2SetID");

                    b.Property<int?>("Set3SetID");

                    b.Property<DateTime>("StartTime");

                    b.Property<int?>("WinnerPlayerID");

                    b.HasKey("MatchID");

                    b.HasIndex("Player1PlayerID");

                    b.HasIndex("Player2PlayerID");

                    b.HasIndex("Set1SetID");

                    b.HasIndex("Set2SetID");

                    b.HasIndex("Set3SetID");

                    b.HasIndex("WinnerPlayerID");

                    b.ToTable("Matchs");
                });

            modelBuilder.Entity("Team.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PlayerAccountID");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Team.Models.Set", b =>
                {
                    b.Property<int>("SetID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<int?>("Player1PlayerID");

                    b.Property<int>("Player1Points");

                    b.Property<int?>("Player2PlayerID");

                    b.Property<int>("Player2Points");

                    b.Property<DateTime>("StartTime");

                    b.Property<int?>("WinnerPlayerID");

                    b.HasKey("SetID");

                    b.HasIndex("Player1PlayerID");

                    b.HasIndex("Player2PlayerID");

                    b.HasIndex("WinnerPlayerID");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Team.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("Player10PlayerID");

                    b.Property<int?>("Player11PlayerID");

                    b.Property<int?>("Player12PlayerID");

                    b.Property<int?>("Player1PlayerID");

                    b.Property<int?>("Player2PlayerID");

                    b.Property<int?>("Player3PlayerID");

                    b.Property<int?>("Player4PlayerID");

                    b.Property<int?>("Player5PlayerID");

                    b.Property<int?>("Player6PlayerID");

                    b.Property<int?>("Player7PlayerID");

                    b.Property<int?>("Player8PlayerID");

                    b.Property<int?>("Player9PlayerID");

                    b.HasKey("TeamID");

                    b.HasIndex("Player10PlayerID");

                    b.HasIndex("Player11PlayerID");

                    b.HasIndex("Player12PlayerID");

                    b.HasIndex("Player1PlayerID");

                    b.HasIndex("Player2PlayerID");

                    b.HasIndex("Player3PlayerID");

                    b.HasIndex("Player4PlayerID");

                    b.HasIndex("Player5PlayerID");

                    b.HasIndex("Player6PlayerID");

                    b.HasIndex("Player7PlayerID");

                    b.HasIndex("Player8PlayerID");

                    b.HasIndex("Player9PlayerID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Team.Models.TeamMatch", b =>
                {
                    b.Property<int>("TeamMatchID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<int?>("Match1MatchID");

                    b.Property<int?>("Match2MatchID");

                    b.Property<int?>("Match3MatchID");

                    b.Property<int?>("Match4MatchID");

                    b.Property<DateTime>("StartTime");

                    b.Property<int?>("Team1TeamID");

                    b.Property<int?>("Team2TeamID");

                    b.Property<int?>("WinnerTeamID");

                    b.HasKey("TeamMatchID");

                    b.HasIndex("Match1MatchID");

                    b.HasIndex("Match2MatchID");

                    b.HasIndex("Match3MatchID");

                    b.HasIndex("Match4MatchID");

                    b.HasIndex("Team1TeamID");

                    b.HasIndex("Team2TeamID");

                    b.HasIndex("WinnerTeamID");

                    b.ToTable("TeamMatchs");
                });

            modelBuilder.Entity("Team.Models.Match", b =>
                {
                    b.HasOne("Team.Models.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1PlayerID");

                    b.HasOne("Team.Models.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2PlayerID");

                    b.HasOne("Team.Models.Set", "Set1")
                        .WithMany()
                        .HasForeignKey("Set1SetID");

                    b.HasOne("Team.Models.Set", "Set2")
                        .WithMany()
                        .HasForeignKey("Set2SetID");

                    b.HasOne("Team.Models.Set", "Set3")
                        .WithMany()
                        .HasForeignKey("Set3SetID");

                    b.HasOne("Team.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerID");
                });

            modelBuilder.Entity("Team.Models.Set", b =>
                {
                    b.HasOne("Team.Models.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1PlayerID");

                    b.HasOne("Team.Models.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2PlayerID");

                    b.HasOne("Team.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerID");
                });

            modelBuilder.Entity("Team.Models.Team", b =>
                {
                    b.HasOne("Team.Models.Player", "Player10")
                        .WithMany()
                        .HasForeignKey("Player10PlayerID");

                    b.HasOne("Team.Models.Player", "Player11")
                        .WithMany()
                        .HasForeignKey("Player11PlayerID");

                    b.HasOne("Team.Models.Player", "Player12")
                        .WithMany()
                        .HasForeignKey("Player12PlayerID");

                    b.HasOne("Team.Models.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1PlayerID");

                    b.HasOne("Team.Models.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2PlayerID");

                    b.HasOne("Team.Models.Player", "Player3")
                        .WithMany()
                        .HasForeignKey("Player3PlayerID");

                    b.HasOne("Team.Models.Player", "Player4")
                        .WithMany()
                        .HasForeignKey("Player4PlayerID");

                    b.HasOne("Team.Models.Player", "Player5")
                        .WithMany()
                        .HasForeignKey("Player5PlayerID");

                    b.HasOne("Team.Models.Player", "Player6")
                        .WithMany()
                        .HasForeignKey("Player6PlayerID");

                    b.HasOne("Team.Models.Player", "Player7")
                        .WithMany()
                        .HasForeignKey("Player7PlayerID");

                    b.HasOne("Team.Models.Player", "Player8")
                        .WithMany()
                        .HasForeignKey("Player8PlayerID");

                    b.HasOne("Team.Models.Player", "Player9")
                        .WithMany()
                        .HasForeignKey("Player9PlayerID");
                });

            modelBuilder.Entity("Team.Models.TeamMatch", b =>
                {
                    b.HasOne("Team.Models.Match", "Match1")
                        .WithMany()
                        .HasForeignKey("Match1MatchID");

                    b.HasOne("Team.Models.Match", "Match2")
                        .WithMany()
                        .HasForeignKey("Match2MatchID");

                    b.HasOne("Team.Models.Match", "Match3")
                        .WithMany()
                        .HasForeignKey("Match3MatchID");

                    b.HasOne("Team.Models.Match", "Match4")
                        .WithMany()
                        .HasForeignKey("Match4MatchID");

                    b.HasOne("Team.Models.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1TeamID");

                    b.HasOne("Team.Models.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2TeamID");

                    b.HasOne("Team.Models.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerTeamID");
                });
#pragma warning restore 612, 618
        }
    }
}
