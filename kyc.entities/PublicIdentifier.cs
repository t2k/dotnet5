namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;


  [Table("PublicIdentifier")]
  public partial class PublicIdentifier
  {
    public int Id { get; set; }
    [Required]
    public Identifier IdType { get; set; }

    [Required]
    public string Value { get; set; }

    public int CIPDetailId { get; set; }

    public virtual CIPDetail CIPDetail { get; set; }
  }
}
