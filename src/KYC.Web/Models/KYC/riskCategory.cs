namespace KYC.Web.Models.KYC
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("RiskCategory")]
  public partial class RiskCategory
  {

    public int Id { get; set; }

    [Required(ErrorMessage="Catgory is required"), Display(Name="Category")]
    public string CategoryName { get; set; }

    [Display(Name="Sort Order")]
    public int Ordinal { get; set; }

    public virtual List<RiskItem> RiskItems { get; set; }
  }
}