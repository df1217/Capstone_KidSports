using KidSports.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KidSports.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatus{ get; set; }
        public DbSet<PreviousGradesCoached> PreviousGradesCoached { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<UpdateApplink> Applinks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}