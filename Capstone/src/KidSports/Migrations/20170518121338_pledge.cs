using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidSports.Migrations
{
    public partial class pledge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeApprovalDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "BadgeSubmissionDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DlApprovalDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DlSubmissionDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "NfhsApprovalDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "NfhsSubmissionDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PcaApprovalDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PcaSubmissionDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PledgeApprovalDate",
                table: "Applications");

            migrationBuilder.AddColumn<bool>(
                name: "pledgeIsInAgreement",
                table: "Applications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pledgeIsInAgreement",
                table: "Applications");

            migrationBuilder.AddColumn<DateTime>(
                name: "BadgeApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BadgeSubmissionDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DlApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DlSubmissionDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NfhsApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NfhsSubmissionDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PcaApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PcaSubmissionDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PledgeApprovalDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
