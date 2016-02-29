using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KYC.Entities;

namespace KYC.Web.DataContext.FluentAPI
{
  public class CustomerRiskAssessmentEntityConfiguration : EntityTypeConfiguration<CustomerRiskAssessment>
  {
    public CustomerRiskAssessmentEntityConfiguration()
    {
      //M2M Customer - CustomerRiskAssessemnt
      this.HasKey(x => x.Id)
        .HasMany(p => p.AssessedRiskItems)
        .WithMany().Map(x =>
        {
          x.ToTable("AssessedRiskItems");
          x.MapLeftKey("CustomerRiskAssessementId");
          x.MapRightKey("RiskItemId");
        });
    }
  }
}