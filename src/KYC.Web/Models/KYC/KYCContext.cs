using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;



namespace KYC.Web.Models.KYC
{
    public class KYCContext : DbContext
    {
        public KYCContext(DbContextOptions<KYCContext> options) : base(options)
        { }

        public DbSet<RiskCategory> RiskCategories { get; set; }  // six categories
        public DbSet<RiskClass> RiskClasses { get; set; }  // High Medium Low
        public DbSet<RiskItem> RiskItems { get; set; }
        public DbSet<RiskReport> RiskReports { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRiskAssessment> RiskAssessments { get; set; }

        //public DbSet<Blog> 
        //Blogs { get; set; }
        //public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // dummy for testing...
            //builder.Entity<Blog>().HasMany(p=>p.Posts).WithOne();

            // define a many to many relationship 
            builder.Entity<RiskReportItem>()
            .HasKey(k => new { k.RiskReportId, k.RiskItemId });

            
            builder.Entity<RiskReportItem>()
            .HasOne(i => i.RiskItem)
            .WithMany(i=>i.RiskReportItems)
            .HasForeignKey(fk=> fk.RiskItemId);
         
            builder.Entity<RiskReportItem>()
            .HasOne(i=>i.RiskReport)
            .WithMany(r=> r.RiskReportItems)
            .HasForeignKey(fk=>fk.RiskReportId);


            /*
            builder.Entity<RiskItem>()
            .HasOne(r => r.RiskCategory)
            .WithMany(i => i.RiskItems)
            .HasForeignKey(fk => fk.RiskCategoryId);
            */

            // riskReportItem set key

            


 

             
            // builder.Entity<Customer>().HasMany(d => d.Documents).WithOne(c => c.Customer);

            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
