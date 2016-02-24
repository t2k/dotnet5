namespace kyc.entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("RiskCategory")]
  public partial class RiskCategory
  {
    public RiskCategory()
    {
      this.RiskItems = new HashSet<RiskItem>();
    }

    public int Id { get; set; }

    [Required(ErrorMessage="Catgory is required"), Display(Name="Category")]
    public string CategoryName { get; set; }

    [Display(Name="Sort Order")]
    public int Ordinal { get; set; }

    public virtual ICollection<RiskItem> RiskItems { get; set; }
  }
}