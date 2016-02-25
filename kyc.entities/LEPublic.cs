namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("LEPublic")]
  public partial class LEPublic : CIPDetail
  {
    public string PublicExchange { get; set; }
  }
}

