using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KidSports.Repositories;

namespace KidSports.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KidSports.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("AppApprovalDate");

                    b.Property<bool>("AppIsChecked");

                    b.Property<int?>("AppSchoolSchoolID");

                    b.Property<int?>("AppSportSportID");

                    b.Property<DateTime>("AppStartDate");

                    b.Property<string>("BackgroundRequest");

                    b.Property<string>("BackgroundResult");

                    b.Property<DateTime>("BadgeApprovalDate");

                    b.Property<string>("BadgePath");

                    b.Property<DateTime>("BadgeSubmissionDate");

                    b.Property<DateTime>("BcApprovalDate");

                    b.Property<DateTime>("BcSubmissionDate");

                    b.Property<string>("City");

                    b.Property<string>("CurrentEmployer");

                    b.Property<DateTime>("DOB");

                    b.Property<DateTime>("DlApprovalDate");

                    b.Property<string>("DlPath");

                    b.Property<DateTime>("DlSubmissionDate");

                    b.Property<string>("JobTitle");

                    b.Property<string>("NameOfChild");

                    b.Property<DateTime>("NfhsApprovalDate");

                    b.Property<bool>("NfhsIsChecked");

                    b.Property<string>("NfhsPath");

                    b.Property<DateTime>("NfhsSubmissionDate");

                    b.Property<DateTime>("PcaApprovalDate");

                    b.Property<bool>("PcaIsChecked");

                    b.Property<string>("PcaPath");

                    b.Property<DateTime>("PcaSubmissionDate");

                    b.Property<string>("PcaVoucherCode");

                    b.Property<DateTime>("PledgeApprovalDate");

                    b.Property<string>("PledgeInitials");

                    b.Property<DateTime>("PledgeSubmissionDate");

                    b.Property<DateTime>("PrefApprovalDate");

                    b.Property<DateTime>("PrefSubmissionDate");

                    b.Property<int?>("PreviousGradesCoached");

                    b.Property<int?>("PreviousYearsCoached");

                    b.Property<string>("State");

                    b.Property<string>("UserId");

                    b.Property<int>("YearsExperience");

                    b.Property<string>("ZipCode");

                    b.HasKey("ApplicationID");

                    b.HasIndex("AppSchoolSchoolID");

                    b.HasIndex("AppSportSportID");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("KidSports.Models.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationID");

                    b.Property<string>("AreaName");

                    b.HasKey("AreaID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("KidSports.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationID");

                    b.Property<string>("CountryName");

                    b.HasKey("CountryID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("KidSports.Models.LastName", b =>
                {
                    b.Property<int>("LastNameID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationID");

                    b.Property<string>("Name");

                    b.HasKey("LastNameID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("LastName");
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

                    b.Property<int?>("ApplicationID");

                    b.Property<string>("StateName");

                    b.HasKey("StateID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("State");
                });

            modelBuilder.Entity("KidSports.Models.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

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

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

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

            modelBuilder.Entity("KidSports.Models.Application", b =>
                {
                    b.HasOne("KidSports.Models.School", "AppSchool")
                        .WithMany()
                        .HasForeignKey("AppSchoolSchoolID");

                    b.HasOne("KidSports.Models.Sport", "AppSport")
                        .WithMany()
                        .HasForeignKey("AppSportSportID");

                    b.HasOne("KidSports.Models.User")
                        .WithMany("UserApplications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("KidSports.Models.Area", b =>
                {
                    b.HasOne("KidSports.Models.Application")
                        .WithMany("Region")
                        .HasForeignKey("ApplicationID");
                });

            modelBuilder.Entity("KidSports.Models.Country", b =>
                {
                    b.HasOne("KidSports.Models.Application")
                        .WithMany("CountriesLived")
                        .HasForeignKey("ApplicationID");
                });

            modelBuilder.Entity("KidSports.Models.LastName", b =>
                {
                    b.HasOne("KidSports.Models.Application")
                        .WithMany("PreviousLastNames")
                        .HasForeignKey("ApplicationID");
                });

            modelBuilder.Entity("KidSports.Models.School", b =>
                {
                    b.HasOne("KidSports.Models.Area")
                        .WithMany("AreaSchools")
                        .HasForeignKey("AreaID");
                });

            modelBuilder.Entity("KidSports.Models.State", b =>
                {
                    b.HasOne("KidSports.Models.Application")
                        .WithMany("StatesLived")
                        .HasForeignKey("ApplicationID");
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
