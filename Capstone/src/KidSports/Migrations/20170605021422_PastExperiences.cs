using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidSports.Migrations
{
    public partial class PastExperiences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppExpJoin_Applications_ApplicationID",
                table: "AppExpJoin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppExpJoin",
                table: "AppExpJoin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PastExperiences",
                table: "AppExpJoin",
                column: "AppExpJoinID");

            migrationBuilder.AddForeignKey(
                name: "FK_PastExperiences_Applications_ApplicationID",
                table: "AppExpJoin",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_AppExpJoin_ApplicationID",
                table: "AppExpJoin",
                newName: "IX_PastExperiences_ApplicationID");

            migrationBuilder.RenameTable(
                name: "AppExpJoin",
                newName: "PastExperiences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastExperiences_Applications_ApplicationID",
                table: "PastExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PastExperiences",
                table: "PastExperiences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppExpJoin",
                table: "PastExperiences",
                column: "AppExpJoinID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppExpJoin_Applications_ApplicationID",
                table: "PastExperiences",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_PastExperiences_ApplicationID",
                table: "PastExperiences",
                newName: "IX_AppExpJoin_ApplicationID");

            migrationBuilder.RenameTable(
                name: "PastExperiences",
                newName: "AppExpJoin");
        }
    }
}
