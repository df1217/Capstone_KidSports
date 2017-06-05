using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidSports.Migrations
{
    public partial class multiselectdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStateJoin_Applications_ApplicationID",
                table: "AppStateJoin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppStateJoin",
                table: "AppStateJoin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatesLived",
                table: "AppStateJoin",
                column: "AppStateJoinID");

            migrationBuilder.AddForeignKey(
                name: "FK_StatesLived_Applications_ApplicationID",
                table: "AppStateJoin",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_AppStateJoin_ApplicationID",
                table: "AppStateJoin",
                newName: "IX_StatesLived_ApplicationID");

            migrationBuilder.RenameTable(
                name: "AppStateJoin",
                newName: "StatesLived");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatesLived_Applications_ApplicationID",
                table: "StatesLived");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatesLived",
                table: "StatesLived");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppStateJoin",
                table: "StatesLived",
                column: "AppStateJoinID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppStateJoin_Applications_ApplicationID",
                table: "StatesLived",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_StatesLived_ApplicationID",
                table: "StatesLived",
                newName: "IX_AppStateJoin_ApplicationID");

            migrationBuilder.RenameTable(
                name: "StatesLived",
                newName: "AppStateJoin");
        }
    }
}
