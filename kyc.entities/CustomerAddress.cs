namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("CustomerAddress")]
  public partial class CustomerAddress
  {

    [Key, ForeignKey("Customer")]
    public int CustomerId { get; set; }


    [Display(Name="Name (care of)")]
    public string COName { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = "Address (care of)")]
    public string COAddress { get; set; }

    [Display(Name = "Legal Name")]
    public string LName { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = "Legal Address")]
    public string LAddress { get; set; }

    public virtual Customer Customer { get; set; }
  }
}
