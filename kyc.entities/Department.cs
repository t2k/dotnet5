namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("Department")]
  public partial class Department
  {
    public int Id { get; set; }

    public Department()
    {
      this.Customers = new HashSet<Customer>();
    }

    [Required, Display(Name="Department")]
    public string Name { get; set; }

    [Display(Name = "Region")]
    public int RegionId { get; set; }
    public virtual Region Region { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
  }
}