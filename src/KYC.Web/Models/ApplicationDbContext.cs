using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using KYC.Entities;

namespace KYC.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CIPDetail> CIPDetails { get; set; }
        public DbSet<FinancialInstitution> FIDetails { get; set; }
        public DbSet<LEPrivate> LEPriDetails { get; set; }
        public DbSet<LEPublic> LEPubDetails { get; set; }
        public DbSet<PublicIdentifier> PublicIdentifiers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public DbSet<CustomerOwnership> CustomerOwnerships { get; set; }
        public DbSet<CustomerRiskAssessment> CustomerRiskAssessments { get; set; }
        public DbSet<CustomerSAPDetail> SAPDetails { get; set; }
        public DbSet<CustomerEmployeeRole> CustomerEmployeeRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Interface> Interfaces { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PublicExchange> PublicExchanges { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RiskCategory> RiskCategories { get; set; }
        public DbSet<RiskClass> RiskClasses { get; set; }
        public DbSet<RiskItem> RiskItems { get; set; }
        public DbSet<RiskReport> RiskReports { get; set; }
        public DbSet<Role> KYCRoles { get; set; }
        public DbSet<SAPBPStatus> BPStatuses { get; set; }
        public DbSet<SAPLegalForm> LegalForms { get; set; }
        public DbSet<SAPCountry> SAPCountries { get; set; }
        public DbSet<SAPLegalEntity> LegalEntities { get; set; }
        public DbSet<SAPRiskSector> RiskSectors { get; set; }
        public DbSet<SAPSystematic> Systematics { get; set; }
        public DbSet<SAPIndustry> SAPIndustries { get; set; }
        //public virtual DbSet<DocumentRiskCycle> DocumentRiskCycles { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<CustomerDocument> CustomerDocuments { get; set; }
        public DbSet<GeographicRiskRating> GeographicRiskRatings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DocumentRule> DocumentRules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Customer>().HasMany(n => n.Notes).WithOne(c => c.Customer);
            builder.Entity<Customer>().HasMany(l => l.Locations).WithOne(c => c.Customer);
            builder.Entity<Customer>().HasMany(d => d.Documents).WithOne(c => c.Customer);

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
