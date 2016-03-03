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
        
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>().HasMany(p=>p.Posts).WithOne();
            
            builder.Entity<RiskItem>().HasOne(r => r.RiskClass).WithMany(i => i.RiskItems);
            builder.Entity<RiskItem>().HasOne(r => r.RiskCategory).WithMany(i => i.RiskItems);
            
            // riskReportItem
            // set key
            builder.Entity<RiskReportItem>()
            .HasKey(k => new {k.RiskReportId, k.RiskItemId});
            
            builder.Entity<RiskReportItem>().HasOne(r => r.RiskReport)
            .WithMany(i => i.RiskReportItems)
            .HasForeignKey(k => k.RiskReportId);
            
            builder.Entity<RiskReportItem>().HasOne(r => r.RiskItem)
            .WithMany(i => i.RiskReportItems)
            .HasForeignKey(k => k.RiskItemId);
            
            
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
