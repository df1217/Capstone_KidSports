using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidSports.Migrations
{
    public partial class applinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    ApplicationStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppApprovalDate = table.Column<DateTime>(nullable: true),
                    AppCompletionDate = table.Column<DateTime>(nullable: true),
                    AppDenialDate = table.Column<DateTime>(nullable: true),
                    AppStartDate = table.Column<DateTime>(nullable: false),
                    ApplicationID = table.Column<int>(nullable: false),
                    BadgeApprovalDate = table.Column<DateTime>(nullable: true),
                    BadgeDenialDate = table.Column<DateTime>(nullable: true),
                    BadgeSubmissionDate = table.Column<DateTime>(nullable: true),
                    CoachInfoApprovalDate = table.Column<DateTime>(nullable: true),
                    CoachInfoDenialDate = table.Column<DateTime>(nullable: true),
                    CoachInfoSubmissionDate = table.Column<DateTime>(nullable: true),
                    CoachInterestApprovalDate = table.Column<DateTime>(nullable: true),
                    CoachInterestDenialDate = table.Column<DateTime>(nullable: true),
                    CoachInterestSubmissionDate = table.Column<DateTime>(nullable: true),
                    IdApprovalDate = table.Column<DateTime>(nullable: true),
                    IdDenialDate = table.Column<DateTime>(nullable: true),
                    IdSubmissionDate = table.Column<DateTime>(nullable: true),
                    NFHSApprovalDate = table.Column<DateTime>(nullable: true),
                    NFHSDenialDate = table.Column<DateTime>(nullable: true),
                    NFHSSubmissionDate = table.Column<DateTime>(nullable: true),
                    PcaApprovalDate = table.Column<DateTime>(nullable: true),
                    PcaDenialDate = table.Column<DateTime>(nullable: true),
                    PcaSubmissionDate = table.Column<DateTime>(nullable: true),
                    PledgeApprovalDate = table.Column<DateTime>(nullable: true),
                    PledgeDenialDate = table.Column<DateTime>(nullable: true),
                    PledgeSubmissionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.ApplicationStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExperienceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "PreviousGradesCoached",
                columns: table => new
                {
                    PreviousGradesCoachedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousGradesCoached", x => x.PreviousGradesCoachedID);
                });

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
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Applinks",
                columns: table => new
                {
                    UpdateApplinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    BevBlog = table.Column<string>(nullable: true),
                    CoachPledge = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FaceBookCoach = table.Column<string>(nullable: true),
                    FaceBookKidsports = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Instragram = table.Column<string>(nullable: true),
                    NFHS = table.Column<string>(nullable: true),
                    PCA = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Voucher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applinks", x => x.UpdateApplinkID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppAreaJoin",
                columns: table => new
                {
                    AppAreaJoinID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<int>(nullable: false),
                    AreaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAreaJoin", x => x.AppAreaJoinID);
                });

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
                });

            migrationBuilder.CreateTable(
                name: "AppStateJoin",
                columns: table => new
                {
                    AppStateJoinID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<int>(nullable: false),
                    StateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStateJoin", x => x.AppStateJoinID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AlternatePhone = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PreferredName = table.Column<string>(nullable: true),
                    PreviousLastName1 = table.Column<string>(nullable: true),
                    PreviousLastName2 = table.Column<string>(nullable: true),
                    PreviousLastName3 = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    currentYearAppApplicationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AppAreaAreaID = table.Column<int>(nullable: true),
                    AppGender = table.Column<string>(nullable: true),
                    AppGrade = table.Column<string>(nullable: true),
                    AppSchoolSchoolID = table.Column<int>(nullable: true),
                    AppSportSportID = table.Column<int>(nullable: true),
                    BackgroundRequest = table.Column<string>(nullable: true),
                    BackgroundResult = table.Column<string>(nullable: true),
                    BadgePath = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ConcussionCourseSubmissionDate = table.Column<DateTime>(nullable: false),
                    CurrentEmployer = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    DlPath = table.Column<string>(nullable: true),
                    HasContacted = table.Column<bool>(nullable: false),
                    IsAssistantCoach = table.Column<bool>(nullable: false),
                    IsHeadCoach = table.Column<bool>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    LivedOutsideUSA = table.Column<bool>(nullable: false),
                    NameOfChild = table.Column<string>(nullable: true),
                    NfhsIsChecked = table.Column<bool>(nullable: false),
                    NfhsPath = table.Column<string>(nullable: true),
                    PcaCourseSubmissionDate = table.Column<DateTime>(nullable: false),
                    PcaIsChecked = table.Column<bool>(nullable: false),
                    PcaPath = table.Column<string>(nullable: true),
                    PcaVoucherCode = table.Column<string>(nullable: true),
                    PledgeInitials = table.Column<string>(nullable: true),
                    PledgeName = table.Column<string>(nullable: true),
                    PledgeSubmissionDate = table.Column<DateTime>(nullable: false),
                    StateID = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    YearsExperience = table.Column<int>(nullable: false),
                    YearsLivedInOregon = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    pledgeIsInAgreement = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Applications_Areas_AppAreaAreaID",
                        column: x => x.AppAreaAreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Applications_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAreaJoin_ApplicationID",
                table: "AppAreaJoin",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_AppExpJoin_ApplicationID",
                table: "AppExpJoin",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppAreaAreaID",
                table: "Applications",
                column: "AppAreaAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppSchoolSchoolID",
                table: "Applications",
                column: "AppSchoolSchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppSportSportID",
                table: "Applications",
                column: "AppSportSportID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StateID",
                table: "Applications",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStateJoin_ApplicationID",
                table: "AppStateJoin",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_AreaID",
                table: "Schools",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_currentYearAppApplicationID",
                table: "AspNetUsers",
                column: "currentYearAppApplicationID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAreaJoin_Applications_ApplicationID",
                table: "AppAreaJoin",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppExpJoin_Applications_ApplicationID",
                table: "AppExpJoin",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppStateJoin_Applications_ApplicationID",
                table: "AppStateJoin",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Applications_currentYearAppApplicationID",
                table: "AspNetUsers",
                column: "currentYearAppApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Applications_currentYearAppApplicationID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppAreaJoin");

            migrationBuilder.DropTable(
                name: "AppExpJoin");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "AppStateJoin");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "PreviousGradesCoached");

            migrationBuilder.DropTable(
                name: "Applinks");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
