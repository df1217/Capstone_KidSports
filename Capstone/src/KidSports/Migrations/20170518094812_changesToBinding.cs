using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidSports.Migrations
{
    public partial class changesToBinding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Applications_ApplicationID",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_ApplicationID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "Experiences");

            migrationBuilder.CreateTable(
                name: "AppExpJoin",
                columns: table => new
                {
                    AppExpJoinID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<int>(nullable: false),
                    ExperienceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppExpJoin", x => x.AppExpJoinID);
                    table.ForeignKey(
                        name: "FK_AppExpJoin_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<string>(
                name: "AlternatePhone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppExpJoin_ApplicationID",
                table: "AppExpJoin",
                column: "ApplicationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternatePhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreferredName",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppExpJoin");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "Experiences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ApplicationID",
                table: "Experiences",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Applications_ApplicationID",
                table: "Experiences",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
