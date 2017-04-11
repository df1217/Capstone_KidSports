using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidSports.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(nullable: true),
                    MaxGrade = table.Column<int>(nullable: false),
                    MinGrade = table.Column<int>(nullable: false),
                    SportName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IdUserID = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<int>(nullable: true),
                    AreaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaID = table.Column<int>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolID);
                    table.ForeignKey(
                        name: "FK_Schools_Areas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AppApprovalDate = table.Column<DateTime>(nullable: false),
                    AppIsChecked = table.Column<bool>(nullable: false),
                    AppSchoolSchoolID = table.Column<int>(nullable: true),
                    AppSportSportID = table.Column<int>(nullable: true),
                    AppStartDate = table.Column<DateTime>(nullable: false),
                    BackgroundRequest = table.Column<string>(nullable: true),
                    BackgroundResult = table.Column<string>(nullable: true),
                    BadgeApprovalDate = table.Column<DateTime>(nullable: false),
                    BadgePath = table.Column<string>(nullable: true),
                    BadgeSubmissionDate = table.Column<DateTime>(nullable: false),
                    BcApprovalDate = table.Column<DateTime>(nullable: false),
                    BcSubmissionDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CurrentEmployer = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    DlApprovalDate = table.Column<DateTime>(nullable: false),
                    DlPath = table.Column<string>(nullable: true),
                    DlSubmissionDate = table.Column<DateTime>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    NameOfChild = table.Column<string>(nullable: true),
                    NfhsApprovalDate = table.Column<DateTime>(nullable: false),
                    NfhsIsChecked = table.Column<bool>(nullable: false),
                    NfhsPath = table.Column<string>(nullable: true),
                    NfhsSubmissionDate = table.Column<DateTime>(nullable: false),
                    PcaApprovalDate = table.Column<DateTime>(nullable: false),
                    PcaIsChecked = table.Column<bool>(nullable: false),
                    PcaPath = table.Column<string>(nullable: true),
                    PcaSubmissionDate = table.Column<DateTime>(nullable: false),
                    PcaVoucherCode = table.Column<string>(nullable: true),
                    PledgeApprovalDate = table.Column<DateTime>(nullable: false),
                    PledgeInitials = table.Column<string>(nullable: true),
                    PledgeSubmissionDate = table.Column<DateTime>(nullable: false),
                    PrefApprovalDate = table.Column<DateTime>(nullable: false),
                    PrefSubmissionDate = table.Column<DateTime>(nullable: false),
                    PreviousGradesCoached = table.Column<int>(nullable: true),
                    PreviousYearsCoached = table.Column<int>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    YearsExperience = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Applications_Schools_AppSchoolSchoolID",
                        column: x => x.AppSchoolSchoolID,
                        principalTable: "Schools",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Sports_AppSportSportID",
                        column: x => x.AppSportSportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<int>(nullable: true),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Country_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LastName",
                columns: table => new
                {
                    LastNameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastName", x => x.LastNameID);
                    table.ForeignKey(
                        name: "FK_LastName_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<int>(nullable: true),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateID);
                    table.ForeignKey(
                        name: "FK_State_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppSchoolSchoolID",
                table: "Applications",
                column: "AppSchoolSchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppSportSportID",
                table: "Applications",
                column: "AppSportSportID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserID",
                table: "Applications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ApplicationID",
                table: "Areas",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ApplicationID",
                table: "Country",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_LastName_ApplicationID",
                table: "LastName",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_AreaID",
                table: "Schools",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_State_ApplicationID",
                table: "State",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Applications_ApplicationID",
                table: "Areas",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Schools_AppSchoolSchoolID",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "LastName");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
