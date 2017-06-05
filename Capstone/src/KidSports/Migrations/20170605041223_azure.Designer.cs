using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KidSports.Repositories;

namespace KidSports.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170605041223_azure")]
    partial class azure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KidSports.Models.AppAreaJoin", b =>
                {
                    b.Property<int>("AppAreaJoinID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationID");

                    b.Property<int>("AreaID");

                    b.HasKey("AppAreaJoinID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("AppAreaJoin");
                });

            modelBuilder.Entity("KidSports.Models.AppExpJoin", b =>
                {
                    b.Property<int>("AppExpJoinID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationID");

                    b.Property<int>("ExperienceID");

                    b.HasKey("AppExpJoinID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("PastExperiences");
                });

            modelBuilder.Entity("KidSports.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("AppAreaAreaID");

                    b.Property<string>("AppGender");

                    b.Property<string>("AppGrade");

                    b.Property<int?>("AppSchoolSchoolID");

                    b.Property<int?>("AppSportSportID");

                    b.Property<string>("BackgroundRequest");

                    b.Property<string>("BackgroundResult");

                    b.Property<string>("BadgePath");

                    b.Property<string>("City");

                    b.Property<DateTime>("ConcussionCourseSubmissionDate");

                    b.Property<string>("CurrentEmployer");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("DlPath");

                    b.Property<bool>("HasContacted");

                    b.Property<bool>("IsAssistantCoach");

                    b.Property<bool>("IsHeadCoach");

                    b.Property<string>("JobTitle");

                    b.Property<bool>("LivedOutsideUSA");

                    b.Property<string>("NameOfChild");

                    b.Property<bool>("NfhsIsChecked");

                    b.Property<string>("NfhsPath");

                    b.Property<DateTime>("PcaCourseSubmissionDate");

                    b.Property<bool>("PcaIsChecked");

                    b.Property<string>("PcaPath");

                    b.Property<string>("PcaVoucherCode");

                    b.Property<string>("PledgeInitials");

                    b.Property<string>("PledgeName");

                    b.Property<DateTime>("PledgeSubmissionDate");

                    b.Property<int?>("StateID");

                    b.Property<string>("UserId");

                    b.Property<int>("YearsExperience");

                    b.Property<int>("YearsLivedInOregon");

                    b.Property<string>("ZipCode");

                    b.Property<bool>("pledgeIsInAgreement");

                    b.HasKey("ApplicationID");

                    b.HasIndex("AppAreaAreaID");

                    b.HasIndex("AppSchoolSchoolID");

                    b.HasIndex("AppSportSportID");

                    b.HasIndex("StateID");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("KidSports.Models.ApplicationStatus", b =>
                {
                    b.Property<int>("ApplicationStatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AppApprovalDate");

                    b.Property<DateTime?>("AppCompletionDate");

                    b.Property<DateTime?>("AppDenialDate");

                    b.Property<DateTime>("AppStartDate");

                    b.Property<int>("ApplicationID");

                    b.Property<DateTime?>("BadgeApprovalDate");

                    b.Property<DateTime?>("BadgeDenialDate");

                    b.Property<DateTime?>("BadgeSubmissionDate");

                    b.Property<DateTime?>("CoachInfoApprovalDate");

                    b.Property<DateTime?>("CoachInfoDenialDate");

                    b.Property<DateTime?>("CoachInfoSubmissionDate");

                    b.Property<DateTime?>("CoachInterestApprovalDate");

                    b.Property<DateTime?>("CoachInterestDenialDate");

                    b.Property<DateTime?>("CoachInterestSubmissionDate");

                    b.Property<DateTime?>("IdApprovalDate");

                    b.Property<DateTime?>("IdDenialDate");

                    b.Property<DateTime?>("IdSubmissionDate");

                    b.Property<DateTime?>("NFHSApprovalDate");

                    b.Property<DateTime?>("NFHSDenialDate");

                    b.Property<DateTime?>("NFHSSubmissionDate");

                    b.Property<DateTime?>("PcaApprovalDate");

                    b.Property<DateTime?>("PcaDenialDate");

                    b.Property<DateTime?>("PcaSubmissionDate");

                    b.Property<DateTime?>("PledgeApprovalDate");

                    b.Property<DateTime?>("PledgeDenialDate");

                    b.Property<DateTime?>("PledgeSubmissionDate");

                    b.HasKey("ApplicationStatusID");

                    b.ToTable("ApplicationStatus");
                });

            modelBuilder.Entity("KidSports.Models.AppStateJoin", b =>
                {
                    b.Property<int>("AppStateJoinID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationID");

                    b.Property<int>("StateID");

                    b.HasKey("AppStateJoinID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("StatesLived");
                });

            modelBuilder.Entity("KidSports.Models.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaName");

                    b.HasKey("AreaID");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("KidSports.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExperienceName");

                    b.HasKey("ExperienceID");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("KidSports.Models.Grade", b =>
                {
                    b.Property<int>("GradeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GradeName");

                    b.HasKey("GradeID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("KidSports.Models.PreviousGradesCoached", b =>
                {
                    b.Property<int>("PreviousGradesCoachedID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GradeName");

                    b.HasKey("PreviousGradesCoachedID");

                    b.ToTable("PreviousGradesCoached");
                });

            modelBuilder.Entity("KidSports.Models.School", b =>
                {
                    b.Property<int>("SchoolID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AreaID");

                    b.Property<string>("SchoolName");

                    b.HasKey("SchoolID");

                    b.HasIndex("AreaID");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("KidSports.Models.Sport", b =>
                {
                    b.Property<int>("SportID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender");

                    b.Property<int>("MaxGrade");

                    b.Property<int>("MinGrade");

                    b.Property<string>("SportName");

                    b.HasKey("SportID");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("KidSports.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StateName");

                    b.HasKey("StateID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("KidSports.Models.UpdateApplink", b =>
                {
                    b.Property<int>("UpdateApplinkID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("BevBlog");

                    b.Property<string>("CoachPledge");

                    b.Property<string>("Email");

                    b.Property<string>("FaceBookCoach");

                    b.Property<string>("FaceBookKidsports");

                    b.Property<string>("Fax");

                    b.Property<string>("Instragram");

                    b.Property<string>("NFHS");

                    b.Property<string>("PCA");

                    b.Property<string>("Phone");

                    b.Property<string>("Twitter");

                    b.Property<string>("Voucher");

                    b.HasKey("UpdateApplinkID");

                    b.ToTable("Applinks");
                });

            modelBuilder.Entity("KidSports.Models.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AlternatePhone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PreferredName");

                    b.Property<string>("PreviousLastName1");

                    b.Property<string>("PreviousLastName2");

                    b.Property<string>("PreviousLastName3");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int?>("currentYearAppApplicationID");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("currentYearAppApplicationID");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KidSports.Models.AppAreaJoin", b =>
                {
                    b.HasOne("KidSports.Models.Application")
                        .WithMany("Areas")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KidSports.Models.AppExpJoin", b =>
                {
                    b.HasOne("KidSports.Models.Application")
                        .WithMany("PreviousExperience")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KidSports.Models.Application", b =>
                {
                    b.HasOne("KidSports.Models.Area", "AppArea")
                        .WithMany()
                        .HasForeignKey("AppAreaAreaID");

                    b.HasOne("KidSports.Models.School", "AppSchool")
                        .WithMany()
                        .HasForeignKey("AppSchoolSchoolID");

                    b.HasOne("KidSports.Models.Sport", "AppSport")
                        .WithMany()
                        .HasForeignKey("AppSportSportID");

                    b.HasOne("KidSports.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateID");

                    b.HasOne("KidSports.Models.User")
                        .WithMany("UserApplications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("KidSports.Models.AppStateJoin", b =>
                {
                    b.HasOne("KidSports.Models.Application")
                        .WithMany("StatesLived")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KidSports.Models.School", b =>
                {
                    b.HasOne("KidSports.Models.Area")
                        .WithMany("AreaSchools")
                        .HasForeignKey("AreaID");
                });

            modelBuilder.Entity("KidSports.Models.User", b =>
                {
                    b.HasOne("KidSports.Models.Application", "currentYearApp")
                        .WithMany()
                        .HasForeignKey("currentYearAppApplicationID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KidSports.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KidSports.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KidSports.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
