using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using kyc.entities;
using Microsoft.Extensions.PlatformAbstractions;


namespace KYC.web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<CIPDetail> CIPDetails { get; set; }
        public virtual DbSet<FinancialInstitution> FIDetails { get; set; }
        public virtual DbSet<LEPrivate> LEPriDetails { get; set; }
        public virtual DbSet<LEPublic> LEPubDetails { get; set; }
        public virtual DbSet<PublicIdentifier> PublicIdentifiers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }
        public virtual DbSet<CustomerOwnership> CustomerOwnerships { get; set; }
        public virtual DbSet<CustomerRiskAssessment> CustomerRiskAssessments { get; set; }
        public virtual DbSet<CustomerSAPDetail> SAPDetails { get; set; }
        public virtual DbSet<CustomerEmployeeRole> CustomerEmployeeRoles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Interface> Interfaces { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PublicExchange> PublicExchanges { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RiskCategory> RiskCategories { get; set; }
        public virtual DbSet<RiskClass> RiskClasses { get; set; }
        public virtual DbSet<RiskItem> RiskItems { get; set; }
        public virtual DbSet<RiskReport> RiskReports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SAPBPStatus> BPStatuses { get; set; }
        public virtual DbSet<SAPLegalForm> LegalForms { get; set; }
        public virtual DbSet<SAPCountry> SAPCountries { get; set; }
        public virtual DbSet<SAPLegalEntity> LegalEntities { get; set; }
        public virtual DbSet<SAPRiskSector> RiskSectors { get; set; }
        public virtual DbSet<SAPSystematic> Systematics { get; set; }
        public virtual DbSet<SAPIndustry> SAPIndustries { get; set; }
        public virtual DbSet<DocumentRiskCycle> DocumentRiskCycles { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<CustomerDocument> CustomerDocuments { get; set; }
        public virtual DbSet<GeographicRiskRating> GeographicRiskRatings { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<DocumentRule> DocumentRules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Conventions.Remove<PluralizingTableNameConvention>();

            //configure with fluentAPI
            /*
                builder.Configurations.Add(new CustomerEntityConfiguration());
                builder.Configurations.Add(new PersonEntityConfiguration());
                builder.Configurations.Add(new RiskReportEntityConfiguration());
                builder.Configurations.Add(new CustomerRiskAssessmentEntityConfiguration());
            */
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
