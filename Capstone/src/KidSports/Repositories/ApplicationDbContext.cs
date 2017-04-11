using KidSports.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KidSports.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<IdentityUserLogin<string>>();
            //modelBuilder.Ignore<IdentityUserRole<string>>();
            //modelBuilder.Ignore<IdentityUserClaim<string>>();
            //modelBuilder.Ignore<IdentityUserToken<string>>();
            //modelBuilder.Ignore<IdentityUser<string>>();
        }
    }
}

    /* Notes:
        OnModelCreating is called when the model for a derived context has been initialized, 
        but before the model has been locked down and used to initialize the context.
        modelBuilder.Ignore excludes the specified type(s) from the model. 
        This is used to remove types from the model that were added by convention 
        during initial model discovery. In our case, we are excluding the types defined 
        in IdentityUser since these will be handled in our other database
     */