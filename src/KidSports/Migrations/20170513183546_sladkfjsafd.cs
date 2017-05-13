using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidSports.Migrations
{
    public partial class sladkfjsafd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_State_StateID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Applications_ApplicationID",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.AddColumn<int>(
                name: "currentYearAppApplicationID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppAreaAreaID",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppGender",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppGrade",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_currentYearAppApplicationID",
                table: "AspNetUsers",
                column: "currentYearAppApplicationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "State",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppAreaAreaID",
                table: "Applications",
                column: "AppAreaAreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Areas_AppAreaAreaID",
                table: "Applications",
                column: "AppAreaAreaID",
                principalTable: "Areas",
                principalColumn: "AreaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_States_StateID",
                table: "Applications",
                column: "StateID",
                principalTable: "State",
                principalColumn: "StateID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Applications_ApplicationID",
                table: "State",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Applications_currentYearAppApplicationID",
                table: "AspNetUsers",
                column: "currentYearAppApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_State_ApplicationID",
                table: "State",
                newName: "IX_States_ApplicationID");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Areas_AppAreaAreaID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_States_StateID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Applications_ApplicationID",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Applications_currentYearAppApplicationID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_currentYearAppApplicationID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Applications_AppAreaAreaID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "currentYearAppApplicationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppAreaAreaID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AppGender",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AppGrade",
                table: "Applications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "States",
                column: "StateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_State_StateID",
                table: "Applications",
                column: "StateID",
                principalTable: "States",
                principalColumn: "StateID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Applications_ApplicationID",
                table: "States",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_States_ApplicationID",
                table: "States",
                newName: "IX_State_ApplicationID");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");
        }
    }
}
