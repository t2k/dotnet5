namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("RiskClass")]
  public partial class RiskClass
  {
    public RiskClass()
    {
      this.RiskItems = new HashSet<RiskItem>();
    }

    public int Id { get; set; }

    [Required]
    public string Classification { get; set; }

    [Display(Name = "Sort Order")]
    public int Ordinal { get; set; }

    public virtual ICollection<RiskItem> RiskItems { get; set; }
  }
}