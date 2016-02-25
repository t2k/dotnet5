using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using KYC.Entities;

namespace KYC.Web.DataContext.FluentAPI
{
  public class CustomerEntityConfiguration:EntityTypeConfiguration<Customer>
  {
    public CustomerEntityConfiguration()
    {
      this.HasMany<Event>(c => c.Events)
        .WithMany(e => e.Customers).Map(m =>
        {
          m.ToTable("CustomerEvent");
          m.MapLeftKey("CustomerId");
          m.MapRightKey("EventId");
        });

      this.HasMany<Note>(c => c.Notes)
        .WithMany(n => n.Customers).Map(m =>
        {
          m.ToTable("CustomerNote");
          m.MapLeftKey("CustomerId");
          m.MapRightKey("NoteId");
        });

      this.HasMany(c => c.KYCInterfaces)
        .WithMany(k => k.Customers).Map(m =>
        {
          m.ToTable("CustomerInterface");
          m.MapLeftKey("CustomerId");
          m.MapRightKey("InterfaceId");
        });

      this.HasMany(c => c.Locations)
        .WithMany(e => e.Customers).Map(m =>
        {
          m.ToTable("CustomerLocation");
          m.MapLeftKey("CustomerId");
          m.MapRightKey("LocationId");
        });

    }


  }
}