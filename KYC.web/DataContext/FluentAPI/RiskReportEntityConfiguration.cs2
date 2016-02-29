using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KYC.Entities;

namespace KYC.Web.DataContext.FluentAPI
{
  public class RiskReportEntityConfiguration : EntityTypeConfiguration<RiskReport>
  {
    public RiskReportEntityConfiguration()
    {
      this.HasMany(r => r.RiskItems)
        .WithMany(r => r.RiskReports).Map(x =>
        {
          x.ToTable("RiskReportItems");
          x.MapLeftKey("RiskReportID");
          x.MapRightKey("RiskItemId");
        });
    }
  }
}