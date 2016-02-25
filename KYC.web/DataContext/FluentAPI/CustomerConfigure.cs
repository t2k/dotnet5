using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity;
using kyc.entities;

namespace KYC.web.DataContext.FluentAPI
{
    public class ConfigureCustomer
    {
        public ConfigureCustomer(ModelBuilder builder)
        {   
            builder.Entity<Customer>()           
            .HasMany<Event>(c => c.Events)
            .WithMany(e => e.Customers).Map(m =>
            {
                m.ToTable("CustomerEvent");
                m.MapLeftKey("CustomerId");
                m.MapRightKey("EventId");
            });

            b.HasMany<Note>(c => c.Notes)
              .WithMany(n => n.Customers).Map(m =>
              {
                  m.ToTable("CustomerNote");
                  m.MapLeftKey("CustomerId");
                  m.MapRightKey("NoteId");
              });

            b.HasMany(c => c.KYCInterfaces)
              .WithMany(k => k.Customers).Map(m =>
              {
                  m.ToTable("CustomerInterface");
                  m.MapLeftKey("CustomerId");
                  m.MapRightKey("InterfaceId");
              });

            b.HasMany(c => c.Locations)
              .WithMany(e => e.Customers).Map(m =>
              {
                  m.ToTable("CustomerLocation");
                  m.MapLeftKey("CustomerId");
                  m.MapRightKey("LocationId");
              });


        }

    }

}