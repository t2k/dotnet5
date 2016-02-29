using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KYC.Entities;

namespace KYC.Web.DataContext.FluentAPI
{
  public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
  {
    public PersonEntityConfiguration()
    {
      // M2M Person - Phone
      this.HasMany(p => p.Phones)
        .WithMany().Map(x =>
        {
          x.MapLeftKey("PersonId");
          x.MapRightKey("PhoneId");
          x.ToTable("PersonPhone");
        });
    }
  }
}