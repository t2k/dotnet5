namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("Role")]
  public partial class Role
  {
    public int Id { get; set; }

    [Required, Display(Name = "Role Name")]
    public string Name { get; set; }

    [Required, DataType(DataType.MultilineText)]
    public string Description{ get; set; }


  }
}