namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Interface")]
  public partial class Interface
  {
    public Interface()
    {
      Customers = new HashSet<Customer>();
    }

    public int Id { get; set; }

    [Required, Display(Name="KYC ")]
    public KYCSystemInterface Name { get; set; }

    [Required, DataType(DataType.MultilineText)]
    public string Description { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
  }
}
