using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidSports.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppApprovalDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AppCompletionDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AppIsChecked",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AppStartDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "BcApprovalDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "BcSubmissionDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PrefApprovalDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PrefSubmissionDate",
                table: "Applications");

            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    ApplicationStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppApprovalDate = table.Column<DateTime>(nullable: false),
                    AppCompletionDate = table.Column<DateTime>(nullable: false),
                    AppDenialDate = table.Column<DateTime>(nullable: false),
                    AppStartDate = table.Column<DateTime>(nullable: false),
                    ApplicationID = table.Column<int>(nullable: false),
                    BcApprovalDate = table.Column<DateTime>(nullable: false),
                    BcStartDate = table.Column<DateTime>(nullable: false),
                    BcSubmissionDate = table.Column<DateTime>(nullable: false),
                    PrefApprovalDate = table.Column<DateTime>(nullable: false),
                    PrefDenialDate = table.Column<DateTime>(nullable: false),
                    PrefSubmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.ApplicationStatusID);
                });

            migrationBuilder.AddColumn<bool>(
                name: "HasContacted",
                table: "Applications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasContacted",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AppCompletionDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "AppIsChecked",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AppStartDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BcApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BcSubmissionDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PrefApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PrefSubmissionDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
