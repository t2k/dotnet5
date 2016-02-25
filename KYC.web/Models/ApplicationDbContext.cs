using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

using kyc.entities;

namespace KYC.web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Conventions.Remove<PluralizingTableNameConvention>();

      //configure with fluentAPI
            builder.Configurations.Add(new CustomerEntityConfiguration());
            builder.Configurations.Add(new PersonEntityConfiguration());
            builder.Configurations.Add(new RiskReportEntityConfiguration());
            builder.Configurations.Add(new CustomerRiskAssessmentEntityConfiguration());

            base.OnModelCreating(builder);            
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
