namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Region")]
  public partial class Region
  {
    public Region()
    {
      Departments = new HashSet<Department>();
    }
    public int Id { get; set; }
    [Required, Display(Name = "Region")]
    public string RegionName { get; set; }
    public virtual ICollection<Department> Departments { get; set; }
  }
}