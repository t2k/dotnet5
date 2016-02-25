namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("LEPrivate")]
  public partial class LEPrivate : CIPDetail
  {
    public string OwnersPlus20Pct { get; set; }
  }

}