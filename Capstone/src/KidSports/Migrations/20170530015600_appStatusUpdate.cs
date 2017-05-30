using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidSports.Migrations
{
    public partial class appStatusUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BcApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "BcStartDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "BcSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PrefApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PrefDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PrefSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "BadgeApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BadgeDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BadgeSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CoachInfoApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CoachInfoDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CoachInfoSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CoachInterestApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CoachInterestDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CoachInterestSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IdSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NFHSApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NFHSDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NFHSSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PcaApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PcaDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PcaSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PledgeApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PledgeDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PledgeSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "BadgeDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "BadgeSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "CoachInfoApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "CoachInfoDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "CoachInfoSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "CoachInterestApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "CoachInterestDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "CoachInterestSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "IdApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "IdDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "IdSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "NFHSApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "NFHSDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "NFHSSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PcaApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PcaDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PcaSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PledgeApprovalDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PledgeDenialDate",
                table: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "PledgeSubmissionDate",
                table: "ApplicationStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "BcApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BcStartDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BcSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrefApprovalDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrefDenialDate",
                table: "ApplicationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrefSubmissionDate",
                table: "ApplicationStatus",
                nullable: true);
        }
    }
}
