namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;


  public partial class Location
  {

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name="Location Type")]
    public LocationType? LocationType { get; set; }

    [Display(Name = "Location")]
    [Required, DataType(DataType.MultilineText)]
    public string FullAddress { get; set; }


    public virtual ICollection<Customer> Customers { get; set; }
  }
}
