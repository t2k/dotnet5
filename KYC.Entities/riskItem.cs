namespace KYC.Entities
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  // using System.Data.Entity.Spatial;

  [Table("RiskItem")]
  public partial class RiskItem
  {
    public int Id { get; set; }

    [Display(Name="Risk Item"), Required]
    public string Description { get; set; }

    [Display(Name = "Risk Score"), Required]
    public int Score { get; set; }

    [Display(Name="Category")]
    public int RiskCategoryId { get; set; }
    public virtual RiskCategory RiskCategory { get; set; }

    [Display(Name = "Classification")]
    public int RiskClassId { get; set; }
    public virtual RiskClass RiskClass { get; set; }

    /// <summary>
    /// many to many Ri to RRs
    /// </summary>
    public virtual ICollection<RiskReport> RiskReports { get; set; }
    public virtual ICollection<CustomerRiskAssessment> AssessedRiskItems { get; set; }
  }
}
