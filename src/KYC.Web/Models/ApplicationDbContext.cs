using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using KYC.Entities;

namespace KYC.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<RiskCategory> RiskCategories { get; set; }
        public DbSet<RiskClass> RiskClasses { get; set; }
        public DbSet<RiskItem> RiskItems { get; set; }
        public DbSet<RiskReport> RiskReports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // builder.Entity<Customer>().HasMany(n => n.Notes).WithOne(c => c.Customer);
            //  builder.Entity<Customer>().HasMany(l => l.Locations).WithOne(c => c.Customer);
            // builder.Entity<Customer>().HasMany(d => d.Documents).WithOne(c => c.Customer);

            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var path = PlatformServices.Default.Application.ApplicationBasePath;
            //optionsBuilder.UseSqlite("Filename=./kycdb.sqlite"); // + 

        }
    }
}
